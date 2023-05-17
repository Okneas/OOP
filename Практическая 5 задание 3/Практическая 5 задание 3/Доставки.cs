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
    public partial class Доставки : Form
    {
        public Доставки()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void SetInfoAllComponents()
        {
            List<Component> alldel = new List<Component>();
            alldel = Form1.shop.GetAllDeliveries();
            foreach (Component i in alldel)
            {
                string info = "";
                switch (i.Type)
                {
                    case (ComponentType.Cooler):
                        Cooler cooler = i as Cooler;
                        info = $"Тип товара: Кулер\nНазвание: {cooler.Name} \nПроизводитель: {cooler.Manufacturer}\nСкорость винтов: {cooler.FanSpeed} \nРегион продажи: {cooler.region}\nЦена: {cooler.Price}\nВремя до прибытия доставки: {Math.Ceiling(cooler.dtDelivery.Hours / 24M)}д {cooler.dtDelivery.Hours % 24}:{cooler.dtDelivery.Minutes}:{cooler.dtDelivery.Seconds}";
                        break;
                    case (ComponentType.Motherboard):
                        Motherboard motherboard = i as Motherboard;
                        info = $"Тип товара: Материнская плата\nНазвание: {motherboard.Name} \nПроизводитель: {motherboard.Manufacturer}\nЧипсет: {motherboard.Chipset}\nКол-во RAM-слотов: {motherboard.RAMSlots} \nРегион продажи: {motherboard.region}\nЦена: {motherboard.Price}\nВремя до прибытия доставки: {Math.Ceiling(motherboard.dtDelivery.Hours / 24M)}д {motherboard.dtDelivery.Hours % 24}:{motherboard.dtDelivery.Minutes}:{motherboard.dtDelivery.Seconds}";
                        break;
                    case (ComponentType.VideoCard):
                        VideoCard videoCard = i as VideoCard;
                        info = $"Тип товара: Видеокарта\nНазвание: {videoCard.Name} \nПроизводитель: {videoCard.Manufacturer}\nЧастота: {videoCard.ClockSpeed}\nVRAM: {videoCard.VRAM} \nРегион продажи: {videoCard.region}\nЦена: {videoCard.Price}\nВремя до прибытия доставки: {Math.Ceiling(videoCard.dtDelivery.Hours/24M)}д {videoCard.dtDelivery.Hours % 24}:{videoCard.dtDelivery.Minutes}:{videoCard.dtDelivery.Seconds}";
                        break;
                    case (ComponentType.Processor):
                        Processor proc = i as Processor;
                        info = $"Тип товара: Процессор\nНазвание: {proc.Name} \nПроизводитель: {proc.Manufacturer}\nЧастота: {proc.ClockSpeed}\nЯдер: {proc.Cores} \nКол-во потоков: {proc.Threads} \nРегион продажи: {proc.region}\nЦена: {proc.Price}\nВремя до прибытия доставки: {Math.Ceiling(proc.dtDelivery.Hours / 24M)}д {proc.dtDelivery.Hours % 24}:{proc.dtDelivery.Minutes}:{proc.dtDelivery.Seconds}";
                        break;
                }
                richTextBox1.AppendText(info + Environment.NewLine);
            }
        }

        private void Доставки_Load(object sender, EventArgs e)
        {
            SetInfoAllComponents();
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            foreach(Component i in Form1.shop.AllDeliveries)
            {
                i.dtDelivery -= TimeSpan.FromSeconds(1);
                if(i.dtDelivery.TotalSeconds < 0)
                {
                    i.dl = DeliveryStatus.Delivered;
                }
            }
            SetInfoAllComponents();
        }
    }
}
