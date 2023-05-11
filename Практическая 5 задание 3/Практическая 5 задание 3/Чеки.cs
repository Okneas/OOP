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
    public partial class Чеки : Form
    {
        public Чеки()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Чеки_Load(object sender, EventArgs e)
        {
            List<string> info = Form1.shop.GetAllChecks();
            foreach(string i in info)
            {
                richTextBox1.AppendText(i + Environment.NewLine);
            }
        }
    }
}
