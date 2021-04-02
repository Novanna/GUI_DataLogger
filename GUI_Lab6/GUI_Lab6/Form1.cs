using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GUI_Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label9.Text = folderDlg.SelectedPath;

            comboBox2.Items.Add("9600");
            comboBox2.Items.Add("14400");
            comboBox2.Items.Add("19200");
            comboBox2.Items.Add("38400");
            comboBox2.Items.Add("56000");
            comboBox2.Items.Add("57600");
            comboBox2.Items.Add("76800");
            comboBox2.Items.Add("115200");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] portList = System.IO.Ports.SerialPort.GetPortNames();
            foreach (String portName in portList)
                comboBox1.Items.Add(portName);
            comboBox1.Text = comboBox1.Items[comboBox1.Items.Count - 1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Connect";
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = Int32.Parse(comboBox2.Text);
                serialPort1.NewLine = "\r\n";
                serialPort1.Open();
                toolStripStatusLabel1.Text = serialPort1.PortName + " is connected.";
                button1.Text = "Disconnect";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "ERROR: " + ex.Message.ToString();
                button1.Text = "Connect";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            toolStripStatusLabel1.Text = serialPort1.PortName + " is closed.";
        }
    

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            String receivedMsg = serialPort1.ReadLine();
            Tampilkan(receivedMsg);
        }

        private delegate void TampilkanDelegate(object item);
        private void Tampilkan(object item)
        {
            if (InvokeRequired)
                listBox1.Invoke(new TampilkanDelegate(Tampilkan), item);
            else
            {
                // This is the UI thread so perform the task.
                listBox1.Items.Add(item);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                splitData(item);
            }
        }

        private void splitData(object item)
        {
            String[] data = item.ToString().Split(',');
            textBox1.Text = data[1]; // textbox untuk data suhu
            textBox2.Text = data[2]; // textbox untuk data kelembaban
            textBox3.Text = data[3]; // textbox untuk data tekanan udara
            textBox4.Text = data[4]; // textbox untuk data uv index
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
                label9.Text = folderDlg.SelectedPath;
        }
        private FolderBrowserDialog folderDlg = new FolderBrowserDialog();

        private void button4_Click(object sender, EventArgs e)
        {
            //TextWriter txt = new StreamWriter(label9.Text + "dataTRUE.txt", true);
            TextWriter txt = new StreamWriter(label9.Text + "dataLAB62.txt");
            txt.WriteLine(listBox1.Text);
            txt.Close();
        }

   }
}

