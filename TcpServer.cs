using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Int8 = System.SByte;
using System.IO;

namespace ModelSat_Test_Kite
{
    class TcpServer
    {
        public static DateTime lastCounter = DateTime.Now;
        private static int bufferSize = 420;

        public static RichTextBox console { get; set; }

        Socket server;

        public StreamWriter writer;

        public void OpenConnection()
        {
            //bunu da bir kere çağırıyorsun ön tarafta
            //init ediyoruz gibi düşün sonra zaten ListenToClient()
            //metodunu çağırıyor ve orda client'ı asenkron dinliyor
            writer = new StreamWriter("../log"+DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss")+".csv");
            var endpoint = new IPEndPoint(IPAddress.Any, 8080);

            server = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Bind(endpoint);
                server.Listen(128);
                _ = Task.Run(() => ListenToClient(server));
            }
            catch (Exception ex)
            {
                _ = Task.Run(() => ListenToClient(server));
            }


        }

        private async Task ListenToClient(Socket server)
        {
            do
            {
                var clientSocket = await Task.Factory.FromAsync(
                    new Func<AsyncCallback, object, IAsyncResult>(server.BeginAccept),
                    new Func<IAsyncResult, Socket>(server.EndAccept), null).ConfigureAwait(false);

                using (var stream = new NetworkStream(clientSocket, true))
                {
                    var receivedBuffer = new byte[bufferSize];

                    do
                    {
                        DateTime timeOne = DateTime.Now;
                        int bytesRead = await stream.ReadAsync(receivedBuffer, 0, receivedBuffer.Length).ConfigureAwait(false);

                        lastCounter = DateTime.Now;

                        int startingIndex = 0;
                        int sumCheck = 0;

                        if (bytesRead == 0)
                        {
                            break;
                        }

                        DateTime timeTwo = DateTime.Now;

                        var difference = timeTwo - timeOne;

                        console.Text += "\n" + difference.ToString();

                        Int8 returnData = (Int8)BitConverter.ToChar(receivedBuffer, startingIndex);

                        console.Text += "\n" + returnData.ToString();

                        writer.WriteLine(returnData.ToString() + "," + difference.TotalSeconds.ToString() + "," + DateTime.Now);
                        
                        receivedBuffer = new byte[bufferSize];


                    } while (true);
                }
                
            } while (true);
        }


        Socket transmitClient;
        Socket transmitSocket;
        IPEndPoint transmitIp;

        public async void OpenTransmit()
        {
            //transmit portunu açıp client'a bağlanılmasını sağlıyor
            //bunu bir defa çağırıp init ediyoruz gibi düşün

            await Task.Run(() =>
            {
                transmitIp = new IPEndPoint(IPAddress.Any, 3333);
                transmitSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                transmitSocket.Bind(transmitIp);
                transmitSocket.Listen(10);

                transmitClient = transmitSocket.Accept();
                var clientep = (IPEndPoint)transmitClient.RemoteEndPoint;
            });

        }

        private async void ReOpenTransmit(byte[] buffer)
        {
            //bunun ön tarafla alakası yok
            await Task.Run(() =>
            {
                transmitClient = transmitSocket.Accept();
                var clientep = (IPEndPoint)transmitClient.RemoteEndPoint;
                TransmitData(buffer);

            });

        }

        public async void TransmitData(byte[] sendBuffer)
        {
            //veri göndereceğin zaman alıyosun usta, göndermek istediğin bufferı veriyosun parametre
            //olarak o gerisini senin yerine hallediyor uzda

            await Task.Run(() =>
            {
                try
                {
                    transmitClient.Send(sendBuffer, sendBuffer.Length, SocketFlags.None);
                }
                catch (Exception)
                {
                    ReOpenTransmit(sendBuffer);
                }

            });

        }

    }
}
