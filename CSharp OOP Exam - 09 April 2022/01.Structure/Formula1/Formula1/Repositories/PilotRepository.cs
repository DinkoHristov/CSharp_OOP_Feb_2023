using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IPilotRepository
    {
        private readonly List<IPilot> models;

        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models
            => this.models;

        public void Add(IPilot model)
        {
            this.models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            IPilot pilot = this.models.FirstOrDefault(p => p.FullName == name);

            if (pilot != null)
            {
                return pilot;
            }

            return null;
        }

        public bool Remove(IPilot model)
        {
            IPilot pilot = this.models.FirstOrDefault(p => p == model);

            if (pilot != null)
            {
                this.models.Remove(pilot);

                return true;
            }

            return false;
        }
    }
}
