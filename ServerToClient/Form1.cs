using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerToClient
{
    public partial class Form1 : Form
    {
        Socket s;
        byte[] bytes = new byte[1024];

        public Form1()
        {
            InitializeComponent();

            try
            {
                IPHostEntry ipHost = Dns.Resolve("localhost");
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 8086);
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                s.Connect(ipEndPoint);
                this.Text = "Сокет соединен с" + s.RemoteEndPoint.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textBox1Name = textBox1.Text;
            string textBox3Type = textBox3.Text;
            // Отправка сообщения
            byte[] msg1 = Encoding.UTF8.GetBytes("name:" + textBox1Name + 
                                                 ";date:"+ dateTimePicker1.Value.ToString("dd.MM.yyyy") + 
                                                 ";type:" + textBox3Type);
            s.Send(msg1);
            // Получение ответа от сервера
            int bytesRec = s.Receive(bytes);
            string data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            MessageBox.Show(data);
            
        }
    }
}