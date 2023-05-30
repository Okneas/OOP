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
    public partial class Продажа_компьютера : Form
    {
        public Продажа_компьютера()
        {
            InitializeComponent();
        }

        private void Продажа_компьютера_Load(object sender, EventArgs e)
        {
            foreach(Computer i in Form1.shop.GetAllComputers())
            {
                comboBox1.Items.Add(i.Name);
            }
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1.shop.SellComponent(ComponentType.Computer, comboBox1.Text, dateTimePicker1.Value);
            Close();
        }
    }
}
