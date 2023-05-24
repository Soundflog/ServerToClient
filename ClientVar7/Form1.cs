using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientVar7
{
    public partial class Form1 : Form
    {
        Socket s;
        byte[] bytes = new byte[1024];

        public Form1()
        {
            InitializeComponent();

            /*try
            {
                IPHostEntry ipHost = Dns.Resolve("10.168.204.58");
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 8080);
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                s.Connect(ipEndPoint);
                this.Text = "Сокет соединен с" + s.RemoteEndPoint.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new System.Net.Sockets.TcpClient();
            // IPAddress.Parse("26.159.100.61")
            client.Connect(IPAddress.Parse("26.125.30.60"), 8080);
            Console.WriteLine(@"Connected to server ...");
            
            NetworkStream networkStream = client.GetStream();
            
            
            string textBox1par = textBox1.Text;
            string textBox2par = textBox2.Text;
            string textBox3par = textBox3.Text;
            // Отправка сообщения
            byte[] msg1 = Encoding.UTF8.GetBytes("param1:" + textBox1par + 
                                                 ";param2:"+ textBox2par + 
                                                 ";param3:" + textBox3par);
            
            var msg = $"param1:{textBox1par};param2:{textBox2par};param3:{textBox3par}";
            // s.Send(msg1);
            string path = "message.txt";
            using (var sw = new StreamWriter(path))
            {
                sw.Write(msg);
            }

            Console.WriteLine(@"File Creating");
            
            var fileBytes = File.ReadAllBytes(path);
            networkStream.Write(fileBytes, 0, fileBytes.Length);
            Console.WriteLine(@"File send");
            
            // Received response from server
            var buffer = new byte[1024];
            var bytesRead = networkStream.Read(buffer, 0, buffer.Length);
            var responseFromServer = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($@"Response From Server: {responseFromServer}");
            MessageBox.Show(responseFromServer);
            networkStream.Close();
            client.Close();
            /*// Получение ответа от сервера
            try
            {
                int bytesRec = s.Receive(bytes);
                string data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                // Console.WriteLine(data);
                MessageBox.Show(data);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }*/
        }
    }
}