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
    public partial class Создание_компьютера : Form
    {
        public Создание_компьютера()
        {
            InitializeComponent();
        }

        private void Создание_компьютера_Load(object sender, EventArgs e)
        {
            List<Product> allVideocards = Form1.shop.FindAllByType(ComponentType.VideoCard);
            List<Product> allMotherboards = Form1.shop.FindAllByType(ComponentType.Motherboard);
            List<Product> allCoolers = Form1.shop.FindAllByType(ComponentType.Cooler);
            List<Product> allProcessors = Form1.shop.FindAllByType(ComponentType.Processor);
            foreach(Product i in allVideocards)
            {
                comboBox1.Items.Add(i.Name);
            }
            foreach (Product i in allProcessors)
            {
                comboBox2.Items.Add(i.Name);
            }
            foreach (Product i in allCoolers)
            {
                comboBox3.Items.Add(i.Name);
            }
            foreach (Product i in allMotherboards)
            {
                comboBox4.Items.Add(i.Name);
            }
        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Computer comp;
            if (Convert.ToInt32(textBox1.Text) > 100 || Convert.ToInt32(textBox1.Text) < 0)
            {
                MessageBox.Show("Неправильно введено значение скидки");
            }
            Strategy strategy = null;
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                strategy = new RegionPrice();
            }
            else if (!checkBox1.Checked && checkBox2.Checked)
            {
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
            Product videcard = Form1.shop.FindByName(comboBox1.Text, ComponentType.VideoCard);
            Product processor = Form1.shop.FindByName(comboBox2.Text, ComponentType.Processor);
            Product cooler = Form1.shop.FindByName(comboBox3.Text, ComponentType.Cooler);
            Product motherboard = Form1.shop.FindByName(comboBox4.Text, ComponentType.Motherboard);

            comp = new Computer(processor as Processor, videcard as VideoCard, cooler as Cooler, motherboard as Motherboard);
            comp.SetData(textBox2.Text, "", strategy.calculatePrice(comboBox6.Text, processor.Price+videcard.Price+cooler.Price+motherboard.Price, Convert.ToInt32(textBox1.Text)), comboBox6.Text, Convert.ToInt32(textBox1.Text));
            Form1.shop.CreateComputer(comp);
            Form1.shop.AllComponents.Remove(videcard);
            Form1.shop.AllComponents.Remove(processor);
            Form1.shop.AllComponents.Remove(cooler);
            Form1.shop.AllComponents.Remove(motherboard);
            Close();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox6.Enabled = true;
            }
            else
            {
                comboBox6.Enabled = true;
            }
        }
    }
}
