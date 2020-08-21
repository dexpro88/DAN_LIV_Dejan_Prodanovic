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
        static BW bworker;
        static SemaphoreBw semaphore = new SemaphoreBw();
        static object gasStation = new object();
        static object   endRace = new object();

        static bool weHaveWiner;
        static Car winner;
        public static int counter = 0;

        static void Main(string[] args)
        {
            Dictionary<string,Car> cars = new Dictionary<string,Car>();
            LinkedList<Tractor> tractors = new LinkedList<Tractor>();
            HashSet<Truck> trucks = new HashSet<Truck>();
            Dictionary<string, Thread> threads = new Dictionary<string, Thread>();

            DemoClass.CreateCars(cars);
            DemoClass.CreateTractors(tractors);
            DemoClass.CreateTrucks(trucks);
          
           
            Car orangeGolf = new Car("NS-457-AC", 4, 55, "manual", "Golf", 9874255, 20
               , 1000, "B", "petrol", "orange", 3432,3);

            orangeGolf.CurrentAmountOfFuel = 35;
            Thread.Sleep(5000);

           

            Console.WriteLine("Cars come to the start\n");
            foreach (var car in cars)
            {
                Console.WriteLine("{0} {1} is ready", car.Value.Color, car.Value.Producer);
            }
            cars.Add(orangeGolf.RegistrationNumber,orangeGolf);
            Console.WriteLine("{0} {1} joins race", orangeGolf.Color, orangeGolf.Producer);
            Console.WriteLine();
           

            foreach (var car in cars)
            {
                Thread t = new Thread(()=>Race(car.Value));
                string name = car.Value.Color + " "+ car.Value.Producer;
                t.Name = name;
                threads.Add(car.Value.RegistrationNumber,t);
                t.Start();
            }
           
            bworker = new BW(cars, threads);
            bworker.DoStuff();
            semaphore.DoStuff();

            Thread endThread = new Thread(PrintWinner);
            endThread.Start();



            Console.ReadLine();
        }

      /// <summary>
      /// Method runned by threads that represent cars
      /// it simulates the race
      /// </summary>
      /// <param name="car"></param>
        static void Race(Car car)
        {
            Console.WriteLine("{0} started",Thread.CurrentThread.Name);

            Thread.Sleep(10000);

            //cars came to the semaphore we check the current state
            if (semaphore.semaphoreOn)
            {
                Console.WriteLine("{0} waits on semaphore", Thread.CurrentThread.Name);
                while (semaphore.semaphoreOn)
                {
                    Thread.Sleep(200);
                }
                Console.WriteLine("{0} starts again", Thread.CurrentThread.Name);
            }

            Thread.Sleep(3000);

            //we check the ammount of gas in car and we tank it in case if it is less than 15
            if (car.CurrentAmountOfFuel < 15)
            {
                lock (gasStation)
                {
                    Console.WriteLine("{0} {1} tanks fuel",car.Producer,car.Color);
                    car.CurrentAmountOfFuel = car.TankVolume;
                    Thread.Sleep(1000);
                }
            }

            Thread.Sleep(7000);

            //car finished race we check if he is the winner
            if (!weHaveWiner)
            {
                if (car.Color.Equals("red"))
                {
                 
                    winner = car;
                    weHaveWiner = true;
                   
                   
                }
             
            }
            car.FinishRace = true;

            Console.WriteLine("{0} finish race", Thread.CurrentThread.Name);

            //we check if all cares finished race (or run out of fuel)
            counter++;
            if (counter==3)
            {
                semaphore.raceEnds = true;
                lock (endRace)
                {
                    Monitor.Pulse(endRace);
                }
            }
            
           
        }
        /// <summary>
        /// prints who the winner of the race is
        /// </summary>
        static void PrintWinner()
        {
            lock (endRace)
            {
                Monitor.Wait(endRace);
                if (winner!=null)
                {
                    Console.WriteLine("\nThe winner is: {0} {1}", winner.Color, winner.Producer);
                }
                else
                {
                    Console.WriteLine("\nThe race has no winner");
                }
               
            }
           
        }
    }
}
