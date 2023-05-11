using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private double turnover;
        private double currentBill = 0;
        private int capacity;

        private readonly IRepository<IDelicacy> delicacies;
        private readonly IRepository<ICocktail> cocktails;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            currentBill = 0;
            turnover = 0;

            delicacies = new DelicacyRepository();
            cocktails = new CocktailRepository();
        }
        public int BoothId { get; private set; }

        public int Capacity {
            get
            {
                return this.capacity;
            }
            private set
            { 
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }

                this.capacity = value;
            } 
        }

        public IRepository<IDelicacy> DelicacyMenu
            => this.delicacies;

        public IRepository<ICocktail> CocktailMenu
            => this.cocktails;

        public double CurrentBill => this.currentBill;

        public double Turnover => this.turnover;

        public bool IsReserved { get; private set; }

        public void ChangeStatus()
        {
            if (IsReserved)
            {
                IsReserved = false;
                return;
            }

            IsReserved = true;
        }

        public void Charge()
        {
            turnover += currentBill;

            currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            currentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Booth: {BoothId}");
            result.AppendLine($"Capacity: {Capacity}");
            result.AppendLine($"Turnover: {Turnover:F2} lv");

            result.AppendLine("-Cocktail menu:");

            if (CocktailMenu.Models.Count > 0)
            {
                foreach (var coctailMenu in CocktailMenu.Models)
                {
                    result.AppendLine($"--{coctailMenu.ToString()}");
                }
            }

            result.AppendLine("-Delicacy menu:");

            if (DelicacyMenu.Models.Count > 0)
            {
                foreach (var delicacyMenu in DelicacyMenu.Models)
                {
                    result.AppendLine($"--{delicacyMenu.ToString()}");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
