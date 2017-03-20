namespace ConsoleApp
{
    //A list of the types of wood available
    public enum DeskType
    {
        Oak,
        Laminate,
        Pine,
        Plywood,
        Rosewood,
        Birch
    };

    //A structure that contains the type of wood and its price
    struct Wood
    {
        public DeskType woodType;
        public double price;
    };

    struct DeskStruct
    {
        public string customerName, surfaceType;
        public double widthDesk, lengthDesk, area, rushDays, numberOfDrawers, price, shipping, priceTotal;
    }

    class Desk : IDesk
    {
        public string customerName, surfaceType;
        public double widthDesk, lengthDesk, area, rushDays, numberOfDrawers, price, shipping, priceTotal;

        public double CalculateArea(double width, double length)
        {
            area = width * length;
            return area;
        }

        public double CalculateShipping(int days, double area, double[] prices)
        {
            //Shipping is calculated based on the number of days and the surface area of the desk
            double shipping = 0;
            if (area > 2000)
            {
                switch (days)
                {
                    case 3:
                        shipping = prices[2];
                        break;
                    case 5:
                        shipping = prices[5];
                        break;
                    case 7:
                        shipping = prices[8];
                        break;
                }
            }
            else if (area > 1000)
            {
                switch (days)
                {
                    case 3:
                        shipping = prices[1];
                        break;
                    case 5:
                        shipping = prices[4];
                        break;
                    case 7:
                        shipping = prices[7];
                        break;
                }
            }
            else
            {
                switch (days)
                {
                    case 3:
                        shipping = prices[0];
                        break;
                    case 5:
                        shipping = prices[3];
                        break;
                    case 7:
                        shipping = prices[6];
                        break;
                }
            }
            return shipping;
        }

        public double CalculateTotalPrice(double area, double drawers, double wood, double shipping)
        {
            double price = 0;
            price += this.PriceForArea(area);
            price += (drawers * 50);
            price += wood;
            price += shipping;
            return price;
        }

        public double PriceForArea(double area)
        {
            double price;
            if (area > 1000)
            {
                price = ((area - 1000) * 5) + 200;
            }
            else
            {
                price = 200;
            }
            return price;
        }

    }
}
