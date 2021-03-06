﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO.Ports;

namespace xbitsServer
{
    public partial class Form1 : Form
    {
        public static IPAddress ipAddress;
        public static int PortNo = 3000;
        public static Thread serverThread;
        static SerialPort SP1;
        
        private static readonly Object _Lock = new Object();
        String[] months = { "ETC", "Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public StateObject state2;        
        public volatile bool stopServer = false;
        public volatile bool stopComServer = false;
        String content = String.Empty;
        public class StateObject
        {
            // Client  socket.  
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 4096;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];
            // Received data string.  
            public StringBuilder sb = new StringBuilder();
        }
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public static ManualResetEvent disconnectDone = new ManualResetEvent(false);


        public Form1()
        {
            InitializeComponent();
            SP1 = new SerialPort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int con = 0;
            string[] portNames = SerialPort.GetPortNames();     //<-- Reads all available comPorts
            foreach (var portName in portNames)
            {
                comboBoxComport.Items.Add(portName);                  //<-- Adds Ports to combobox
                con++;
            }if(con > 0) { comboBoxComport.SelectedIndex = 0; }

            linkLabelPath.Text = Properties.Settings.Default.Path;
        }

        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {
            var FolderDialog = new FolderBrowserDialog();
            if (FolderDialog.ShowDialog() == DialogResult.OK)
            {

                linkLabelPath.Text = FolderDialog.SelectedPath;
                Properties.Settings.Default.Path = linkLabelPath.Text.ToString();
                Properties.Settings.Default.Save();
            }
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            stopServer = true;
            allDone.Set();
            if(SP1.IsOpen)
            {
                SP1.DataReceived -= new SerialDataReceivedEventHandler(this.SP1_DataReceived);
                SP1.Dispose();
                SP1.Close();
            }
           
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private IPAddress LocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }

