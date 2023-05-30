using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_5_задание_3
{
   
    public interface IShop
    {
        List<Product> AllComponents { get; set; }
        List<Product> AllDeliveries { get; set; }
        List<Computer> AllComputers { get; set; }
        List<Product> AllSolds { get; set; }
        string Name { get; set; }
        string Address { get; set; }

        void AddComponent(Product component);
        void CreateComputer(Computer comp);
        void SellComponent(ComponentType componentType, string name, DateTime DateOfDelivery);
        void SellComputer(string name);
        List<Product> GetAllComponents();
        List<Computer> GetAllComputers();
        List<Product> GetAllSoldComponents();
        List<Product> GetAllDeliveries();
        Product FindByName(string name, ComponentType type);
        List<Product> FindAllByType(ComponentType type);
    }
}
