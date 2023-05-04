using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Navigation.Classes_Tests
{
    public class Class_Test_Attend
    {
        public bool NewAttend(int student, string date, int quantity_gr, int quantity_nGR, int general_hours)
        {
            int lenght = student;
            int lenght1 = date.Length;
            int lenght2 = quantity_gr;
            int lenght3 = quantity_nGR;
            int lenght4 = general_hours;

            bool rez = lenght > 0 && lenght1 > 0 && lenght2 > 0 && lenght3 > 0  && lenght4 > 0;
            if (rez)
            {
                using (var context = new MyDbContext())
                {
                    var add = new Attendance_Student()
                    {
                        Student = student,
                        date = date,
                        quantity_of_hours_GR = quantity_gr,
                        quantity_of_hours_nGR = quantity_nGR,
                        General_quantity_of_hours = general_hours
                    };
                    context.Attendances.Add(add);
                    context.SaveChanges();

                    var maxValue = context.Attendances.Max(x => x.id_attendance);
                    var result = context.Attendances.First(x => x.id_attendance == maxValue);

                    int checkStud = result.Student;
                    string checkDate = result.date;
                    int checkGR = result.quantity_of_hours_GR;
                    int checkNgr = result.quantity_of_hours_nGR;
                    int checkGen = result.General_quantity_of_hours;
                    return (0 == String.Compare(student.ToString(), checkStud.ToString())) && 0 == String.Compare(date, checkDate) && 0 == String.Compare(quantity_gr.ToString(), checkGR.ToString()) && 0 == String.Compare(quantity_nGR.ToString(), checkNgr.ToString()) && 0 == String.Compare(general_hours.ToString(), checkGen.ToString());
                }
            }
            else
            {
                return false;
            }
        }
    }
}
