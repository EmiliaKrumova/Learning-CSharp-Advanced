using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public string Type { get; set; }
        public int Capacity { get; set; }

        public List<Cloth> Clothes { get; set; }

        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
           
        }
        public bool RemoveCloth(string color)
        {
            Cloth clothToRemove = Clothes.FirstOrDefault(c => c.Color == color);
            if(clothToRemove != null)
            {
                Clothes.Remove(clothToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }
        //Method GetSmallestCloth() – returns the Cloth with the smallest Size
        public Cloth GetSmallestCloth()
        {
           Cloth smallest = Clothes.OrderBy(cloth=> cloth.Size).First();
           
            return smallest;
        }
        //Method GetCloth(string color) – returns the Cloth with the given colo
        public Cloth GetCloth(string color)
        {
            Cloth cloth = Clothes.FirstOrDefault(cl => cl.Color == color);
            return cloth;
        }
        //Method GetClothCount() – returns the number of clothe
        public int GetClothCount()
        {
            return Clothes.Count;
        }
        //Method Report()
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Type} magazine contains:");
            foreach(Cloth cloth in Clothes.OrderBy(cloth => cloth.Size))
            {
                sb.AppendLine(cloth.ToString().TrimEnd());
            }
            return sb.ToString().TrimEnd();

        }
    }
}
