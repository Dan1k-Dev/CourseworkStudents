using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Navigation.Classes_Tests
{
    public class Class_Test_Group
    {
        public bool NewGroup(string title, string year, string elder, int director, int edPr)
        {
            int lenght = title.Length;
            int lenght1 = year.Length;
            int lenght2 = elder.Length;
            int lenght3 = director;
            int lenght4 = edPr;

            bool rez = lenght > 0 && lenght1 > 0 && lenght2 > 0 && lenght3 > 0 && lenght4 > 0;
            if (rez)
            {
                using (var context = new MyDbContext())
                {
                    var add = new Group()
                    {
                        Title_group = title,
                        Year_of_recruitment = year,
                        Elder_of_group = elder,
                        Director_teacher = director,
                        Educational_program = edPr
                    };
                    context.Groups.Add(add);
                    context.SaveChanges();

                    var maxValue = context.Groups.Max(x => x.id_group);
                    var result = context.Groups.First(x => x.id_group == maxValue);

                    string checkTitle = result.Title_group;
                    string checkYear = result.Year_of_recruitment;
                    string checkElder = result.Elder_of_group;
                    int checkDirec = result.Director_teacher;
                    int checkEdPr = result.Educational_program;
                    return (0 == String.Compare(title, checkTitle)) && 0 == String.Compare(year.ToString(), checkYear.ToString()) && 0 == String.Compare(elder, checkElder) && 0 == String.Compare(director.ToString(), checkDirec.ToString()) && 0 == String.Compare(edPr.ToString(), checkEdPr.ToString());
                }
            }
            else
            {
                return false;
            }
        }
    }
}
