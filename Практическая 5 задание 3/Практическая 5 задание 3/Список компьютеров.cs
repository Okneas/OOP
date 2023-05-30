using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практическая_5_задание_3
{
    public partial class Список_компьютеров : Form
    {
        public Список_компьютеров()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Список_компьютеров_Load(object sender, EventArgs e)
        {
            foreach(Computer i in Form1.shop.GetAllComputers())
            {
                richTextBox1.AppendText(i.GetInfoString() + Environment.NewLine);
            }
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            foreach (Computer i in Form1.shop.GetAllComputers())
            {
                richTextBox1.AppendText(i.GetInfoString() + Environment.NewLine);
            }
        }
    }
}
