using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {

        public string StealFieldInfo(string className, params string[] fields)
            // метод за обследване на класа приема:
            // името на класа и множество параметри под формата на стринг[] полета
        {
            Type investigatedClasType = Type.GetType(className);// взимаме типа на класа, знаейки неговото име
            FieldInfo[] fieldInfos = investigatedClasType.GetFields// взимаме в масив всички полета от класа
                (BindingFlags.Public
                |BindingFlags.NonPublic
                |BindingFlags.Static
                |BindingFlags.Instance);

            Object classInstance = Activator.CreateInstance(investigatedClasType,new object[] { });// създаваме инстанция (обект) от този клас
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in fieldInfos
                .Where(f => fields.Contains(f.Name))) 
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            //намирам типа на класа

            FieldInfo[] fieldInfos = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Public|BindingFlags.Static);
            // намирам всички публични, инстанционни и статични полета

            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            // всички публични и инстанционни методи

            MethodInfo[] noNpublicMethods = classType.GetMethods (BindingFlags.NonPublic | BindingFlags.Instance);
            // всички прайвът и инстанционни методи


            StringBuilder sb = new StringBuilder();

            foreach(FieldInfo field in fieldInfos)
            {
                sb.AppendLine($"{field.Name} must be private!");// тези полета трябва да са привате
            }
            foreach(MethodInfo method in noNpublicMethods.Where(met=>met.Name.StartsWith("get")))
                // търся в Непубличните методи, всички методи, чието име започва с гет( тоест са направени привате)
                // -> те са сбъркани и трябва да са публик
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach(MethodInfo method1 in publicMethods.Where(met => met.Name.StartsWith("set")))
                //в масива от публик методи, не трябва да има методи със сеттер, намирам ако има такива и изписвам, че трябва да са привате
            {
                sb.AppendLine($"{method1.Name} have to be private!");
            }

            return sb .ToString().Trim();
            
        }
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.NonPublic|BindingFlags.Instance);
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach( MethodInfo method in methodInfos)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }
    }
}
