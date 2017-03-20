using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        //Constants that are the min and max measurements for the desk size
        const double MAXWIDTH = 48;
        const double MINWIDTH = 24;
        const double MAXLENGTH = 48;
        const double MINLENGTH = 24;

        //Get number input from user between two numbers
        static double getNumber(double low, double high, string prompt = "")
        {
            double result = 0;
            string resultString;
            do
            {
                Console.WriteLine(prompt + low + " and " + high);
                resultString = Console.ReadLine();
                try
                {
                    result = double.Parse(resultString);
                    if(result < low)
                    {
                        Console.WriteLine("Number is too low");
                    }
                    else if(result > high)
                    {
                        Console.WriteLine("Number is too high");
                    }

                }
                catch(Exception e)
                {
                    //Exception is caught and a message is sent telling the user to only user numbers
                    Console.WriteLine("Please only enter numbers");
                }
            }
            while ((result < low) || (result > high));
            return result;
        }

        //Get string input from user
        static string getString(string prompt = "")
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
            } while (result == "");
            return result;
        }

        //Ask the user to choose a type of wood; sends back a Wood structure with the type of wood and its price
        static Wood switchWood()
        {
            Wood woodChosen;
            woodChosen.woodType = DeskType.Birch;
            woodChosen.price = 0;
            string selection;
            bool stop = false;
            do
            {
                Console.WriteLine("Choose a surface material\n"+
                    "1: Oak ($500)\n"+
                    "2: Laminate ($400)\n"+
                    "3: Pine ($300)\n"+
                    "4: Plywood ($200)\n"+
                    "3: Rosewood ($100)\n"+
                    "3: Birch ($50)\n");
                selection = Console.ReadLine();
                switch(selection.ToUpper())
                {
                    case "O":
                    case "OAK":
                    case "1":
                        woodChosen.woodType = DeskType.Oak;
                        woodChosen.price = 500;
                        stop = true;
                        break;
                    case "L":
                    case "LAMINATE":
                    case "2":
                        woodChosen.woodType = DeskType.Laminate;
                        woodChosen.price = 400;
                        stop = true;
                        break;
                    case "PINE":
                    case "3":
                        woodChosen.woodType = DeskType.Pine;
                        woodChosen.price = 300;
                        stop = true;
                        break;
                    case "PLYWOOD":
                    case "4":
                        woodChosen.woodType = DeskType.Plywood;
                        woodChosen.price = 200;
                        stop = true;
                        break;
                    case "R":
                    case "ROSEWOOD":
                    case "5":
                        woodChosen.woodType = DeskType.Rosewood;
                        woodChosen.price = 100;
                        stop = true;
                        break;
                    case "B":
                    case "BIRCH":
                    case "6":
                        woodChosen.woodType = DeskType.Birch;
                        woodChosen.price = 50;
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            } while (!stop);

            return woodChosen;
        }

        static int rushDays()
        {
            int numDays = 0;
            string selection;
            do
            {
                Console.WriteLine("Choose number of days for your delivery\n" +
                    "3 Days\n" +
                    "5 Days\n" +
                    "7 Days\n");
                selection = Console.ReadLine();
                switch (selection.ToUpper())
                {
                    case "3":
                    case "T":
                    case "THREE":
                        numDays = 3;
                        break;
                    case "5":
                    case "F":
                    case "FIVE":
                        numDays = 5;
                        break;
                    case "7":
                    case "S":
                    case "SEVEN":
                        numDays = 7;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            } while (numDays == 0);
            return numDays;
        }

        static double[] getRushedPrices()
        {
            //Get prices from text file
            string filePath = @"rushOrderPrices.txt";
            double[] prices = new double[9];
            StreamReader reader = new StreamReader(filePath);
            int i = 0;
            //Each line from the text file is passed into the prices array
            while(reader.EndOfStream == false)
            {
                string line = reader.ReadLine();
                prices[i] = double.Parse(line);
                i++;
            }
            reader.Close();
            return prices;
        }

        static string readFileString(string filePath)
        {
            string textString = File.ReadAllText(filePath);
            return textString; 
        }

        static string yesOrNo()
        {
            string input, answer = "";
            do
            {
                input = Console.ReadLine();
                switch(input.ToUpper())
                {
                    case "Y":
                    case "YES":
                        answer = "yes";
                        break;
                    case "N":
                    case "NO":
                        answer = "no";
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            } while (answer == "");
            return answer;
        }

        

        static void Main(string[] args)
        {
            //Initialize variables
            double width = 0, length = 0, price = 0, drawerNum = 0, surfaceArea = 0, priceShipping = 0;
            int rushNum = 0;
            bool rush = false, complete = false;
            string name = "";
            Wood woodType;
            DeskStruct deskStr;
            //Create desk object
            Desk desk = new Desk();

            //Get User Input
            name = getString("Enter your name: ");
            //Add values to the desk structure as the user inputs data
            deskStr.customerName = name;
            Console.WriteLine("Hello " + name);
            //Loops until user enters width and length and agrees with surface area size
            while (!complete)
            { 
                width = getNumber(MINWIDTH, MAXWIDTH, "Please enter the width of the desk in inches between ");
                deskStr.widthDesk = width;
                length = getNumber(MINLENGTH, MAXLENGTH, "Please enter the length of the desk in inches between ");
                deskStr.lengthDesk = length;
                surfaceArea = desk.CalculateArea(width, length);
                deskStr.area = surfaceArea;
                double currentPrice = desk.PriceForArea(surfaceArea);
                Console.WriteLine("The surface area of the desk is " + surfaceArea + " inches squared.\n"+
                    "The starting price for a desk this size is $" + currentPrice + ".\n"+
                    "Is this the size you want?");
                string answer = yesOrNo();
                if(answer == "yes")
                {
                    complete = true;
                }
                else
                {
                    continue;
                }    
            }
            complete = false;
            drawerNum = getNumber(0, 7, "Please choose the number of drawers between ");
            deskStr.numberOfDrawers = drawerNum;
            woodType = switchWood();
            deskStr.surfaceType = woodType.woodType.ToString();
            //start loop again to see if user wants to rush their order
            while(!complete)
            {
                Console.WriteLine("Do you want to rush order your shipping?");
                string answer = yesOrNo();
                if (answer == "yes")
                {
                    rush = true;
                }
                else
                {
                    rush = false;
                }
                complete = true;
            }
            if(rush)
            {
                complete = false;
                while(!complete)
                {
                    //Ask for the number of days for the order
                    rushNum = rushDays();
                    //Calculate the shipping and ask user if the are ok with the price
                    priceShipping = desk.CalculateShipping(rushNum, surfaceArea, getRushedPrices());
                    Console.WriteLine("The cost of the shipping would be $" + priceShipping + "\n" +
                        "Are you sure?");
                    string answer = yesOrNo();
                    if (answer == "yes")
                    {
                        complete = true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            deskStr.rushDays = rushNum;
            deskStr.shipping = priceShipping;
            price = desk.CalculateTotalPrice(surfaceArea, drawerNum, woodType.price, priceShipping);
            deskStr.priceTotal = price;
            Console.WriteLine(
                "Price for desk size: \t\t\t$" + desk.PriceForArea(surfaceArea) + "\n"+
                "Number of drawers: " + "50 X " + deskStr.numberOfDrawers + " = \t\t$" + (deskStr.numberOfDrawers * 50) + "\n"+
                "Type of surface material: " + woodType.woodType + " \t\t$" + woodType.price + "\n"+
                "Rush order: " + deskStr.rushDays + " days" + " \t\t\t$" + deskStr.shipping + "\n\n"+
                "The total cost of the desk is \t\t$" + deskStr.priceTotal);
                
               
            
            //Add values to desk object
            desk.customerName = name;
            desk.widthDesk = width;
            desk.lengthDesk = length;
            desk.rushDays = rushNum;
            desk.surfaceType = woodType.woodType.ToString();
            desk.numberOfDrawers = drawerNum;
            desk.price = price - priceShipping;
            desk.shipping = priceShipping;
            desk.priceTotal = price;
            desk.area = surfaceArea;

            //load older JSONs and deserialize them into a list
            string filePath = @"desks.json";
            string path = Path.Combine(Environment.CurrentDirectory, filePath);
            string jsonData = readFileString(filePath);
            List<Desk> desks = JsonConvert.DeserializeObject<List<Desk>>(jsonData) ?? new List<Desk>();
            //add new JSON to list
            desks.Add(desk);
            //serialize and write list to a file
            jsonData = JsonConvert.SerializeObject(desks, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Did you enjoy your desk buying experience?");
            string yes = yesOrNo();


            


        }
    }
}
