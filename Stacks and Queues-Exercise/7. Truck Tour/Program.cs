﻿namespace _7._Truck_Tour
{
    /*
     Let’s suppose there is a circular route for lorries. There are N petrol pumps on that route. Petrol pumps are 
numbered 0 to (N−1) (both inclusive). You will receive information (array), corresponding to each of the petrol 
pumps: [0] the amount of petrol (in litres) that particular petrol pump will give, and [1] the distance(in kilometers) 
from the current petrol pump to the next petrol pump.
You have a tank of infinite capacity carrying no petrol. Your task is to figure out, which is the first possible petrol 
pump, from which the lorry will be able to complete the route. Consider that the lorry will stop at each of the petrol 
pumps. The lorry will move one kilometer for each liter of petrol.

Input
 The first line will contain the value of N
 The next N lines will contain a pair of integers each, i.e. the amount of petrol that petrol pump will give and 
the distance between that petrol pump and the next petrol pump.

Output
 An integer which will be the smallest index of the petrol pump from which we can start the tour.
     */


    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPetrolStations = int.Parse(Console.ReadLine());
            Queue<int[]> petrolStationInfo = new Queue<int[]>();

            for (int i = 0; i < countOfPetrolStations; i++)
            {
                int[] station = Console.ReadLine().Split().Select(int.Parse).ToArray();
                petrolStationInfo.Enqueue(station);
                // fill the queue with pump stations
            }
            int indexOfStation = 0;

            while (true)
            {
                bool isComplete = true;
                int litres = 0;// litres in truck 
                int[] currStation = petrolStationInfo.Peek();

                foreach (var station in petrolStationInfo)
                    // here var station is an array of integers [0] - for litres, and [1] for distance to the next station
                {
                    int currLitres = station[0];
                    int currDistance = station[1];
                    litres += currLitres;// add litres in the truck

                    if (litres < currDistance)// if they are not  enough to drive to next station
                    {
                        petrolStationInfo.Dequeue();// remove this station from the queue and added it as last element of queue
                        petrolStationInfo.Enqueue(currStation);
                        indexOfStation++;// increase the index of searching station
                        isComplete = false;
                        break;
                    }
                    else
                    {

                        litres -= currDistance;
                    }
                }

                if (isComplete == true)
                {
                    Console.WriteLine(indexOfStation);
                    break;
                }

            }
        }
    }
}