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

            string result = spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}