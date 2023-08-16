namespace _10._Crossroads
{
    /*The road Sam is on has a single lane where cars queue up until the light goes green. When it does, they start passing 
one by one during the green light and the free window before the intersecting road's light goes green. During one
second only one part of a car (a single character) passes the crossroads. If a car is still at the crossroads when the 
free window ends, it will get hit at the first character that is still in the crossroads.

Input
 On the first line, you will receive the duration of the green light in seconds – an integer in the range 
[1…100].
 On the second line, you will receive the duration of the free window in seconds – an integer in the range 
[0…100].
 On the following lines, until you receive the "END" command, you will receive one of two things:
 A car – a string containing any ASCII character, or
 The command "green" indicates the start of a green light cycle
A green light cycle goes as follows:
 During the green light, cars will enter and exit the crossroads one by one.
 During the free window, cars will only exit the crossroads.

Output
 If a crash happens, end the program and print:
"A crash happened!"
"{car} was hit at {characterHit}."
 If everything goes smoothly and you receive an "END" command, prin
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeLight = int.Parse(Console.ReadLine());
            Queue<string>cars = new Queue<string>();
            string car;
            
            int passedCars = 0;
            while ((car = Console.ReadLine()) != "END")
            {
                
                if (car != "green")
                {
                    cars.Enqueue(car);
                    continue;
                }
                int currDuration = greenDuration;
                while (currDuration >0 && cars.Any())
                {
                    string currCar = cars.Dequeue();
                    if(currDuration>=currCar.Length) // in this case car passed succesfully
                    {
                        currDuration -= currCar.Length; // decrement green Duration with exactly length of a car name
                        passedCars++;
                        continue;// get a new command
                    }
                    if (currDuration + freeLight - currCar.Length>=0)// if green + free lights are enough to pass current car
                    {
                        passedCars++;
                        currDuration = 0;
                        
                        continue;// get a new command
                    }

                    // if the greenLight + freeLight are not enough to pass the car -> The crash hapens
                    int indexToCrash = currDuration+freeLight; // index of letter that hapens the crash
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{currCar} was hit at {currCar[indexToCrash]}.");
                        return;// stop the all program
                }

            

            } Console.WriteLine("Everyone is safe.");// in case all cars passed succesfully
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");

        }
    }
}