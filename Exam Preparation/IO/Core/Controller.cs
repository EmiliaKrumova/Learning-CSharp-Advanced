using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private readonly BoothRepository boothRepository;

        public Controller()
        {
            boothRepository = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothId = this.boothRepository.Models.Count;
            IBooth booth = new Booth(boothId,capacity);
            this.boothRepository.AddModel(booth);

            return $"Added booth number {boothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = this.boothRepository.Models.FirstOrDefault(booth => booth.BoothId == boothId);
            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(delicacy => delicacy.Name == delicacyName);

            if (delicacy != null)
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }


            switch (delicacyTypeName)
            {
                case nameof(Gingerbread):
                    delicacy = new Gingerbread(delicacyName);
                    break;
                case nameof(Stolen):
                    delicacy = new Stolen(delicacyName);
                    break;
                default:
                    return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            booth.DelicacyMenu.AddModel(delicacy);
            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = this.boothRepository.Models.FirstOrDefault(booth => booth.BoothId == boothId);
            ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(cocktail => cocktail.Name == cocktailName && cocktail.Size == size);

            if (size != "Small" && size != "Middle" && size != "Large") 
            {
                return $"{size} is not recognized as valid cocktail size!";
            }
            
            if (cocktail != null)
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            switch (cocktailTypeName)
            {
                case nameof(Hibernation):
                    cocktail = new Hibernation(cocktailName, size);
                    break;
                case nameof(MulledWine):
                    cocktail = new MulledWine(cocktailName, size);
                    break;
                default:
                    return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }

            booth.CocktailMenu.AddModel(cocktail);
            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string ReserveBooth(int countOfPeople)
        {
            var boothToReserve = this.boothRepository
                .Models
                .Where(booth => booth.IsReserved == false && booth.Capacity >= countOfPeople)
                .OrderBy(booth => booth.Capacity)
                .ThenByDescending(booth => booth.BoothId)
                .FirstOrDefault();

            if (boothToReserve == null)
            {
                return $"No available booth for {countOfPeople} people!";
            }
            else 
            {
                boothToReserve.ChangeStatus();
                return $"Booth {boothToReserve.BoothId} has been reserved for {countOfPeople} people!";
            }

        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = this.boothRepository
                .Models
                .FirstOrDefault(booth => booth.BoothId == boothId);

            string[]orderArray = order.Split('/');
            string itemTypeName = orderArray[0];
            string itemName = orderArray[1];
            string countOfOrderedPieces
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = this.boothRepository
                .Models
                .FirstOrDefault(booth => booth.BoothId == boothId);

            StringBuilder boothStats = new StringBuilder();
            boothStats.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            boothStats.AppendLine($"Booth {booth.BoothId} is now available!");
            
            booth.Charge();
            booth.ChangeStatus();

            return boothStats.ToString().TrimEnd();


        }

        public string BoothReport(int boothId)
        {
            StringBuilder boothReport = new StringBuilder();

            foreach (var booth in this.boothRepository.Models)
            {
                boothReport.AppendLine(booth.ToString());
            }

            return boothReport.ToString().TrimEnd();
        }
    }
}
