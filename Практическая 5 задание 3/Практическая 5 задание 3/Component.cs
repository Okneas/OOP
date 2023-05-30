using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_5_задание_3
{
    public enum DeliveryStatus
    {
        OnStorage,
        InTransit,
        Delivered
    }
    public enum ComponentType
    {
        Processor,
        VideoCard,
        Cooler,
        Motherboard,
        Computer
    }
    public abstract class Product
    {
        public TimeSpan dtDelivery; 
        public DeliveryStatus dl = DeliveryStatus.OnStorage;
        public string Name;
        public string Manufacturer;
        public decimal Price;
        public ComponentType Type;
        public string region;
        public double discount;

        public void SetData(string name, string man, decimal price, string reg, double dis)
        {
            if(reg == "")
            {
                this.region = "Russia";
            }
            else
            {
                this.region = reg;
            }
            this.discount = dis;
            this.Name = name;
            this.Price = price;
            this.Manufacturer = man;
        }
        public void SetDateOfDelivery(TimeSpan dt)
        {
            this.dtDelivery = dt;
        }
        public string GetTypeString()
        {
            switch (Type)
            {
                case (ComponentType.Cooler):
                    return "Cooler";
                case (ComponentType.Motherboard):
                    return "Motherboard";
                case (ComponentType.Processor):
                    return "Processor";
                case (ComponentType.VideoCard):
                    return "VideoCard";
                case (ComponentType.Computer):
                    return "Computer";
            }
            return "";
        }
        public string GetDeliveryStatusString()
        {
            switch (dl)
            {
                case (DeliveryStatus.OnStorage):
                    return "На складе";
                case (DeliveryStatus.InTransit):
                    return "В пути";
                case (DeliveryStatus.Delivered):
                    return "Доставлено";
            }
            return "";
        }
    }
}
