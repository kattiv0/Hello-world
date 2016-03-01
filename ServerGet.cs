using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ServerGet
{
    public partial class Form1 : Form
    {
        string path = "";
        string dest = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"\\" + cmbServer.SelectedItem + @"\Public";
            ofd.ShowDialog();
            path = ofd.InitialDirectory;
            txtSourceDir.Text = path;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] Server = new string[3];

            Server[0] = "10.132.0.64";
            Server[1] = "10.127.0.16";
            Server[2] = "10.244.0.64";

            foreach (string r in Server)
            {
                cmbServer.Items.Add(r);
            }
        }

        private void btnDestPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            dest = folderBrowserDialog1.SelectedPath.ToString();
            textBox1.Text = dest;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGet_Click_1(object sender, EventArgs e)
        {
            foreach (string dirPath in Directory.GetDirectories(path, "*", SearchOption.AllDirectories))Directory.CreateDirectory(dirPath.Replace(path, dest));
            foreach (string newPath in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))File.Copy(newPath, newPath.Replace(path, dest), true);
        }
    }
}
