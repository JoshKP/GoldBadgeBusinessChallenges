using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class Claim
    {
        public Claim() { }
        public Claim(string id, ClaimType typeOfClaim, string description, double amount, string dateOfIncident, string dateOfClaim)
        {
            ID = id;
            TypeOfClaim = typeOfClaim;
            Description = description;
            Amount = amount;
            IncidentDate = dateOfIncident;
            ClaimDate = dateOfClaim;
        }

        public string ID { get; set; }

        public enum ClaimType
        {
            Car, Home, Theft
        }
        public ClaimType TypeOfClaim { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public string IncidentDate { get; set; }

        public string ClaimDate { get; set; }

        public bool IsValid
        {
            get
            {
                TimeSpan days = DateTime.Parse(ClaimDate) - DateTime.Parse(IncidentDate);
                return days.TotalDays <= 30;
            }
        }


    }
}
