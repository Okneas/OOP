using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_5_задание_3
{
    public abstract class Strategy
    {
        public abstract decimal calculatePrice(string region, decimal price, int discount);
    }
    public class RegularPrice : Strategy
    {
        public override decimal calculatePrice(string region, decimal price, int discount)
        {
            return price;
        }
    }
    public class RegionPrice : Strategy
    {
        public override decimal calculatePrice(string region, decimal price, int discount)
        {
            switch(region){
                case "North America":
                    return price * 2;
                case "Europe":
                    return price * 1.5M;
                case "Asia":
                    return price * 1.1M;
                case "South America":
                    return price * 1.3M;
                case "Australia":
                    return price * 1.4M;
                default:
                    return price;
            }
        }
    }
    public class DiscountPrice : Strategy
    {
        public override decimal calculatePrice(string region, decimal price, int discount)
        {
            return price * (1M-discount/100M);
        }
    }
    public class MixedPrice : Strategy
    {

        public override decimal calculatePrice(string region, decimal price, int discount)
        {
            switch (region)
            {
                case "North America":
                    price *= 2;
                    break;
                case "Europe":
                    price *= 1.5M;
                    break;
                case "Asia":
                    price *= 1.1M;
                    break;
                case "South America":
                    price *= 1.3M;
                    break;
                case "Australia":
                    price *= 1.4M;
                    break;
            }
            return price * (1M - discount / 100M);
        }
    }
    }
