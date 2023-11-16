using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
    public class Tracker
    {
         public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance |BindingFlags.Static);
           foreach (var method in methods)
            {
                
                if (method.CustomAttributes.Any(met => met.AttributeType == typeof(AuthorAttribute)))
                {
                  var attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute atribute in attributes)
                    {
                        Console.WriteLine("{0} is written by {1}", method.Name, atribute.Name);
                    }
                }
            }
        }
    }
}
