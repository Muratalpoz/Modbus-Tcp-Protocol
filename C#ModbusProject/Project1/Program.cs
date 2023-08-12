using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

byte[] data = {
    0x00, 0x01, // İşlem tanımlayıcı
    0x00, 0x00, // Protokol tanımlayıcı (Modbus)
    0x00, 0x06, // PDU uzunluk
    0x01,       // Adres (0x11 = 17 ondalık) // cihaz network adresi NAD = 1
    0x03,       // Register oku komutu
    0x00, 0x00, // 14'üncü registerdan itibaren
    0x00, 0x02  // Sadece 2 register (4 byte)
};

// Her 5 saniyede bir veri çekmek için bir zamanlayıcı oluşturuyoruz
Timer timer = new(TimerCallback, data, 0, 5000 * 12);

// Zamanlayıcının çalışmasını sağlamak için beklemeye alıyoruz
Console.ReadLine();

static void TimerCallback(object? state) 
{
    byte[]? data = (byte[]?)state;

    TcpClient tcpClient = new();
    try
    {
        tcpClient.Connect("192.168.4.153", 502); // modemin IP adresi ve portu
            
        if (tcpClient.Connected && data != null) // null kontrolü ekleniyor
        {
            NetworkStream networkStream = tcpClient.GetStream(); 
            networkStream.Write(data, 0, data.Length);  // Veriyi gönder

            byte[] rData = new byte[2048];
            int bytes = networkStream.Read(rData, 0, rData.Length); // Yanıtı oku

            if (bytes >= 4)  // 4 byte alındığını varsayıyoruz (2 byte Modbus yanıt başlığı ve 2 byte değer için)
            {


                byte[] resData = GetData(rData);
                ushort[] ushortArray = NetworkBytesToHostUInt16(resData);

                // Alınan ushort array'ı göster
               /* Console.Write("Alınan Ushort Array: ");
                foreach (ushort value in ushortArray)
                {
                    Console.Write($"{value*0.1} ");
                }
                Console.WriteLine(); */
                
                if (ushortArray.Length >= 2)
                {
                    ushort number1 = ushortArray[0];
                    ushort number2 = ushortArray[1];
                    uint voltValue = TwoShortToUInt(number1, number2);

                     // Volt değerini göster
                    Console.WriteLine("Alinan Volt Değeri: " + voltValue);
                }
                else
                {
                    Console.WriteLine("Geçersiz veri alindi.");
                }

            networkStream.Close();
            }
        }
    }

        catch (Exception e)
        {
            Console.WriteLine("Hata: {0}", e.Message);
        }
    }  


static ushort[] NetworkBytesToHostUInt16(byte[] networkBytes)
{
    if (networkBytes == null)
    {
        throw new ArgumentNullException(nameof(networkBytes));
    }

    if (networkBytes.Length % 2 != 0)
    {
        throw new FormatException("NetworkBytesNotEven");
    }

    ushort[] result = new ushort[networkBytes.Length / 2];

    for (int i = 0; i < result.Length; i++)
    {
        result[i] = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(networkBytes, i * 2));
    }

    return result;
}


 static byte[] GetData(Byte[] rData){
    byte function = rData[7];
    byte[] data;

    if(function >=5){
        data = new byte[2];
        Array.Copy(rData, 10, data, 0, 2);
       
    }
    else{
         data = new byte[rData[8]];
        Array.Copy(rData, 9, data, 0, rData[8]);

    }

    return data;
}


static uint TwoShortToUInt(ushort number1, ushort number2){
	
	uint result = number1;
	result <<= 16;
	result += number2;
	return result; 
}
