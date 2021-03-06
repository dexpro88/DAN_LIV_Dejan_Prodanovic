﻿using DAN_LIV_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_LIV_Dejan_Prodanovic
{
    class BW
    {
        public bool raceEnds = false;
        
        private BackgroundWorker worker = new BackgroundWorker();

        Dictionary<string, Car> cars;
        Dictionary<string, Thread> threads;

        public BW(Dictionary<string,Car> cars, Dictionary<string, Thread> threads)
        {
           
            worker.DoWork += DoWork;
            worker.ProgressChanged += ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted += RunWorkerCompleted;
            this.cars = cars;
            this.threads = threads;
        }
                  
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
             
        }

        /// <summary>
        /// decrements the amount of fuel in every car every secon
        /// checks if the  car tankvolume is empty
        /// in case it is it aborts thread that represents that car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            while (!raceEnds)
            {
                Thread.Sleep(1000);
                string carToDeleteKey = null;
                foreach (var car in cars)
                {
                    car.Value.CurrentAmountOfFuel -= car.Value.AmountCousumedPerSec;
                    if (car.Value.CurrentAmountOfFuel <= 0
                        && car.Value.FinishRace != true)
                    {
                        Console.WriteLine("{0} {1} runs out of fuel and ends race"
                            ,car.Value.Color, car.Value.Producer);


                        carToDeleteKey = car.Key;
                        Program.counter++;
                    }
                    
                }
                if (carToDeleteKey!=null)
                {
                    cars.Remove(carToDeleteKey);
                    threads[carToDeleteKey].Abort();
                }
                
               
            }
           
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            
        }

        static void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            

        }



        /// <summary>
        /// starts Background worker
        /// </summary>
        public void DoStuff()
        {         
            worker.RunWorkerAsync();

        }
    }
}
