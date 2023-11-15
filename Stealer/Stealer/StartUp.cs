namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            //задача 1
            //string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");

            // задача 2
            // string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");

            //задача  3
            //string result = spy.RevealPrivateMethods("Stealer.Hacker");

            //задача 4
            string result = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}