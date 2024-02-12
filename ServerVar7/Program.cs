using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ServerVar7
{
    internal class Program
    {
    
    static void Main(string[] args)
    {
        
        try
        {
            // IPAddress.Parse("26.125.30.60")
            TcpListener server = new TcpListener(IPAddress.Parse("26.125.30.60"), 8080);
            server.Start();
            Console.WriteLine("Server starting ...");
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine($"Client connected {client.Client.RemoteEndPoint}");
                NetworkStream networkStream = client.GetStream();
                var buffer = new byte[1024];
                
                BinaryFormatter outFormatter = new BinaryFormatter();
                // Console.WriteLine("Введите путь сохранения файла, иначе файл будет сохранен в папке приложения");
                using (var ms = new MemoryStream())
                {
                    Console.WriteLine("File saving");
                    int bytesRead;
                    while ((bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                        if (networkStream.DataAvailable == false)
                        {
                            break;
                        }
                    }

                    var fileBytes = ms.ToArray();
                    var path = "receivedFile.txt";
                    File.WriteAllBytes(path, fileBytes);

                    var msg = File.ReadAllText(path);
                    
                    // Sending msg to client
                    var resultWrite = WriteNewFile(msg);
                    Console.WriteLine($"Result WriteNewFile: {Encoding.UTF8.GetString(resultWrite)}");
                    networkStream.Write(resultWrite,0,resultWrite.Length);
                }
                
                client.Close();
                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    // Parser recv to name, date, type
    private static string[] Parser(string recv)
    {
        string[] result = new string[3];
        string[] temp = recv.Split(';');
        result[0] = temp[0].Split(':')[1];
        result[1] = temp[1].Split(':')[1];
        result[2] = temp[2].Split(':')[1];
        Console.WriteLine("Параметр 1: {0}", result[0]);
        Console.WriteLine("Параметр 2: {0}", result[1]);
        Console.WriteLine("Параметр 3: {0}", result[2]);
        return result;
    }
    
    private static byte[] WriteNewFile(string data)
    {
        try
        {
            string[] dataResult = Parser(data);
            int sum = 0;
            byte[] message;
            int param1 = Convert.ToInt32(dataResult[0]);
            int param2 = Convert.ToInt32(dataResult[1]);
            int param3 = Convert.ToInt32(dataResult[2]);
            sum = param1 + param2 + param3;
            message = Encoding.UTF8.GetBytes(sum.ToString());
            
            /*
            // Проверка на срок хранения
            DateTime date = DateTime.Parse(dataResult[1]);
            DateTime now = DateTime.Now;
            TimeSpan difference = now - date;
            int days = difference.Days;
            int index = 0;
            Console.WriteLine($"Product Type: {dataResult[2]}");
            int typeIndex = 0;
            
            for (int i = 0; i < type.Length; i++)
            {
                if (dataResult[2].ToString() == type[i])
                {
                    typeIndex = i;
                    break;
                }
            }
            // index = Array.IndexOf(type, dataResult[2]) != 0 ? index : 0 ;
            byte[] msg;
            Console.WriteLine($"Difference Days: {days}\nTime Index: {time[index]}");
            
            if (days > time[typeIndex])
            {
                Console.WriteLine("Срок хранения истек");
                msg = Encoding.UTF8.GetBytes("Срок хранения истек");
            }
            else
            {
                Console.WriteLine("Срок хранения не истек");
                msg = Encoding.UTF8.GetBytes("Срок хранения не истек");
            }*/

            return message;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Encoding.UTF8.GetBytes("Ошибка");
        }
    }
    }
}