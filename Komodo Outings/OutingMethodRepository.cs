using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Outings
{
    class OutingMethodRepository
    {
        protected readonly List<Outing> _outingList = new List<Outing>();

        public bool AddOuting(Outing outing)
        {
            int _startingCount = _outingList.Count;
            _outingList.Add(outing);
            bool wasAdded = (_outingList.Count > _startingCount) ? true : false;
            return wasAdded;
        }

        public List<Outing> GetOutings()
        {
            return _outingList;
        }
    }
}
