using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gerenciamento_Colmeia
{
    class Queen
    {
        public Queen(Worker[] workers)
        {
            this.workers = workers;
        }

        private Worker[] workers;
        private int shiftNumber = 0;

        public bool AssignWork(string job, int numberOfShifts)
        {
            for (int i = 0; i < workers.Length; i++)
                if (workers[i].DoThisJob(job, numberOfShifts))
                    return true;

            return false;
        }

        public string WorkTheNextShift()
        {
            shiftNumber++;
            string report = "Relatório para turno #" + shiftNumber + "\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].WorkOneShift())
                    report += "Operária #" + (i + 1) + " terminou o trabalho\r\n";
                if (string.IsNullOrEmpty(workers[i].currentJob))
                    report += "Operária #" + (i + 1) + " não está trabalhando\r\n";
                else
                    if (workers[i].shiftsLeft > 0)
                        report += "Operária #" + (i + 1) + " fará " + workers[i].currentJob
                            + " por " + workers[i].shiftsLeft + " mais turnos\r\n";
                    else
                        report += "Operária #" + (i + 1) + " terminará '"
                            + workers[i].currentJob + "' após este turno\r\n";

            }
            return report;
        }
    }
}
