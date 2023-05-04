using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Navigation.Classes_Tests
{
    public class Class_Test_Perf
    {
        public bool NewPerf(int student, int discipline, int estim)
        {
            int lenght = student;
            int lenght1 = discipline;
            int lenght2 = estim;

            bool rez = lenght > 0 && lenght1 > 0 && lenght2 > 0;
            if (rez)
            {
                using (var context = new MyDbContext())
                {
                    var add = new Student_Progress()
                    {
                        student = student,
                        descipline = discipline,
                        estimation = estim,
                    };
                    context.Student_s.Add(add);
                    context.SaveChanges();

                    var maxValue = context.Student_s.Max(x => x.id_progress);
                    var result = context.Student_s.First(x => x.id_progress == maxValue);

                    int checkStud = result.student;
                    int checkDisc = result.descipline;
                    int checkEst = result.estimation;

                    return (0 == String.Compare(student.ToString(), checkStud.ToString()))
                        && 0 == String.Compare(discipline.ToString(), checkDisc.ToString())
                        && 0 == String.Compare(estim.ToString(), checkEst.ToString());
                }
            }
            else
            {
                return false;
            }
        }
    }
}
