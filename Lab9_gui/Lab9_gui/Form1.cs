using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.IO;

namespace Lab9_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = folderDlg.SelectedPath;
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
                label1.Text = folderDlg.SelectedPath;
        }

        private FolderBrowserDialog folderDlg = new FolderBrowserDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            TextWriter txt = new StreamWriter(label1.Text + "data.txt", true);
            //TextWriter txt = new StreamWriter(label1.Text + "data.txt");
            txt.WriteLine(textBox1.Text);
            txt.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
