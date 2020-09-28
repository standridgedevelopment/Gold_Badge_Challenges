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
    }
}
