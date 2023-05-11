using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_5_задание_3
{
    public enum ComponentType
    {
        Processor,
        VideoCard,
        Cooler,
        Motherboard
    }
    public abstract class Component
    {
        public string Name;
        public string Manufacturer;
        public decimal Price;
        public ComponentType Type;

        public void SetNameManPrice(string name, string man, decimal price)
        {
            this.Name = name;
            this.Manufacturer = man;
            this.Price = price;
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
            }
            return "";
        }
    }
}
