using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    class ClaimsRepository
    {
        protected readonly Queue<Claims> _claimsList = new Queue<Claims>();

        public bool AddClaimToQueue(Claims claim)
        {
            int _startingCount = _claimsList.Count;
            _claimsList.Enqueue(claim);
            bool wasAdded = (_claimsList.Count > _startingCount) ? true : false;
            return wasAdded;
        }

        public Queue<Claims> GetClaims()
        {
            return _claimsList;
        }
        public bool PeekClaim()
        {
            Queue<Claims> _currentClaimsList = GetClaims();
            Claims firstClaim = _currentClaimsList.Peek();
            firstClaim.printProps();
            bool wasPeeked = true;
            return wasPeeked;
        }
        public bool DequeueClaim()
        {
        Queue<Claims> _currentClaimsList = GetClaims();
            int initialQueueCount = _claimsList.Count();
            _claimsList.Dequeue();
            bool wasRemoved = false;
            if (initialQueueCount > _claimsList.Count)
            {
                wasRemoved = true;
            }
            return wasRemoved;

        }
    }
}
