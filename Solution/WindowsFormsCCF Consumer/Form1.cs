using CallBackWcfService;
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
using WindowsFormsCCF_Consumer.CallBackWCFService;

namespace WindowsFormsCCF_Consumer
{
    public partial class Form1 : Form, IService1Callback
    {
    
        public Form1()
        {
            InitializeComponent();

           
            
        }

        public void progress(int i)
        {
            label1.Text = i + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            InstanceContext   instanceContext = new InstanceContext(this);
            CallBackWCFService.Service1Client proxy = new CallBackWCFService.Service1Client(instanceContext);


            int nbr = 0;
            if (!String.IsNullOrEmpty( textBox1.Text) && Int32.TryParse(textBox1.Text,out nbr))
            {
                button2.Enabled = false;

                proxy.Process(nbr);
                button2.Enabled = true;
            }
            
            


        }
    }

    
}
