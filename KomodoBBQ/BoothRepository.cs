using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBBQ
{
    class BoothRepository
    {
        protected readonly List<Party> _partyDirectory = new List<Party>();
        public bool AddParty(Party party)
        {
            int _startingCount = _partyDirectory.Count;
            _partyDirectory.Add(party);
            bool wasAdded = (_partyDirectory.Count > _startingCount) ? true : false;
            return wasAdded;
        }
        public List<Party> GetParties()
        {
            return _partyDirectory;
        }
        public bool DeleteParty(Party existingParty)
        {
            bool deleteResult = _partyDirectory.Remove(existingParty);
            return deleteResult;
        }
    }
}
