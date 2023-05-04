using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Navigation.Classes_Tests
{
    public class Class_Test_Stud
    {
        public bool NewStud(string FCs, int numb_grade, string date_born, string address, string telephone, int group, string fluorgr)
        {
            int lenght = FCs.Length;
            int lenght1 = numb_grade;
            int lenght2 = date_born.Length;
            int lenght3 = address.Length;
            int lenght4 = telephone.Length;
            int lenght5 = group;
            int lenght6 = fluorgr.Length;

            bool rez = lenght > 0 && lenght1 > 0 && lenght2 > 0 && lenght3 > 0 && lenght4 > 0 && lenght5 > 0 && lenght6 > 0;
            if (rez)
            {
                using (var context = new MyDbContext())
                {
                    var add = new Student()
                    {
                        FCs = FCs,
                        numb_of_gradebook = numb_grade,
                        date_of_born = date_born,
                        address = address,
                        telephone = telephone,
                        group = group,
                        fluorography = fluorgr
                    };
                    context.Students.Add(add);
                    context.SaveChanges();

                    var maxValue = context.Students.Max(x => x.id_student);
                    var result = context.Students.First(x => x.id_student == maxValue);

                    string checkFcs = result.FCs;
                    int checkGrade = result.numb_of_gradebook;
                    string checkBorn = result.date_of_born;
                    string checkAddres = result.address;
                    string checkTeleph = result.telephone;
                    int checkGroup = result.group;
                    string checkFlu = result.fluorography;
   
                    return (0 == String.Compare(FCs, checkFcs)) && 0 == String.Compare(numb_grade.ToString(), checkGrade.ToString()) 
                        && 0 == String.Compare(date_born, checkBorn)
                        && 0 == String.Compare(address, checkAddres) 
                        && 0 == String.Compare(telephone, checkTeleph)
                        && 0 == String.Compare(group.ToString(), checkGroup.ToString())
                        && 0 == String.Compare(fluorgr, checkFlu);
                }
            }
            else
            {
                return false;
            }
        }
    }
}
