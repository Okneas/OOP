using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_5_задание_3
{
   
    public interface IShop
    {
        List<Component> AllComponents { get; set; }
        List<Component> AllDeliveries { get; set; }
        List<Computer> AllComputers { get; set; }
        List<string> AllChecks { get; set; }
        string Name { get; set; }
        string Address { get; set; }

        void AddComponent(Component component);
        void CreateComputer(string name, Processor processor, VideoCard videoCard, Cooler cooler, Motherboard motherboard);
        void SellComponent(ComponentType componentType, string name, DateTime DateOfDelivery);
        void SellComputer(string name);
        List<Component> GetAllComponents();
        List<Computer> GetAllComputers();
        List<string> GetAllChecks();
        List<Component> GetAllDeliveries();
    }
}
