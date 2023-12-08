using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        public IRepository<IBooth> booths;

        //ctor
        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothID = booths.Models.Count + 1;
            Booth booth = new Booth(boothID,capacity);
            booths.AddModel(booth);
            return string
                .Format(OutputMessages.NewBoothAdded, boothID, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if(cocktailTypeName!=nameof(Hibernation)&& cocktailTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            if(size!="Large" &&size!= "Middle"&& size!= "Small")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }
            
            if (this.booths.Models.Any(b => b.CocktailMenu.Models.Any(cm => cm.Name == cocktailName && cm.Size == size)))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size,cocktailName);
            }
            IBooth currBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            ICocktail coctailToAdd = null;
            if (cocktailTypeName == nameof(MulledWine))
            {
                coctailToAdd = new MulledWine(cocktailName, size);
            }else if(cocktailTypeName== nameof(Hibernation))
            {
                coctailToAdd = new Hibernation(cocktailName,size);
            }
            currBooth.CocktailMenu.AddModel(coctailToAdd);
            //"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!" 
             return string.Format(OutputMessages.NewCocktailAdded, size,cocktailName,cocktailTypeName);
            
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return string
                    .Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            
            if(this.booths.Models.Any(b => b.DelicacyMenu.Models.Any(dm => dm.Name == delicacyName)))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            IBooth currBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            IDelicacy delicasyToAdd = null;
            if(delicacyTypeName== nameof(Gingerbread))
            {
                delicasyToAdd = new Gingerbread(delicacyName);
            }else 
            {
                delicasyToAdd = new Stolen(delicacyName);
            }
            currBooth.DelicacyMenu.AddModel(delicasyToAdd);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
           var booth = booths.Models.FirstOrDefault(b=>b.BoothId==boothId);
            return booth.ToString().Trim();
        }

        public string LeaveBooth(int boothId)
        {
            var bootToLeave = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Bill {bootToLeave.CurrentBill:f2} lv");

            bootToLeave.Charge();
            bootToLeave.ChangeStatus();
            
            stringBuilder.AppendLine($"Booth {boothId} is now available!");
            return stringBuilder.ToString().Trim();
            
        }

        public string ReserveBooth(int countOfPeople)
        {
            
            IBooth boothToReserve = booths.Models.Where(b=>b.IsReserved==false&&b.Capacity>=countOfPeople).OrderBy(b=>b.Capacity).ThenByDescending(b=>b.BoothId).FirstOrDefault();
            if(boothToReserve == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople); 
            }
            boothToReserve.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully,boothToReserve.BoothId, countOfPeople);//???
            //boothToReserve.Capacity вместо countOfPeople
        }

        public string TryOrder(int boothId, string order)
        {
            string[] data = order.Split("/", StringSplitOptions.RemoveEmptyEntries);
            bool IsCoctail = false;
            string itemTypeName = data[0];            string itemName = data[1];            int countOfOrderedItems = int.Parse(data[2]);            string size = string.Empty;                        if(data.Length== 4)
            {
                size = data[3];
                IsCoctail = true;
            }            IBooth currBooth = booths.Models.FirstOrDefault(b=>b.BoothId == boothId);            if(itemTypeName!=nameof(Hibernation)&&                 itemTypeName != nameof(MulledWine) &&                 itemTypeName != nameof(Gingerbread) &&                 itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }                                    if(!currBooth.DelicacyMenu.Models.Any(i=>i.Name == itemName)                && !currBooth.CocktailMenu.Models.Any(i =>  i.Name == itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }            IDelicacy delicacy = null;            ICocktail cocktail = null;            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                IsCoctail = true;
            }            if (IsCoctail)
            {
                if (currBooth.CocktailMenu.Models.Any(i => i.Name == itemName && i.GetType().Name == itemTypeName && i.Size == size))
                {
                    cocktail = currBooth.CocktailMenu.Models.
                        FirstOrDefault(i => i.Name == itemName
                        && i.GetType().Name == itemTypeName
                        && i.Size == size);

                    currBooth.UpdateCurrentBill(cocktail.Price * countOfOrderedItems);
                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedItems, itemName);
                }
                else
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName); ;
                }

            }
            else
            {
                if (currBooth.DelicacyMenu.Models.Any(i => i.Name == itemName && i.GetType().Name == itemTypeName ))
                {
                    delicacy = currBooth.DelicacyMenu.Models.
                        FirstOrDefault(i => i.Name == itemName
                        && i.GetType().Name == itemTypeName);

                    currBooth.UpdateCurrentBill(delicacy.Price * countOfOrderedItems);
                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedItems, itemName);
                }
                else
                {
                     return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName,itemName);
                    
                }
            }            
        }
    }
}
