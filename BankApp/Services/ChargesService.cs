using BankApp.Views;
using System;

namespace BankApp.BankStaff
{
    internal class ChargesService
    {
        private static decimal rtgsChargeSameBank = 0.0m;
        private static decimal impsChargeSameBank = 0.05m;
        private static decimal rtgsChargeOtherBank = 0.02m;
        private static decimal impsChargeOtherBank = 0.06m;

        public static void SetServiceChargeSameBank()
        {
            BankView.DisplayRTGSChargeUpdateSameBank();
            rtgsChargeSameBank = decimal.Parse(Console.ReadLine());

            BankView.DisplayIMPSChargeUpdateSameBank();
            impsChargeSameBank = decimal.Parse(Console.ReadLine());

            BankView.DisplayChargesUpdated();
        }

        public static void SetServiceChargeOtherBank()
        {
            BankView.DisplayRTGSChargeUpdateOtherBank();
            rtgsChargeOtherBank = decimal.Parse(Console.ReadLine());

            BankView.DisplayIMPSChargeUpdateOtherBank();
            impsChargeOtherBank = decimal.Parse(Console.ReadLine());

            BankView.DisplayChargesUpdated();
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
