// See https://aka.ms/new-console-template for more information

// Verileri oluşturulan sınıflardan al
using System.Net;
using System.Net.Sockets;
using ConsoleApp1.DataSource;
using ConsoleApp1.Entity;


byte[] data = {
    0x00, 0x01, // İşlem tanımlayıcı
    0x00, 0x00, // Protokol tanımlayıcı (Modbus)
    0x00, 0x06, // PDU uzunluk
    0x01,       // Adres (0x11 = 17 ondalık) // cihaz network adresi NAD = 1
    0x03,       // Register oku komutu
    0x00, 0x00, // 0'ıncı registerdan itibaren
    0x00, 0x20  // 20 register (4 byte)
};

var connectionPointData = new ConsoleApp1.DataSource.ConnectionPointData();
var deviceData = new ConsoleApp1.DataSource.DeviceData();
var parameterData = new ConsoleApp1.DataSource.ParameterData();

// Tek bir cihazın ConnectionPointId değeri, elimizde sadece bir cihaz varsa bu değeri direkt olarak belirtebiliriz.
var cp = connectionPointData.ConnectionPoints.FirstOrDefault();
int cpID = cp == null ? 0 : cp.Id;

TcpClient tcpClient = new();

            try
            {
            tcpClient.Connect(cp.IpAddress, cp.PortNumber); // modemin IP adresi ve portu
            
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

                int index =0;

            foreach (var parameter in parameterData.Parameters)
                {
                        if (ushortArray.Length >= 2)
                     {
                        ushort number1 = ushortArray[index];
                        ushort number2 = ushortArray[index+1];
                        uint voltValue = TwoShortToUInt(number1, number2);
                           
                        parameter.Value = voltValue;

                           // Volt değerini göster
                        Console.WriteLine($"Parameter Name: {parameter.ParameterName}, Value: { parameter.Value }, Unit: {GetUnitName(parameter.Unit)}");

                        index+=2;
                     }
                     else
                     {
                        Console.WriteLine("Geçersiz veri alindi.");
                     }    
                 
                 }

            networkStream.Close();

            }
        }
    }

        catch (Exception e)
        {
            Console.WriteLine("Hata: {0}", e.Message);
        }



// Birim numarasına göre birim adını al
static string GetUnitName(byte unit)
{
    return unit switch
    {
        (byte)ConsoleApp1.Enums.Unit.V => "Volt",
        (byte)ConsoleApp1.Enums.Unit.A => "Ampere",
        // Diğer birim numaralarına göre de case'ler ekleyebilirsiniz.
        _ => "N/A",
    };
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
