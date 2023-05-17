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
    public partial class Добавление_компонента : Form
    {
        public Добавление_компонента()
        {
            InitializeComponent();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox7.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox7.Enabled = false;
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox9.Enabled = true;
                textBox10.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox8.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox8.Enabled = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(textBox12.Text) > 100 || Convert.ToInt32(textBox12.Text) < 0)
            {
                MessageBox.Show("Неправильно введено значение скидки");
            }
            Strategy strategy = null;
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                strategy = new RegionPrice();
            }
            else if(!checkBox1.Checked && checkBox2.Checked){
                strategy = new DiscountPrice();
            }
            else if (checkBox1.Checked && checkBox2.Checked)
            {
                strategy = new MixedPrice();
            }
            else
            {
                strategy = new RegularPrice();
            }
            if (radioButton1.Checked)
            {
                VideoCard vid = new VideoCard(Convert.ToDecimal(textBox4.Text), Convert.ToInt32(textBox7.Text));
                vid.SetData(textBox1.Text, textBox2.Text, strategy.calculatePrice(comboBox1.Text, Convert.ToDecimal(textBox3.Text), Convert.ToInt32(textBox12.Text)), comboBox1.Text, Convert.ToDouble(textBox12.Text));
                Form1.shop.AddComponent(vid);
            }
            else if (radioButton2.Checked)
            {
                Cooler cool = new Cooler(Convert.ToDecimal(textBox8.Text)); 
                cool.SetData(textBox1.Text, textBox2.Text, strategy.calculatePrice(comboBox1.Text, Convert.ToDecimal(textBox3.Text), Convert.ToInt32(textBox12.Text)), comboBox1.Text, Convert.ToDouble(textBox12.Text));
                Form1.shop.AddComponent(cool);
            }
            else if (radioButton3.Checked)
            {
                Processor proc = new Processor(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToDecimal(textBox6.Text));
                proc.SetData(textBox1.Text, textBox2.Text, strategy.calculatePrice(comboBox1.Text, Convert.ToDecimal(textBox3.Text), Convert.ToInt32(textBox12.Text)), comboBox1.Text, Convert.ToDouble(textBox12.Text));
                Form1.shop.AddComponent(proc);
            }
            else if (radioButton4.Checked)
            {
                Motherboard mb = new Motherboard(textBox9.Text, Convert.ToInt32(textBox10.Text));
                mb.SetData(textBox1.Text, textBox2.Text, strategy.calculatePrice(comboBox1.Text, Convert.ToDecimal(textBox3.Text), Convert.ToInt32(textBox12.Text)), comboBox1.Text, Convert.ToDouble(textBox12.Text));
                Form1.shop.AddComponent(mb);
            }
            Close();
        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void Добавление_компонента_Load(object sender, EventArgs e)
        {
            
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox12.Enabled = true;
            }
            else
            {
                textBox12.Enabled = false;
            }
        }

        private void TextBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
