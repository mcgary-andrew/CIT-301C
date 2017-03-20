using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    interface IDesk
    {
        double CalculateArea(double width, double length);
        double CalculateShipping(int days, double area, double[] prices);
        double PriceForArea(double area);
        double CalculateTotalPrice(double area, double drawers, double wood, double shipping);
    }
}
