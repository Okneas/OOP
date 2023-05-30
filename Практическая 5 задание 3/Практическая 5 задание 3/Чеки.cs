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
            SetAllChecks();
            timer1.Start();
        }

        public void SetAllChecks()
        {
            List<Product> list = Form1.shop.GetAllSoldComponents();
            foreach (Product i in list)
            {
                string info = "";
                switch (i.Type)
                {
                    case (ComponentType.Cooler):
                        Cooler cooler = i as Cooler;
                        info = $"Тип товара: Кулер\nНазвание: {cooler.Name} \nПроизводитель: {cooler.Manufacturer}\nСкорость винтов: {cooler.FanSpeed} \nРегион продажи: {cooler.region}\nЦена: {cooler.Price}\nСтатус:{cooler.GetDeliveryStatusString()}";
                        break;
                    case (ComponentType.Motherboard):
                        Motherboard motherboard = i as Motherboard;
                        info = $"Тип товара: Материнская плата\nНазвание: {motherboard.Name} \nПроизводитель: {motherboard.Manufacturer}\nЧипсет: {motherboard.Chipset}\nКол-во RAM-слотов: {motherboard.RAMSlots} \nРегион продажи: {motherboard.region}\nЦена: {motherboard.Price}\nСтатус:{motherboard.GetDeliveryStatusString()}";
                        break;
                    case (ComponentType.VideoCard):
                        VideoCard videoCard = i as VideoCard;
                        info = $"Тип товара: Видеокарта\nНазвание: {videoCard.Name} \nПроизводитель: {videoCard.Manufacturer}\nЧастота: {videoCard.ClockSpeed}\nVRAM: {videoCard.VRAM} \nРегион продажи: {videoCard.region}\nЦена: {videoCard.Price}\nСтатус:{videoCard.GetDeliveryStatusString()}";
                        break;
                    case (ComponentType.Processor):
                        Processor proc = i as Processor;
                        info = $"Тип товара: Процессор\nНазвание: {proc.Name} \nПроизводитель: {proc.Manufacturer}\nЧастота: {proc.ClockSpeed}\nЯдер: {proc.Cores} \nКол-во потоков: {proc.Threads} \nРегион продажи: {proc.region}\nЦена: {proc.Price}\nСтатус:{proc.GetDeliveryStatusString()}";
                        break;
                    case (ComponentType.Computer):
                        Computer comp = i as Computer;
                        info = comp.GetInfoString();
                        break;
                }
                richTextBox1.AppendText(info + Environment.NewLine);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            SetAllChecks();
        }
    }
}
