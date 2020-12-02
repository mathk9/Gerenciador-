using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gerenciamento_Colmeia
{
    class Worker
    {
        public Worker(string[] jobsICanDo)
        {
            this.jobsICanDo = jobsICanDo;
        }

        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;
        public bool DoThisJob(string job, int numberOfShifts)
        {
            if (!String.IsNullOrEmpty(currentJob))
                return false;
            for (int i = 0; i < jobsICanDo.Length; i++)
                if (jobsICanDo[i] == job)
                {
                    currentJob = job;
                    this.shiftsToWork = numberOfShifts;
                    shiftsWorked = 0;
                    return true;
                }
            return false;
        }

        public int shiftsLeft
        {
            get
            {
                return shiftsToWork - shiftsWorked;
            }
        }

        public string currentJob = "";

        public bool WorkOneShift()
        {
            if (String.IsNullOrEmpty(currentJob))
                return false;
            shiftsWorked++;
            if (shiftsWorked > shiftsToWork)
            {
                shiftsToWork = 0;
                shiftsWorked = 0;
                currentJob = "";
                return true;
            }
            else
                return false;
        }
    }
}
