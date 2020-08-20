using DAN_LIV_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_LIV_Dejan_Prodanovic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            LinkedList<Tractor> tractors = new LinkedList<Tractor>();
            HashSet<Truck> trucks = new HashSet<Truck>();
           

            DemoClass.CreateCars(cars);
            DemoClass.CreateTractors(tractors);
            DemoClass.CreateTrucks(trucks);
            BW bworker = new BW(cars);
           
            Car orangeGolf = new Car("NS-457-AC", 4, 55, "manual", "Golf", 9874255, 20
               , 1000, "B", "petrol", "orange", 3432,3);

            orangeGolf.CurrentAmountOfFuel = 45;
            Thread.Sleep(5000);

           

            Console.WriteLine("Cars come to the start\n");
            foreach (var car in cars)
            {
                Console.WriteLine("{0} {1} is ready", car.Color, car.Producer);
            }
            cars.Add(orangeGolf);
            Console.WriteLine("{0} {1} joins race", orangeGolf.Color, orangeGolf.Producer);
            Console.WriteLine();
            foreach (var car in cars)
            {
                Thread t = new Thread(Race);
                string name = car.Color+" "+ car.Producer;
                t.Name = name;
                t.Start();
            }
            bworker.DoStuff();
            Console.ReadLine();
        }

      
        static void Race()
        {
            Console.WriteLine("{0} started",Thread.CurrentThread.Name);

            Thread.Sleep(10000);
        }
    }
}
