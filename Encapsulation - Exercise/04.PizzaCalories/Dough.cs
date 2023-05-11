using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private string flour;
        private string bakingTechnique;
        private decimal doughWeigh;

        public Dough(string flour, string bakingTechnique, decimal caloriesPerGram)
        {
            Flour = flour;
            BakingTechnique = bakingTechnique;
            CaloriesPerGram = caloriesPerGram;
        }

        private string Flour {
            get
            {
                return this.flour;
            }
            set
            { 
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flour = value;
            }
        }

        private string BakingTechnique {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (value.ToLower() != "crispy" && 
                    value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public decimal CaloriesPerGram {
            get
            {
                return this.doughWeigh;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                decimal flourTypeInt = 1;
                if (this.flour.ToLower() == "white")
                {
                    // 1.5
                    flourTypeInt = 1.5m;
                }
                else if (this.flour.ToLower() == "wholegrain")
                {
                    // 1.0
                    flourTypeInt = 1.0m;
                }

                decimal bakingInt = 1;
                if (this.bakingTechnique.ToLower() == "crispy")
                {
                    // 0.9
                    bakingInt = 0.9m;
                }
                else if (this.bakingTechnique.ToLower() == "chewy")
                {
                    // 1.1
                    bakingInt = 1.1m;
                }
                else if (this.bakingTechnique.ToLower() == "homemade")
                {
                    // 1.0
                    bakingInt = 1.0m;
                }

                decimal totalCalories = 2m * value * flourTypeInt * bakingInt;

                this.doughWeigh = totalCalories;
            }
        }
    }
}
