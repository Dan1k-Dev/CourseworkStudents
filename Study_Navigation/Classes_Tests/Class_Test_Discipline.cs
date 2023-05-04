using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Navigation.Classes_Tests
{
    public class Class_Test_Discipline
    {
        public bool NewDiscipline(string title, int teacher, int hours)
        {
            int lenght = title.Length;
            int lenght1 = teacher;
            int lenght2 = hours;

            bool rez = lenght > 0 && lenght1 > 0 && lenght2 > 0;
            if (rez)
            {
                using (var context = new MyDbContext())
                {
                    var add = new Disciplines()
                    {
                        title_discipline = title,
                        teacher = teacher,
                        quantity_of_hours = hours
                    };
                    context.Disciplines.Add(add);
                    context.SaveChanges();

                    var maxValue = context.Disciplines.Max(x => x.id_discipline);
                    var result = context.Disciplines.First(x => x.id_discipline == maxValue);

                    string checkDisc= result.title_discipline;
                    int checkTeach = result.teacher;
                    int checkQH = result.quantity_of_hours;
                    return (0 == String.Compare(title, checkDisc) && 0 == String.Compare(teacher.ToString(), checkTeach.ToString()) && 0 == String.Compare(hours.ToString(), checkQH.ToString()));
                }
            }
            else
            {
                return false;
            }
        }
    }
}
