using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    class Program
    {
            static int readValue(
            string prompt, // prompt for the user
            int size // size
            )
            {
                int result = 0;
                do
                {
                    Console.WriteLine(prompt +
                    size);
                    string resultString = Console.ReadLine();
                    result = int.Parse(resultString);
                } while (result == 0);
                return result;
            }

        static void Main(string[] args)
        {

            Desk myNewDesk = new Lab03.Desk();
            int deskWidth = readValue("Enter width of desk: ", 0);
            Console.WriteLine("Width: " + deskWidth);
            int deskLength = readValue("Enter length of desk: ", 0);
            Console.WriteLine("Length: " + deskLength);
            string[] SurfaceMaterial = new string[2];
            SurfaceMaterial[0] = "Oak";
            SurfaceMaterial[1] = "Laminate";
            SurfaceMaterial[2] = "Pine";
            Console.WriteLine("Select Surface Material: ");
            int numOfDrawers = readValue("Enter Number of Drawers: ", 0);
            Console.WriteLine("Number of Drawers: ", 0);
            

        }
    }

    public class Desk
    {
        int Length;
        int NumOfDrawers;

        int Width;
        int Cost;
        int SurfaceMaterialId;

        public void createDesk()
        { }
        private int getDeskSizePrice()
        {
            int DeskSize = Width * Length;
            int DeskSizePrice = 200;
            int DeskOver;

            if (DeskSize > 1000)
            {
                DeskOver = DeskSize - 1000;
                DeskSizePrice += (DeskOver * 5);
            }
            return DeskSizePrice;
        }

        private int getDrawerCountPrice()
        {
            int NumDrawerPrice = NumOfDrawers * 50;
            return NumDrawerPrice;
        }

        private int getMaterialPrice()
        {
            string[] SurfaceMaterial = new string[3];
            SurfaceMaterial[1] = "Oak";
            SurfaceMaterial[2] = "Laminate";
            SurfaceMaterial[3] = "Pine";
            if (SurfaceMaterial[1] == "Oak")
            {
                SurfaceMaterialId = 200;
            }
            else if (SurfaceMaterial[2] == "Laminate")
            {
                SurfaceMaterialId = 100;
            }
            else if (SurfaceMaterial[3] == "Pine")
            {
                SurfaceMaterialId = 50;
            };

            return SurfaceMaterialId;

        }
        public int getTotalPrice()
        {
            int TotalPrice;
            TotalPrice = getDeskSizePrice() + getDrawerCountPrice() + getMaterialPrice();
            return TotalPrice;
        }
    }
}
