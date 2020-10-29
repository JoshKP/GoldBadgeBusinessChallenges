using KomodoInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KomodoInsurance.Claim;

namespace KomodoInsuranceUI
{
    public class InsuranceUI
    {
        private bool _isRunning = true;
        private readonly ClaimsRepo _claimRepo = new ClaimsRepo();

        public void Start()
        {
            SeedClaimList();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("Menu:\n" +
                "1  See all claims\n" +
                "2  Take care of next claim\n" +
                "3  Enter a new claim\n" +
                "4  Modify an existing claim\n" +
                "5  Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    DisplayAllClaims();
                    break;
                case "2":
                    TakeCareOfNextClaim();
                    break;
                case "3":
                    CreateNewClaim();
                    break;
                case "4":
                    UpdateExistingClaim();
                    break;
                case "5":
                    _isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
            Console.WriteLine("Press a key to return to menu");
            Console.ReadKey();
        }

        private void DisplayAllClaims()
        {
            Queue<Claim> queueOfClaims = _claimRepo.GetDirectory();

            foreach (Claim claim in queueOfClaims)
            {
                DisplayClaim(claim);
            }
        }

        public void DisplayClaim(Claim claim)
        {
            Console.WriteLine($"\n {"ClaimID",-30}{"Type",-30}{"Description",-30}{"Amount",-30}{"Date Of Incident",-30}{"Date Of Claim",-30}{"Is Valid", -30}\n" +
                $"{claim.ID,-30}{claim.TypeOfClaim,-30}{claim.Description,-30}{claim.Amount,-30}{claim.IncidentDate,-30}{claim.ClaimDate,-30}{(claim.IsValid ? "Yes" : "No"),-30}\n");
        }

        private void CreateNewClaim()
        {
            Console.WriteLine("Enter a claim ID:  ");
            string id = Console.ReadLine();

            ClaimType claimType = GetClaimType();

            Console.WriteLine("Claim description:  ");
            string description = Console.ReadLine();

            Console.WriteLine("Dollar amount of claim:  ");
            var costOfClaim = Console.ReadLine();

            double amountNumber;
            while (!double.TryParse(costOfClaim, out amountNumber))
            {
                Console.WriteLine("Invalid number try again");
                costOfClaim = Console.ReadLine();
            }
            double claimAmount = amountNumber;

            Console.WriteLine("When did incident occur? (YYYY/MM/DD)");
            string incidentDate = Console.ReadLine();

            Console.WriteLine("When was claim made? (YYYY/MM/DD)");
            string claimDate = Console.ReadLine();

            Claim newClaim = new Claim(id, claimType, description, claimAmount, incidentDate, claimDate);

            _claimRepo.AddClaim(newClaim);
        }

        private ClaimType GetClaimType()
        {
            Console.WriteLine("Select type of claim:  \n" +
                "1  Car\n" +
                "2  Home\n" +
                "3  Theft\n");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return ClaimType.Car;
                    case "2":
                        return ClaimType.Home;
                    case "3":
                        return ClaimType.Theft;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
                Console.WriteLine("Invalid selection.  Please try again.");
            }
        }

        private void UpdateExistingClaim()
        {
            Console.WriteLine("Enter the ID of the claim to be updated");
            string oldClaimId = Console.ReadLine();

            Console.WriteLine("Enter a new claim ID:  ");
            string id = Console.ReadLine();

            ClaimType claimType = GetClaimType();

            Console.WriteLine("Claim description:  ");
            string description = Console.ReadLine();

            Console.WriteLine("Dollar amount of claim:  ");
            var costOfClaim = Console.ReadLine();
            double amountNumber;
            while (!double.TryParse(costOfClaim, out amountNumber))
            {
                Console.WriteLine("Invalid number try again");
                costOfClaim = Console.ReadLine();
            }
            double claimAmount = amountNumber;

            Console.WriteLine("When did incident occur? (YYYY/MM/DD)");
            string incidentDate = Console.ReadLine();

            Console.WriteLine("When was claim made? (YYYY/MM/DD)");
            string claimDate = Console.ReadLine();

            Claim updatedClaim = new Claim(id, claimType, description, claimAmount, incidentDate, claimDate);

            bool wasUpdated = _claimRepo.UpdateClaim(updatedClaim, oldClaimId);
            if (wasUpdated)
            {
                Console.WriteLine("Claim was updated");
            }
            else
            {
                Console.WriteLine("Could not update content");
            }
        }

        private void TakeCareOfNextClaim()
        {
            Queue<Claim> claimQueue = _claimRepo.GetDirectory();
            bool claimExists = true;

            while (claimExists)
            {
                if (claimQueue.Count > 0)
                {
                    var claim = claimQueue.Peek();
                    DisplayClaim(claim);
                }

            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            string userInput = Console.ReadLine();

            if (userInput == "y")
            {
                claimQueue.Dequeue();
            }
            else claimExists = false;
            }
        }

        private void SeedClaimList()
        {
            Claim firstClaim = new Claim("01", ClaimType.Car, "Casey was texting", 10999.99, "2020/04/05", "2020/04/25");
            Claim secondClaim = new Claim("02", ClaimType.Theft, "Josh was texting", 8999.99, "2020/07/28", "2020/08/19");
            Claim thirdClaim = new Claim("03", ClaimType.Home, "Kevin was texting", 5999.99, "2020/06/14", "2020/08/19");
            Claim fourthClaim = new Claim("04", ClaimType.Car, "Michael was texting", 3999.99, "2020/05/29", "2020/08/19");

            _claimRepo.AddClaim(firstClaim);
            _claimRepo.AddClaim(secondClaim);
            _claimRepo.AddClaim(thirdClaim);
            _claimRepo.AddClaim(fourthClaim);
        }
    }
}
