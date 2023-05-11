using _07.MilitaryElite.Core.Interface;
using _07.MilitaryElite.Enums;
using _07.MilitaryElite.Models;
using _07.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private Dictionary<int, ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                ISoldier currSoldier = null;

                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string soldierType = inputArgs[0];
                int id = int.Parse(inputArgs[1]);
                string firstName = inputArgs[2];
                string lastName = inputArgs[3];

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);

                    currSoldier = 
                        new Private(id, firstName, lastName, salary);

                    this.soldiers.Add(id, currSoldier);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);

                    List<IPrivate> privates = new List<IPrivate>();

                    string[] privatesId = inputArgs[5..inputArgs.Length];

                    foreach (var currId in privatesId)
                    {
                        int soldierId = int.Parse(currId);
                        IPrivate soldier = (IPrivate)soldiers[soldierId];
                        privates.Add(soldier);
                    }

                    currSoldier = 
                        new LieutenantGeneral(id, firstName, lastName, salary, privates);

                    this.soldiers.Add(id, currSoldier);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);

                    bool isValid = Enum.TryParse<Corps>(inputArgs[5], out Corps corps);
                    if (!isValid)
                    {
                        continue;
                    }

                    string corpInfo = inputArgs[5];
                    Corps corp = Corps.Airforces;

                    if (corpInfo == "Airforces")
                    {
                        corp = Corps.Airforces;
                    }
                    else if (corpInfo == "Marines")
                    {
                        corp = Corps.Marines;
                    }

                    string[] repairsInfo = inputArgs[6..inputArgs.Length];

                    List<IRepair> repairs = new List<IRepair>();

                    for (int i = 0; i < repairsInfo.Length; i += 2)
                    {
                        string partName = repairsInfo[i];
                        int hoursWork = int.Parse(repairsInfo[i + 1]);

                        Repair repair = new Repair(partName, hoursWork);

                        repairs.Add(repair);
                    }

                    currSoldier = 
                        new Engineer(id, firstName, lastName, salary, corp, repairs);

                    this.soldiers.Add(id, currSoldier);
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);

                    bool isValid = Enum.TryParse<Corps>(inputArgs[5], out Corps corps);
                    
                    if (!isValid)
                    {
                        continue;
                    }

                    string corpInfo = inputArgs[5];
                    Corps corp = Corps.Airforces;

                    if (corpInfo == "Airforces")
                    {
                        corp = Corps.Airforces;
                    }
                    else if (corpInfo == "Marines")
                    {
                        corp = Corps.Marines;
                    }

                    List<IMission> missions = new List<IMission>();

                    string[] missionsInfo = inputArgs[6..inputArgs.Length];

                    for (int i = 0; i < missionsInfo.Length; i += 2)
                    {
                        string codeName = missionsInfo[i];
                        string stateInfo = missionsInfo[i + 1];

                        bool isMissionValid = Enum.TryParse<State>(stateInfo, out State state);

                        if (!isMissionValid)
                        {
                            continue;
                        }

                        State currState = State.inProgress;
                        if (stateInfo == "inProgress")
                        {
                            currState = State.inProgress;
                        }
                        else if (stateInfo == "Finished")
                        {
                            currState = State.Finished;
                        }

                        Mission mission = new Mission(codeName, currState);

                        missions.Add(mission);
                    }

                    currSoldier = 
                        new Commando(id, firstName, lastName, salary, corp, missions);

                    this.soldiers.Add(id, currSoldier);
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(inputArgs[4]);

                    currSoldier = 
                        new Spy(id, firstName, lastName, codeNumber);

                    this.soldiers.Add(id, currSoldier);
                }
            }

            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}
