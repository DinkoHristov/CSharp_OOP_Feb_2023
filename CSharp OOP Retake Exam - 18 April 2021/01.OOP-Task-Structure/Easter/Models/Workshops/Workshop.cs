using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
            
        }

        public void Color(IEgg egg, IBunny bunny)
        {
            bool isEggDone = false;

            foreach (IDye dye in bunny.Dyes)
            {
                while (!dye.IsFinished())
                {
                    if (egg.IsDone())
                    {
                        isEggDone = true;
                        break;
                    }

                    if (bunny.Energy > 0 && 
                        !dye.IsFinished())
                    {
                        bunny.Work();
                        dye.Use();
                        egg.GetColored();
                    }
                }

                if (egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
