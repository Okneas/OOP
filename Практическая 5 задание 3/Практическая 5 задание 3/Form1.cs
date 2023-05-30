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
        Продажа_компьютера f9;
        Список_компьютеров f8;
        Создание_компьютера f7;
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

        private void DisplayLastSale(Product component)
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

        private void Button2_Click(object sender, EventArgs e)
        {
            f7 = new Создание_компьютера();
            f7.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            f8 = new Список_компьютеров();
            f8.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {

            f9 = new Продажа_компьютера();
            f9.Show();
        }
    }

    public class Processor : Product, IProcessor
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

    public class VideoCard : Product, IVideoCard
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

    public class Cooler : Product, ICooler
    {
        public decimal FanSpeed { get; set; }
        public Cooler(decimal FS)
        {
            Type = ComponentType.Cooler;
            FanSpeed = FS;
        }
    }

    public class Motherboard : Product, IMotherboard
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
    public class Computer : Product,  IComputer
    {
        public Processor Processor { get; set; }
        public VideoCard VideoCard { get; set; }
        public Cooler Cooler { get; set; }
        public Motherboard Motherboard { get; set; }
        public Computer( Processor processor, VideoCard videoCard, Cooler cooler, Motherboard motherboard)
        {
            Type = ComponentType.Computer;
            Processor = processor;
            VideoCard = videoCard;
            Cooler = cooler;
            Motherboard = motherboard;
        }
        public string GetAllComponentsName()
        {
            return $"Материнская плата: {this.Motherboard.Name}\nВидеокарта: {this.VideoCard.Name}\nПроцессор: {this.Processor.Name}\nКулер: {this.Cooler.Name}\n";
        }
        public string GetInfoString()
        {
            return $"Название: {Name}\nЦена: {Price}\n{this.GetAllComponentsName()}Регион продажи: {this.region}\nСтатус: {this.GetDeliveryStatusString()}\n";
        }
    }
    public class ComponentEventArgs : EventArgs
    {
        public readonly Product Product;

        public ComponentEventArgs(Product product)
        {
            Product = product;
        }
    }
    public class Shop : IShop
    {
        public event EventHandler<ComponentEventArgs> ComponentSold;
        public Shop(string name, string address)
        {
            AllDeliveries = new List<Product>();
            AllComponents = new List<Product>();
            AllComputers = new List<Computer>();
            AllSolds = new List<Product>();
            Name = name;
            Address = address;
        }
        public List<Product> AllComponents { get; set; }
        public List<Product> AllDeliveries { get; set; }
        public List<Computer> AllComputers { get; set; }
        public List<Product> AllSolds { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public void AddComponent(Product component)
        {
            AllComponents.Add(component);
        }
        public void CreateComputer(Computer comp)
        {
            AllComputers.Add(comp);
        }
        protected virtual void OnProductSold(ComponentEventArgs e)
        {
            ComponentSold?.Invoke(this, e);
        }
        public void SellComponent(ComponentType componentType, string name, DateTime DateOfDelivery)
        {
            bool find = false;
            if (componentType == ComponentType.Computer)
            {
                foreach (Computer i in AllComputers)
                {
                    if (i.Name == name)
                    {
                        find = true;
                        DateTime dt = DateTime.Now;
                        OnProductSold(new ComponentEventArgs(i));
                        i.SetDateOfDelivery(DateOfDelivery - dt);
                        i.dl = DeliveryStatus.InTransit;
                        AllSolds.Add(i);
                        AllDeliveries.Add(i);
                        break;
                    }
                }
            }
            else
            {
                foreach (Product i in AllComponents)
                {
                    if (i.Name == name && i.Type == componentType)
                    {
                        find = true;
                        DateTime dt = DateTime.Now;
                        OnProductSold(new ComponentEventArgs(i));
                        i.SetDateOfDelivery(DateOfDelivery - dt);
                        i.dl = DeliveryStatus.InTransit;
                        AllSolds.Add(i);
                        AllDeliveries.Add(i);
                        break;
                    }
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
                    //AllChecks.Append($"Продано {dt.Date} в {dt.Hour}:{dt.Minute} \nТип товара: Компьютер \nНазвание: {i.Name} \nПроцессор: {i.Processor.Name} \nВидеокарта: {i.VideoCard.Name} \nКулер: {i.Cooler.Name} \nМатеринская плата: {i.Motherboard.Name} \nЦена: {i.Price} \n");
                    break;
                }
            }
        }
        public List<Product> GetAllComponents()
        {
            return AllComponents;
        }
        public List<Computer> GetAllComputers()
        {
            return AllComputers;
        }
        public List<Product> GetAllSoldComponents()
        {
            return AllSolds;
        }
        public List<Product> GetAllDeliveries()
        {
            return AllDeliveries;
        }
        public Product FindByName(string name, ComponentType type)
        {
            foreach(Product i in Form1.shop.GetAllComponents())
            {
                if(i.Name == name && i.Type == type)
                {
                    return i;
                }
            }
            return null;
        }

        public List<Product> FindAllByType(ComponentType type)
        {
            List<Product> allByType = new List<Product>();
            foreach(Product i in Form1.shop.GetAllComponents())
            {
                if(i.Type == type)
                {
                    allByType.Add(i);
                }
            }
            return allByType;
        }
    }
}
