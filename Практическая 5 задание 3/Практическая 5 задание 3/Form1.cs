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
    public partial class Form1 : Form
    {
        Доставки f6;
        Добавление_компонента f2;
        Информация_об_компонентах f3;
        Продажа_компонента f4;
        Чеки f5;
        Observer observer = new Observer();
        public static Shop shop = new Shop("MyShop", "MyAddress");
        public Form1()
        {
            InitializeComponent();
            label1.Text = $"Добро пожаловать в {shop.Name}\nпо адресу {shop.Address}";
            shop.ComponentSold += Shop_ProductSold;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            f2 = new Добавление_компонента();
            f2.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            f3 = new Информация_об_компонентах();
            f3.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            f4 = new Продажа_компонента();
            f4.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            f5 = new Чеки();
            f5.Show();
        }
        private void Shop_ProductSold(object sender, ComponentEventArgs e)
        {
            // выполняем действия в ответ на событие
            DisplayLastSale(e.Product);
        }

        private void DisplayLastSale(Component component)
        {
            // обновляем метку на форме с информацией о последней продаже
            string saleMessage = $"Продан компонент: {component.Name}\nТип:{component.GetTypeString()}\nцена: {component.Price}";
            label4.Text = saleMessage;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            f6 = new Доставки();
            f6.Show();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            observer.UpdateDeliveries();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }

    public class Processor : Component, IProcessor
    {
        public int Cores { get; set; }
        public int Threads { get; set; }
        public decimal ClockSpeed { get; set; }

        public Processor(int cores, int theads, decimal CS)
        {
            Cores = cores;
            Threads = theads;
            ClockSpeed = CS;
            Type = ComponentType.Processor;
        }
    }

    public class VideoCard : Component, IVideoCard
    {
        public int VRAM { get; set; }
        public decimal ClockSpeed { get; set; }
        public VideoCard(decimal CS, int vram)
        {
            ClockSpeed = CS;
            VRAM = vram;
            Type = ComponentType.VideoCard;
        }
    }

    public class Cooler : Component, ICooler
    {
        public decimal FanSpeed { get; set; }
        public Cooler(decimal FS)
        {
            Type = ComponentType.Cooler;
            FanSpeed = FS;
        }
    }

    public class Motherboard : Component, IMotherboard
    {
        public string Chipset { get; set; }
        public int RAMSlots { get; set; }
        public Motherboard(string chip, int RAMS)
        {
            Type = ComponentType.Motherboard;
            Chipset = chip;
            RAMSlots = RAMS;
        }
    }
    public class Computer : IComputer
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Processor Processor { get; set; }
        public VideoCard VideoCard { get; set; }
        public Cooler Cooler { get; set; }
        public Motherboard Motherboard { get; set; }
        public Computer(string name, Processor processor, VideoCard videoCard, Cooler cooler, Motherboard motherboard)
        {
            Name = name;
            Processor = processor;
            VideoCard = videoCard;
            Cooler = cooler;
            Motherboard = motherboard;

            Price = Processor.Price + VideoCard.Price + Cooler.Price + Motherboard.Price;
        }
    }
    public class ComponentEventArgs : EventArgs
    {
        public readonly Component Product;

        public ComponentEventArgs(Component product)
        {
            Product = product;
        }
    }
    public class Shop : IShop
    {
        public event EventHandler<ComponentEventArgs> ComponentSold;
        public Shop(string name, string address)
        {
            AllDeliveries = new List<Component>();
            AllComponents = new List<Component>();
            AllComputers = new List<Computer>();
            AllChecks = new List<string>();
            Name = name;
            Address = address;
        }
        public List<Component> AllComponents { get; set; }
        public List<Component> AllDeliveries { get; set; }
        public List<Computer> AllComputers { get; set; }
        public List<string> AllChecks { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public void AddComponent(Component component)
        {
            AllComponents.Add(component);
        }
        public void CreateComputer(string name, Processor processor, VideoCard videoCard, Cooler cooler, Motherboard motherboard)
        {
            Computer comp = new Computer(name, processor, videoCard, cooler, motherboard);
            AllComputers.Add(comp);
        }
        protected virtual void OnProductSold(ComponentEventArgs e)
        {
            ComponentSold?.Invoke(this, e);
        }
        public void SellComponent(ComponentType componentType, string name, DateTime DateOfDelivery)
        {
            bool find = false;
            foreach(Component i in AllComponents)
            {
                if(i.Name == name && i.Type == componentType)
                {
                    find = true;
                    DateTime dt = DateTime.Now;
                    switch (i.Type)
                    {
                        case (ComponentType.Cooler):
                            Cooler cooler = i as Cooler;
                            AllChecks.Add($"Продано {dt}\nТип товара: Кулер\nНазвание: {cooler.Name} \nПроизводитель: {cooler.Manufacturer}\nСкорость винтов: {cooler.FanSpeed}\nРегион продажи: {cooler.region}\nЦена: {cooler.Price}\nСтатус: {cooler.GetDeliveryStatusString()}");
                            break;
                        case (ComponentType.Motherboard):
                            Motherboard motherboard = i as Motherboard;
                            AllChecks.Add($"Продано {dt}\nТип товара: Кулер\nНазвание: {motherboard.Name} \nПроизводитель: {motherboard.Manufacturer}\nЧипсет: {motherboard.Chipset}\nКол-во RAM-слотов: {motherboard.RAMSlots} \nРегион продажи: {motherboard.region}\nЦена: {motherboard.Price}\nСтатус: {motherboard.GetDeliveryStatusString()}");
                            break;
                        case (ComponentType.VideoCard):
                            VideoCard videoCard = i as VideoCard;
                            AllChecks.Add($"Продано {dt}\nТип товара: Кулер\nНазвание: {videoCard.Name} \nПроизводитель: {videoCard.Manufacturer}\nЧастота: {videoCard.ClockSpeed}\nVRAM: {videoCard.VRAM} \nРегион продажи: {videoCard.region}\nЦена: {videoCard.Price}\nСтатус: {videoCard.GetDeliveryStatusString()}");
                            break;
                        case (ComponentType.Processor):
                            Processor proc = i as Processor;
                            AllChecks.Add($"Продано {dt} \nТип товара: Кулер\nНазвание: {proc.Name} \nПроизводитель: {proc.Manufacturer}\nЧастота: {proc.ClockSpeed}\nЯдер: {proc.Cores} \nКол-во потоков: {proc.Threads} \nРегион продажи: {proc.region}\nЦена: {proc.Price}\nСтатус: {proc.GetDeliveryStatusString()}");
                            break;
                    }
                    OnProductSold(new ComponentEventArgs(i));
                    i.SetDateOfDelivery(DateOfDelivery - dt);
                    i.dl = DeliveryStatus.InTransit;
                    AllDeliveries.Add(i);
                    break;
                }
            }
            if (!find)
            {
                MessageBox.Show("Компонент не найден");
            }
        }
        public void SellComputer(string name)
        {
            foreach(Computer i in AllComputers)
            {
                if(i.Name == name)
                {
                    DateTime dt = new DateTime();
                    AllChecks.Append($"Продано {dt.Date} в {dt.Hour}:{dt.Minute} \nТип товара: Компьютер \nНазвание: {i.Name} \nПроцессор: {i.Processor.Name} \nВидеокарта: {i.VideoCard.Name} \nКулер: {i.Cooler.Name} \nМатеринская плата: {i.Motherboard.Name} \nЦена: {i.Price} \n");
                    break;
                }
            }
        }
        public List<Component> GetAllComponents()
        {
            return AllComponents;
        }
        public List<Computer> GetAllComputers()
        {
            return AllComputers;
        }
        public List<string> GetAllChecks()
        {
            return AllChecks;
        }
        public List<Component> GetAllDeliveries()
        {
            return AllDeliveries;
        }
    }
}
