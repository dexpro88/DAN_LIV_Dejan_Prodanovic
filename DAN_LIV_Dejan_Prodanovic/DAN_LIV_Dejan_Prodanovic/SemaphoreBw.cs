using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_LIV_Dejan_Prodanovic
{
    class SemaphoreBw
    {
        public bool raceEnds = false;
        public BackgroundWorker worker = new BackgroundWorker();
        public bool semaphoreOn;

        public SemaphoreBw()
        {

            worker.DoWork += DoWork;
            worker.ProgressChanged += ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted += RunWorkerCompleted;
            
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        /// <summary>
        /// changes to light on semaphore and prints current state in console
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            while (!raceEnds)
            {
                if (semaphoreOn)
                {
                    Console.WriteLine("Semaphore Light is green");
                    semaphoreOn = false;
                    
                }
                else
                {
                    Console.WriteLine("Semaphore Light is red");
                    semaphoreOn = true;
                  
                }
                Thread.Sleep(2000);
               

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
