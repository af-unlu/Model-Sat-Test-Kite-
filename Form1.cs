using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelSat_Test_Kite
{
    public partial class Form1 : Form
    {
        TcpServer server;
        bool isTransmitted = false;

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            TcpServer.console = this.richTextBox_console;

            server = new TcpServer();

            server.OpenConnection();
            //dinleme işlemini başlatıyor
            server.OpenTransmit();

            //arayüzdeki transmit portunu açıyor
            //eğer veri transmit etmek istersen
            //server.TransmitData(buff) şeklinde
            //veri transfer edersin uzda

            timer1.Interval = 1000;
            timer1.Enabled = true;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_pid_send_Click(object sender, EventArgs e)
        {

            richTextBox_console.Text = "";
            float KP_value=0;
            float KI_value=0;
            float KD_value=0;
            byte[] PID_command_packet = new byte[18];
            byte[] crc_packet = new byte[13];

            PID_command_packet[0] = 30;
            PID_command_packet[1] = 31;
            PID_command_packet[2] = 13;
            PID_command_packet[3] = 40;
            crc_packet[0] = 40;

            if (textBox_KP.Text.Length > 0)
            {
                KP_value = Convert.ToSingle(textBox_KP.Text);
            }

            if (textBox_KI.Text.Length > 0)
            {
                KI_value = Convert.ToSingle(textBox_KI.Text);
            }
            if (textBox_KD.Text.Length > 0)
            {
                KD_value = Convert.ToSingle(textBox_KD.Text);
            }

            byte[] KP_byte = BitConverter.GetBytes(KP_value);
            byte[] KI_byte = BitConverter.GetBytes(KI_value);
            byte[] KD_byte = BitConverter.GetBytes(KD_value);

            for (int i = 0, j = 0; j < 4; i++, j++)
            {
                PID_command_packet[i + 4] = KP_byte[j];
                crc_packet[i + 1] = KP_byte[j];
            }
            for (int i = 4, j = 0; j < 4; i++, j++)
            {
                PID_command_packet[i + 4] = KI_byte[j];
                crc_packet[i + 1] = KI_byte[j];
            }
            for (int i = 8, j = 0; j < 4; i++, j++)
            {
                PID_command_packet[i + 4] = KD_byte[j];
                crc_packet[i + 1] = KD_byte[j];
            }

            UInt16 crc = aeskCRCCalculate(crc_packet, 13);
            byte[] crc_temp = BitConverter.GetBytes(crc);
            PID_command_packet[16] = crc_temp[0];
            PID_command_packet[17] = crc_temp[1];
            richTextBox_console.Text += "\nCRC:" + crc.ToString()+"\n";

            foreach(byte x in PID_command_packet)
            {
                richTextBox_console.Text +=" " +x.ToString();
            }
            server.TransmitData(PID_command_packet);



        }

        private ushort aeskCRCCalculate(byte[] frame, uint framesize)
        {
            ushort crc16_data = 0;
            byte data = 0;
            for (byte mlen = 0; mlen < framesize; mlen++)
            {
                data = Convert.ToByte(((byte)frame[mlen] ^ Convert.ToByte(((crc16_data) & (0xFF)))));
                Console.WriteLine(data);
                data = (byte)((byte)data ^ (byte)(data << 4));
                crc16_data = (ushort)((((ushort)data << 8) | ((crc16_data & 0xFF00) >> 8)) ^ (byte)(data >> 4) ^ ((ushort)data << 3));
            }
            return (crc16_data);
        }

        private void button_Ayril_Click(object sender, EventArgs e)
        {
            if (!isTransmitted)
            {
                string stringOne = "Yer Istasyonundan ESPye veri aktarim testi";

                //byte[] buffer = new byte[stringOne.Length + 3];

                server.TransmitData(Encoding.UTF8.GetBytes(stringOne));

                isTransmitted = !isTransmitted;
            }

            else
            {
                string stringTwo = "espye veri aktarım testi v2 diger blok calisti";

                server.TransmitData(Encoding.UTF8.GetBytes(stringTwo));
                isTransmitted = !isTransmitted;
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.writer.Close();
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            richTextBox_console.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button_TeamNumberSend_Click(object sender, EventArgs e)
        {
            byte[] command = { 10, 71 ,21, 60, 0 };
            server.TransmitData(command);
            richTextBox_console.Text += "\n" + "Team Number Set";
        }

        bool video_task_state = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (video_task_state)
            {
                byte[] command = { 10, 71, 30, 5, 13 };
                server.TransmitData(command);
                button1.Text = "VStream is OFF";
                richTextBox_console.Text += "\nVStream is OFF";
            }
            else
            {
                byte[] command = { 10, 71, 30, 5, 5 };
                server.TransmitData(command);
                button1.Text = "VStream is ON";
                richTextBox_console.Text += "\nVStream is ON";
            }
            video_task_state = !video_task_state;

        }
    }
}