        public void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // The DNS name of the computer  
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, PortNo);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);
                stopServer = false;
                
                while (true)
                {
                    // Set the event to nonsignaled state.  
                    allDone.Reset();
                    
                    // Start an asynchronous socket to listen for connections.  
                    listener.BeginAccept(new AsyncCallback(AcceptCallback),listener);
                    // Wait until a connection is made before continuing.  
                    Invoke(new Action(() =>
                    { richTextBox1.AppendText("\nWaiting for a connection...");}));

                    allDone.WaitOne();
                    if (stopServer)
                    {
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public  void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            allDone.Set();
            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        public  void ReadCallback(IAsyncResult ar)
        {
            content = String.Empty;
            String path=String.Empty;
            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            state2 = (StateObject)ar.AsyncState;
            Socket handler = state2.workSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.  
                state2.sb.Append(Encoding.ASCII.GetString(
                    state2.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read   
                // more data.  
                content = state2.sb.ToString();
                
                if (content.IndexOf("END") > -1)
                {
                    WriteStringtoFile(content);
                    
                    String ipadd = handler.RemoteEndPoint.ToString();
                    richTextBox1.Invoke(new Action(() => { richTextBox1.AppendText("\nReceived Data From: "+ ipadd); }));
                    // Echo the data back to the client.
                    content = "ACK\r\n";
                    Send(handler, content);
                }
                else
                {
                    // Not all data received. Get more.  
                    handler.BeginReceive(state2.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state2);

                }
            }
        }

        private  void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private  void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private  void WriteStringtoFile(String st)
        {
           
            String path = String.Empty;
            char[] charsToTrim = { '\r', '\n' };
            char[] charsToTrimPid = { ':' };
            String[] split = st.Split(charsToTrim);
            DateTime dateString=DateTime.Now;
            try
            {
                dateString = DateTime.Parse(split[1]);
            }catch(Exception)
            {
                Invoke(new Action(() =>
                {
                    toolStripStatus.Text = "Invalid Date received..";

                }));
                return;
            }
            
            int year = dateString.Year;
            int month = dateString.Month;
            int dayofmonth = dateString.Day;
            path += "RightBiotic\\";
            path += year.ToString() + "\\";
            path += months[month] + "\\";
            path += dayofmonth.ToString();
            path = linkLabelPath.Text.ToString() + "\\" + path;
            String[] pid = split[0].Split(charsToTrimPid);
            String filename = pid[1];
            filename += " " + dateString.Hour.ToString() + " " + dateString.Minute.ToString() + " " + dateString.Second.ToString();
            if (Directory.Exists(path))
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(path + "\\" + filename + ".txt", true))
                {
                    foreach (String sl in split)
                    {
                        file.WriteLine(sl);
                    }

                    file.Flush();
                    file.Close();
                }

            }
            else
            {
                Directory.CreateDirectory(path);
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(path + "\\" + filename + ".txt", true))
                {
                    foreach (String sl in split)
                    {
                        file.WriteLine(sl);
                    }
                    file.Flush();
                    file.Close();
                }
            }
            Invoke(new Action(() =>
            {
                toolStripStatus.Text = "Data received from PID: "+pid[1];

            }));
            return;
        }

        private void linkLabelPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime dt = DateTime.Now;

            int year = dt.Year;
            String path = Properties.Settings.Default.Path;
            path += "RightBiotic\\"+year.ToString();
            path += "\\"+months[dt.Month];
            try
            {
                Process.Start(path);
            }catch(Win32Exception )
            {
                path = Properties.Settings.Default.Path;
                Process.Start(path);
                //MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PatientDetails pd = new PatientDetails();
            pd.ShowDialog();
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
           
            linkLabelPath.Text = Properties.Settings.Default.Path;
            ipAddress = LocalIPAddress();
            richTextBox1.Clear();
            if (ipAddress == null)
            {
                richTextBox1.Text = "Please Check WiFi or Local Lan Connection..";
                return;
            }
            labelIPadd.Text = ipAddress.ToString();
            richTextBox1.Clear();
            richTextBox1.AppendText("Server is up and Listening on:" + labelIPadd.Text.ToString() + ":" + PortNo);
            buttonStartServer.Enabled = false;
            serverThread = new Thread(StartListening);
            serverThread.Start();            
        }
            
        private void buttonOpenCom_Click(object sender, EventArgs e)
        {
            if (buttonOpenCom.Text.Equals("Open Com Port"))
            {
                string Comportname;
                try
                {
                    Comportname = comboBoxComport.SelectedItem.ToString();
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Select A Valid Comm Port");
                    return;
                }
               
                SP1.BaudRate = 115200;
                SP1.PortName = Comportname;
                SP1.DataBits = 8;
                SP1.Parity = Parity.None;
                SP1.StopBits = StopBits.One;
                SP1.Handshake = Handshake.None;
                SP1.ReadTimeout = 3000;
                SP1.NewLine = "\r\n";
                try
                {
                    SP1.Open();
                }
                catch (Exception se)
                {
                    MessageBox.Show(se.Message.ToString());
                    return;
                }
                buttonOpenCom.Text = "Close Com Port";
                buttonOpenCom.BackColor = Color.HotPink;
                SP1.DataReceived += new SerialDataReceivedEventHandler(this.SP1_DataReceived);

                richTextBox1.Clear();
                richTextBox1.AppendText("Server is up and Listening Com Port:"+ Comportname+"\n");
            }
            else
            {
                SP1.DataReceived -= new SerialDataReceivedEventHandler(this.SP1_DataReceived);
                SP1.Dispose();
                SP1.Close();
                buttonOpenCom.Text = "Open Com Port";
                buttonOpenCom.BackColor = Color.LightGreen;
                richTextBox1.AppendText("Serial Port Server is Down...\n");
            }
        }       

        private void ReadData()
        {
            char[] split = { ' ' };
            String[] res;
            int count = 0, command = 0;
            String x = String.Empty;
            try
            {
                x = SP1.ReadLine();
            }
            catch (TimeoutException tout)
            {
                Debug.WriteLine(tout.ToString());
                Invoke(new Action(() =>
                {
                    toolStripStatus.Text = "Timeout Occured";

                }));
                return;
            }

            String qx = String.Empty;
            res = x.Split(split);
            try
            {
                count = int.Parse(res[1]);
                command = int.Parse(res[0]);
                SP1.WriteLine("A");
            }
            catch (Exception)
            {
                // To Do code here
                Invoke(new Action(() =>
                {
                    toolStripStatus.Text = "Invalid start protocol received";

                }));
                return;
            }
            if (command != 30)
            {
                Invoke(new Action(() =>
                {
                    toolStripStatus.Text = "Invalid command received";

                }));
                return;
            }
            Debug.WriteLine(x);
            SP1.WriteLine("A");
            String pid = String.Empty;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    if (i == 0)
                    {
                        pid = SP1.ReadLine();
                        qx = String.Copy(pid)+"\n";
                    }else
                    {
                        qx += SP1.ReadLine() + "\n";
                    }
                    
                }
                catch (TimeoutException tout)
                {
                    Debug.WriteLine(tout.ToString());
                    Invoke(new Action(() =>
                    {
                        toolStripStatus.Text = "Timeout occured during the receive string phase:";

                    }));
                    return;
                }

            }
                        
            Debug.WriteLine(qx);
            WriteStringtoFile(qx);
            Invoke(new Action(() =>
            {
                toolStripStatus.Text = "Data Received with "+pid;
                richTextBox1.AppendText("Data Received with " + pid+"\n");
            }));
            SP1.WriteLine("A");

        }

        private void SP1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int datacount = SP1.BytesToRead;
            if (datacount > 0)
            {
                ReadData();
            }
        }

        private void buttonEnumComport_Click(object sender, EventArgs e)
        {
            int con = 0;
            string[] portNames = SerialPort.GetPortNames();     //<-- Reads all available comPorts
            comboBoxComport.Items.Clear();
            comboBoxComport.BeginUpdate();
            foreach (var portName in portNames)
            {
                comboBoxComport.Items.Add(portName);                  //<-- Adds Ports to combobox
                con++;
            }
            comboBoxComport.EndUpdate();
        }

        
    }
}
