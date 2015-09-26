using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WgetHere
{
    public partial class MainForm : Form
    {
        // Where the application is called FROM
        string _currentExecutingDirectory;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _currentExecutingDirectory = Directory.GetCurrentDirectory();
        }

        private void urlTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string url = urlTextBox.Text.Trim().Replace("\"", "");
                    string filenameFromURL = url.Substring(url.LastIndexOf('/') + 1);

                    string destinationFilename = Path.Combine(_currentExecutingDirectory, filenameFromURL);

                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(url, destinationFilename);

                    Application.Exit();
                    break;

                case Keys.Escape:
                    Application.Exit();
                    break;

                default:
                    break;
            }
        }

    }
}
