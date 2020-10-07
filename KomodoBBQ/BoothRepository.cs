using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBBQ
{
    class BoothRepository
    {
        protected readonly List<Booths> _partyDirectory = new List<Booths>();
        public bool AddParty(Booths party)
        {
            int _startingCount = _partyDirectory.Count;
            _partyDirectory.Add(party);
            bool wasAdded = (_partyDirectory.Count > _startingCount) ? true : false;
            return wasAdded;
        }
        public List<Booths> GetParties()
        {
            return _partyDirectory;
        }
        public Booths GetPartyByDate(DateTime dateOfParty)
        {
            foreach (Booths partyByDate in _partyDirectory)
            {
                if (partyByDate.DateOfParty == dateOfParty)
                {
                    return partyByDate;
                }

            }
            return null;
        }
        public bool DeleteParty(Booths existingParty)
        {
            bool deleteResult = _partyDirectory.Remove(existingParty);
            return deleteResult;
        }
    }
}
