using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class ClaimsRepo
    {
        private readonly Queue<Claim> _claimDirectory = new Queue<Claim>();

        public Queue<Claim> GetDirectory()
        {
            return _claimDirectory;
        }

        public void AddClaim(Claim claim)
        {
            _claimDirectory.Enqueue(claim);
        }

        public Claim GetClaimByID(int claimId)
        {
            foreach (Claim claim in _claimDirectory)
            {
                if (claim.ID == claimId)
                {
                    return claim;
                }
            }
            return null;
        }

        public bool UpdateClaim(Claim updatedClaim, int originalClaimId)
        {
            Claim claim = GetClaimByID(originalClaimId);
            if (claim != null)
            {
                claim.ID = updatedClaim.ID;
                claim.TypeOfClaim = updatedClaim.TypeOfClaim;
                claim.Description = updatedClaim.Description;
                claim.Amount = updatedClaim.Amount;
                claim.IncidentDate = updatedClaim.IncidentDate;
                claim.ClaimDate = updatedClaim.ClaimDate;
                return true;
            }
            return false;
        }
    }
}
