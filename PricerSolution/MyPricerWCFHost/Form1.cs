using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPricerWCFHost
{
    public partial class Form1 : Form
    {
        private ServiceHost host;
        public Form1()
        {
            InitializeComponent();
            host = new ServiceHost(typeof(MyPricerWCFLibrary.MyPricerService));

            host.Open();
            OpenBtn.Enabled = false;
            CloseBtn.Enabled = true;

            label1.Text = " Service Started @ " + DateTime.Now;
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            host =new ServiceHost(typeof(MyPricerWCFLibrary.MyPricerService));
            
                host.Open();
                   OpenBtn.Enabled = false;
            CloseBtn.Enabled = true;

            label1.Text = " Service Started @ " + DateTime.Now;
               
            
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {

            host.Close();
            OpenBtn.Enabled = true;

            CloseBtn.Enabled = false;

            label1.Text = " Service Stopped @ " + DateTime.Now;

            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            host.Close();
            OpenBtn.Enabled = true;

            CloseBtn.Enabled = false;

            label1.Text = " Service Stopped @ " + DateTime.Now;
        }
    }
}
