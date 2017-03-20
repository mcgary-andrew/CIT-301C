using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab03
{
    public class Desk : Order
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