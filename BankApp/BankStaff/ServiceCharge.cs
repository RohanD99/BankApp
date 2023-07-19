using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.BankStaff
{
    internal class ServiceCharge
    {
        private static decimal rtgsChargeSameBank = 0.0m;
        private static decimal impsChargeSameBank = 0.05m;
        private static decimal rtgsChargeOtherBank = 0.02m;
        private static decimal impsChargeOtherBank = 0.06m;

        public static void SetServiceChargeSameBank()
        {
            Console.WriteLine("Enter the service charge for RTGS (in percentage) for same bank:");
            rtgsChargeSameBank = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the service charge for IMPS (in percentage) for same bank:");
            impsChargeSameBank = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Service charges updated successfully for same bank.");
        }

        public static void SetServiceChargeOtherBank()
        {
            Console.WriteLine("Enter the service charge for RTGS (in percentage) for other bank:");
            rtgsChargeOtherBank = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the service charge for IMPS (in percentage) for other bank:");
            impsChargeOtherBank = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Service charges updated successfully for other bank.");
        }

        public static decimal GetRtgsChargeSameBank()
        {
            return rtgsChargeSameBank;
        }

        public static decimal GetImpsChargeSameBank()
        {
            return impsChargeSameBank;
        }

        public static decimal GetRtgsChargeOtherBank()
        {
            return rtgsChargeOtherBank;
        }

        public static decimal GetImpsChargeOtherBank()
        {
            return impsChargeOtherBank;
        }
    }
}
