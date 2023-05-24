using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpClient
{
    public partial class Form1 : Form
    {
        private bool WriteInFile(string path)
        {
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);
                // Write data in file
                string textBox1Name = textBox2.Text;
                string textBox3Type = textBox3.Text;
                // Отправка сообщения
                byte[] msg1 = Encoding.UTF8.GetBytes("name:" + textBox1Name + 
                                                     ";date:"+ dateTimePicker1.Value.ToString("dd.MM.yyyy") + 
                                                     ";type:" + textBox3Type);
                // Записать пустую строчку (очистить содержимое)
                /*using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(msg1);
                    sw.Close();
                }*/
                
                fileStream.Write(msg1, 0, msg1.Length);
                fileStream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
        public Form1()
        {
            InitializeComponent();
            /*try
            {
                IPHostEntry ipHost = Dns.Resolve("26.81.20.164");
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
            // localhost = 127.0.0.1
            // martin 26.159.100.61
            client.Connect(IPAddress.Parse("26.159.100.61"), 33333);
            Console.WriteLine(@"Connected to server ...");
            
            NetworkStream networkStream = client.GetStream();
            // BinaryFormatter formatter = new BinaryFormatter();

            // path from TextBox1
            string path = textBox1.Text;

            // Write data in file
            string textBox1Name = textBox2.Text;
            string textBox3Type = textBox3.Text;
            var dateFromUser = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            // Отправка сообщения
            byte[] msg1 = Encoding.UTF8.GetBytes("name:" + textBox1Name + 
                                                 ";date:"+ dateFromUser + 
                                                 ";type:" + textBox3Type);
            var msg = $"name:{textBox1Name};date:{dateFromUser};type:{textBox3Type}";
            
            // Записать пустую строчку (очистить содержимое)
            /*using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(msg1);
                sw.Close();
            }*/
            
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
            

            // fileStream.Write(msg1, 0, msg1.Length);
            // fileStream.Close();


            /*if (isWrite)
            {
                long k = fileStream.Length;
                BinaryReader binaryReader = new BinaryReader(fileStream);
                // send file size
                formatter.Serialize(networkStream, k.ToString());
                // send file
                while ((count = binaryReader.Read(buff, 0, buff.Length))>0)
                {
                    formatter.Serialize(networkStream, buff);
                }
                /*fileStream.Close();
                binaryReader.Close();#1#
            }
            else
            {
                Console.WriteLine("Ошибка при записи в файлик");
            }*/

            /*byte[] dataP = new byte[256];
            int lenght = networkStream.Read(dataP, 0, dataP.Length);
            String response = Encoding.UTF8.GetString(dataP, 0, lenght);
            Console.WriteLine("Received: {0}", response);*/

            /*FileStream fs = new FileStream("received.txt", FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fs);
            // received file size
            int size = int.Parse(formatter.Deserialize(networkStream).ToString());
            // received file
            string data = "";
            for (int i = 0; i < size; i += 1024)
            {
                byte[] bufDeserialize = (byte[])formatter.Deserialize(networkStream);
                data = Encoding.UTF8.GetString(bufDeserialize, 0, bufDeserialize.Length);
                Console.WriteLine(data);
                bw.Write(bufDeserialize);
            }
            bw.Close();
            fs.Close();*/
        }

        
    }
}