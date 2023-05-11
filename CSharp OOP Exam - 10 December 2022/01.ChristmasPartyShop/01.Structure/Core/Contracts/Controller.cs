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

namespace ChristmasPastryShop.Core.Contracts
{
    public class Controller : IController
    {
        private readonly BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(this.booths.Models.Count + 1, capacity);

            this.booths.AddModel(booth);

            return $"Added booth number {booth.BoothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {

            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }

            if (size != "Large" && size != "Middle" && size != "Small")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }

            if (this.booths.Models.Any(d => d.CocktailMenu.Models.Any(n => n.Name == cocktailName && n.Size == size)))
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            ICocktail cocktail = null;

            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            if (this.booths.Models.Any(d => d.DelicacyMenu.Models.Any(n => n.Name == delicacyName)))
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            IDelicacy delicacy = null;

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder result = new StringBuilder();

            result.AppendLine(booth.ToString());

            return result.ToString().TrimEnd();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            booth.Charge();

            booth.ChangeStatus();

            StringBuilder result = new StringBuilder();

            result.AppendLine($"Bill {booth.Turnover:F2} lv");
            result.AppendLine($"Booth {booth.BoothId} is now available!");

            return result.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = this.booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(c => c.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return $"No available booth for {countOfPeople} people!";
            }

            booth.ChangeStatus();

            return $"Booth {booth.BoothId} has been reserved for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderArgs = order.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderArgs[0];
            string itemName = orderArgs[1];
            int count = int.Parse(orderArgs[2]);
            string size = string.Empty;

            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                size = orderArgs[3];
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (itemTypeName != nameof(MulledWine) &&
                itemTypeName != nameof(Hibernation) &&
                itemTypeName != nameof(Gingerbread) &&
                itemTypeName != nameof(Stolen))
            {
                return $"{itemTypeName} is not recognized type!";
            }

            if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName) &&
                !booth.DelicacyMenu.Models.Any(d => d.Name == itemName))
            {
                return $"There is no {itemTypeName} {itemName} available!";
            }

            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(b => b.GetType().Name == itemTypeName &&
                b.Name == itemName && b.Size == size);

                if (cocktail == null)
                {
                    return $"There is no {size} {itemName} available!";
                }

                booth.UpdateCurrentBill(cocktail.Price * count);

                return $"Booth {boothId} ordered {count} {itemName}!";
            }
            else if (itemTypeName == nameof(Gingerbread) || itemTypeName == nameof(Stolen))
            {

                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(b => b.GetType().Name == itemTypeName &&
                b.Name == itemName);

                if (delicacy == null)
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }

                booth.UpdateCurrentBill(delicacy.Price * count);

                return $"Booth {boothId} ordered {count} {itemName}!";
            }

            return null;
        }
    }
}
