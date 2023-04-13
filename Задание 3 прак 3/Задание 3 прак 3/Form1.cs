using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_3_прак_3
{
    public partial class Form1 : Form
    {
        int a = 2147483647;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                checked
                {
                    a *= 2;
                }
            }
            catch(OverflowException ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
    }
}
