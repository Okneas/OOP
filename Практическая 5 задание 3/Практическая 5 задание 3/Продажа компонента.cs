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
    public partial class Продажа_компонента : Form
    {
        public Продажа_компонента()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ComponentType type = new ComponentType();
            if (radioButton1.Checked)
            {
                type = ComponentType.VideoCard;
            }
            else if (radioButton2.Checked)
            {
                type = ComponentType.Processor;
            }
            else if (radioButton3.Checked)
            {
                type = ComponentType.Motherboard;
            }
            else if (radioButton4.Checked)
            {
                type = ComponentType.Cooler;
            }
            Form1.shop.SellComponent(type, textBox1.Text, dateTimePicker1.Value);
            Close();
        }

        private void Продажа_компонента_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
        }
    }
}
