using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_3_прак_1
{
    public partial class Form1 : Form
    {
        ///<summary>
        ///Это StringBuilder он позволяет легко управлять элементами строки.
        ///</summary>
        StringBuilder sb = new StringBuilder();
        int d;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if ((!(Int32.TryParse(textBox1.Text, out d))))
            {
                MessageBox.Show("Некорректный ввод данных! Введите целочисленное значение");
                return;
            }
            if (d < 0)
            {
                MessageBox.Show("Введите положительное число!");
                return;
            }
            if(d == 0)
            {
                sb.Insert(0, "0");
            } 
            while (d > 0)
            {
                if (d % 2 == 0)
                {
                    sb.Insert(0, "0");
                }
                if (d % 2 != 0)
                {
                    sb.Insert(0, "1");
                }
                d = d / 2;
            }
            label1.Text = sb.ToString();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }
    }
}
