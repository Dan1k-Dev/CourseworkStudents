using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Navigation.Classes_Tests
{
    public class Class_Test_Fac
    {
        public bool NewFac(string title, string headDep, int formEd, int Spec)
        {
            int lenght = title.Length;
            int lenght1 = headDep.Length;
            int lenght2 = formEd;
            int lenght3 = Spec;

            bool rez = lenght > 0 && lenght1 > 0 && lenght2 > 0 && lenght3 > 0;
            if (rez)
            {
                using (var context = new MyDbContext())
                {
                    var add = new Educational_Program()
                    {
                        title_program = title,
                        head_department = headDep,
                        form_education = formEd,
                        specialization = Spec
                    };
                    context.Educational_s.Add(add);
                    context.SaveChanges();

                    var maxValue = context.Educational_s.Max(x => x.id_program);
                    var result = context.Educational_s.First(x => x.id_program == maxValue);

                    string checkTitle = result.title_program;
                    string checkDep = result.head_department;
                    int checkForm = result.form_education;
                    int checkSpec = result.specialization;
                    return (0 == String.Compare(title, checkTitle) && 0 == String.Compare(headDep, checkDep) && 0 == String.Compare(formEd.ToString(), checkForm.ToString()) && 0 == String.Compare(Spec.ToString(), checkSpec.ToString()));
                }
            }
            else
            {
                return false;
            }
        }
    }
}
