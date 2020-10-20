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
        public Claim(int id, ClaimType typeOfClaim, string description, double amount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ID = id;
            TypeOfClaim = typeOfClaim;
            Description = description;
            Amount = amount;
            IncidentDate = dateOfIncident;
            ClaimDate = dateOfClaim;
        }

        public int ID { get; set; }

        public enum ClaimType
        {
            Car, Home, Theft
        }
        public ClaimType TypeOfClaim { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public DateTime IncidentDate { get; set; }

        public DateTime ClaimDate { get; set; }

        public bool IsValid
        {
            get
            {
                TimeSpan days = ClaimDate - IncidentDate;
                return days.TotalDays <= 30;
            }
        }


    }
}
