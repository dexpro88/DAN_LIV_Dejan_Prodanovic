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
        private BackgroundWorker worker = new BackgroundWorker();

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

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            while (!raceEnds)
            {
                Thread.Sleep(1000);
                

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


        private void PrintExecute()
        {


            if (!worker.IsBusy)
            {

                DoStuff();
            }

        }

        public void DoStuff()
        {
            worker.RunWorkerAsync();

        }
    }
}
