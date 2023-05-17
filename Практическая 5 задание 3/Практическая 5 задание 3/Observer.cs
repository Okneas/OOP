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
            List<Component> list = Form1.shop.GetAllComponents();
            foreach (Component i in list)
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
        }
        public void Delete(Component comp)
        {
            Form1.shop.AllComponents.Remove(comp);
            Form1.shop.AllDeliveries.Remove(comp);
        }
    }
}
