using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Arduino
{
    public partial class Form1 : Form
    {

        SerialPort serialPort;
      
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();

            serialPort = new SerialPort("COM3", 9600);
            serialPort.Open();
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            bool haveSense = false;
            string puerto = string.Empty;
            double temp;
            double hum;
            double humtierra;

            while (!haveSense)
            {
                puerto = serialPort.ReadLine();
                if (!string.IsNullOrEmpty(puerto))
                {
                    haveSense = true;
                }
            }


            if (haveSense)
            {
                //temp = temperature.Substring(1, 5);
                //hum = temperature.Substring(7, 11);
                string[] valores = puerto.Split(',');
                temp = (Convert.ToDouble(valores[0])/100); 
                hum = (Convert.ToDouble(valores[1])/100);
                humtierra =(Convert.ToDouble(valores[2])/1);
                //int tem = Convert.ToInt32(values[0]);
                //humtierra = temperature.Substring(13, 14);
                //textBox1.Text += Convert.ToString(tem);
                textBox1.Text += "Temperature is: " + temp + " and humedity is: " + hum + "% and ground humedity is: " + humtierra + "                                           ";
            }

        }
        

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
