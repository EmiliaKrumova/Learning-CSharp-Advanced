using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
           Type type = obj.GetType();// взимаме типа на класа (в случая Персон)
            PropertyInfo[] props = type// масив от инфо за пропъртитата
                .GetProperties()// от всички пропъртите
                .Where(pr=>pr.CustomAttributes// които имат изобщо някакви "мои" къстъм атрибути
                .Any(atribute=>typeof(MyValidationAttribute)// поне един, който да е от тип(или да е наследник на) MyValidationAttribute
                .IsAssignableFrom(atribute.AttributeType)))// и е възможно на бъде присвоен на същия тип (тоест или самия атрибут или негов наследник може да бъде от този тип)
                .ToArray();// на  масив

            foreach (PropertyInfo prop in props)
            {
                IEnumerable<MyValidationAttribute> attributes = 
                    prop.GetCustomAttributes()
                    .Where(ca=>typeof(MyValidationAttribute)
                    .IsAssignableFrom(ca.GetType()))
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attr in attributes)
                {
                    if (!attr.IsValid(prop.GetValue(obj)))
                    {
                        return false;
                    }
                   
                    
                }
            }
            return true;
        }
    }
}
