using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_2_прак_1
{
    public partial class Form1 : Form
    {
        int n = 0;
        decimal guess, true_guess, izm, pog;
        double d;
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ((!(Double.TryParse(textBox1.Text, out d))))
            {
                MessageBox.Show("Некорректный ввод данных!");
                return;
            }
            if(d < 0)
            {
                MessageBox.Show("Введите положительное число!");
                return;
            }
            textBox2.Text = Convert.ToString(Math.Sqrt(d));
            decimal Newton = Convert.ToDecimal(d);
            for(int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    true_guess = Newton / 2;
                }
                true_guess = ((Newton / true_guess) + true_guess) / 2;
            }
            if(n == 0)
            {
                guess = Newton / 2;
            }
            izm = guess - ((Newton / guess) + guess) / 2;
            guess = ((Newton / guess) + guess) / 2;
            pog = true_guess - guess;
            n++;
            textBox3.Text = Convert.ToString(guess);
            label5.Text = Convert.ToString(n);
            label8.Text = izm.ToString("E");
            label7.Text = pog.ToString("E");
        }
    }
}
