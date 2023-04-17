using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    // Пропиши в переменные типы товаров и их срок хранения в DateTime
    public static string[] type = new string[3] { "Молоко", "Хлеб", "Мясо" };
    public static int[] time = new int[3] { 10, 5, 3 };
    
    
    static void Main(string[] args)
    {
        
        
        IPHostEntry ipHost = Dns.Resolve("localhost");
        IPAddress ipAddr = ipHost.AddressList[0];
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 8086);
        Socket sListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            sListener.Bind(ipEndPoint);
            sListener.Listen(10);
            while (true)
            {
                Console.WriteLine("Ожидание соединения с другим портом {0}", ipEndPoint);
                Socket handler = sListener.Accept();
                string data = null;
                while (true)
                {
                    byte[] buffer = new byte[2048];
                    int iRx = handler.Receive(buffer);
                    char[] chars = new char[iRx];

                    Decoder d = Encoding.UTF8.GetDecoder();
                    int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
                    String recv = new String(chars);
                    Console.WriteLine("Полученные данные: {0}", recv);
                    
                    string[] result = Parser(recv);
                    // Проверка на срок хранения
                    DateTime date = DateTime.Parse(result[1]);
                    DateTime now = DateTime.Now;
                    TimeSpan difference = now - date;
                    int days = difference.Days;
                    int index = 0;
                    index = Array.IndexOf(type, result[2]) != 0 ? index : 0 ;
                    if (days > time[index])
                    {
                        Console.WriteLine("Срок хранения истек");
                        byte[] msg = Encoding.UTF8.GetBytes("Срок хранения истек");
                        handler.Send(msg);
                    }
                    else
                    {
                        Console.WriteLine("Срок хранения не истек");
                        byte[] msg = Encoding.UTF8.GetBytes("Срок хранения не истек");
                        handler.Send(msg);
                    }
                }
                
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());

        }
    }
    // Parser recv to name, date, type
    public static string[] Parser(string recv)
    {
        string[] result = new string[3];
        string[] temp = recv.Split(';');
        result[0] = temp[0].Split(':')[1];
        result[1] = temp[1].Split(':')[1];
        result[2] = temp[2].Split(':')[1];
        Console.WriteLine("Имя: {0}", result[0]);
        Console.WriteLine("Дата: {0}", result[1]);
        Console.WriteLine("Тип: {0}", result[2]);
        return result;
    }
}