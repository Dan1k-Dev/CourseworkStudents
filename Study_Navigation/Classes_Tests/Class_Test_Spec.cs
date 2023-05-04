using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Navigation.Classes_Tests
{
    public class Class_Test_Spec
    {
        public bool NewSpec(string title)
        {
            int lenght = title.Length;

            bool rez = lenght > 0;
            if (rez)
            {
                using (var context = new MyDbContext())
                {
                    var add = new Specialization()
                    {
                        title_specialization = title
                        
                    };
                    context.Specializations.Add(add);
                    context.SaveChanges();

                    var maxValue = context.Specializations.Max(x => x.id_specializtion);
                    var result = context.Specializations.First(x => x.id_specializtion == maxValue);

                    string checkTitle = result.title_specialization;
                    return (0 == String.Compare(title, checkTitle));
                }
            }
            else
            {
                return false;
            }
        }
    }
}
