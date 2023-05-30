using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_5_задание_3
{
    class Observer
    {
        public void UpdateDeliveries()
        {
            List<Product> list = Form1.shop.GetAllComponents();
            List<Computer> list2 = Form1.shop.GetAllComputers();
            foreach (Product i in list)
            {
                if (!Form1.shop.AllDeliveries.Contains(i) && i.dl == DeliveryStatus.InTransit)
                {
                    Form1.shop.AllDeliveries.Append(i);
                    break;
                }
                if(i.dl == DeliveryStatus.Delivered)
                {
                    Delete(i);
                    break;
                }
            }
            foreach (Computer i in list2)
            {
                if (!Form1.shop.AllDeliveries.Contains(i) && i.dl == DeliveryStatus.InTransit)
                {
                    Form1.shop.AllDeliveries.Append(i);
                    break;
                }
                if (i.dl == DeliveryStatus.Delivered)
                {
                    Delete(i);
                    break;
                }
            }
        }
        public void Delete(Product comp)
        {
            Form1.shop.AllComponents.Remove(comp);
            Form1.shop.AllDeliveries.Remove(comp);
            if(comp.Type == ComponentType.Computer)
            {
                Form1.shop.AllComputers.Remove(comp as Computer);
            }
        }
    }
}
