using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string name;
        private int numberOfLaps;
        private readonly List<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
            this.pilots = new List<IPilot>();
        }

        public string RaceName {
            get
            {
                return this.name;
            }
            private set
            { 
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }

                this.name = value;
            }
        }

        public int NumberOfLaps {
            get
            {
                return this.numberOfLaps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }

                this.numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots
            => this.pilots.AsReadOnly();

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder result = new StringBuilder();
            string text = string.Empty;

            if (TookPlace)
            {
                text = "Yes";
            }
            else
            {
                text = "No";
            }

            result.AppendLine($"The {RaceName} race has:");
            result.AppendLine($"Participants: {Pilots.Count}");
            result.AppendLine($"Number of laps: {NumberOfLaps}");
            result.AppendLine($"Took place: {text}");

            return result.ToString().TrimEnd();
        }
    }
}
