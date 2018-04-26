using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Services
{
    public class AuthorizationPolicy : IAuthorizationPolicy
    {
        public AuthorizationPolicy()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            if (null == state)
            {
                state = false;
            }
            bool hasAddedClaims = (bool)state;
            if (hasAddedClaims)
            {
                return true; ;
            }
            IList<Claim> claims = new List<Claim>();
            foreach (ClaimSet claimSet in evaluationContext.ClaimSets)
            {
                foreach (Claim claim in claimSet.FindClaims(ClaimTypes.Name, Rights.PossessProperty))
                {
                    string userName = (string)claim.Resource; 
                }
            }
            evaluationContext.AddClaimSet(this, new DefaultClaimSet(this.Issuer, claims));
            state = true;
            return true;           
        }
        public ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }
        public string Id { get; private set; }
    }
}
