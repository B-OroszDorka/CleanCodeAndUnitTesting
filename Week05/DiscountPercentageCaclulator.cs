namespace Week05
{
    internal class DiscountPercentageCaclulator
    {
        private int CalculateDiscountPercentageGiven(string level)
        {
            var discountPercentage = 0;
            switch (level)
            {
                case "standard":
                    discountPercentage = 5;
                    break;
                case "silver":
                    discountPercentage = 10;
                    break;
                case "gold":
                    discountPercentage = 15;
                    break;
                default:
                    discountPercentage = 0;
                    break;
            }

            if (level == "gold")
            {
                // Additional discount for gold members
                discountPercentage += 5;
            }
            return discountPercentage;

        }

        private int CalculateDiscountPercentageRefactored(string level)
        {
            var discountMapping = new Dictionary<string, int>()
            {
                { "standard", 5 },
                { "silver", 10 },
                { "gold", 15 }
            };

            var additionalDiscount = (level == "gold") ? 5 : 0;

            if (discountMapping.TryGetValue(level, out var discountPercentage))
            {
                return discountPercentage + additionalDiscount;
            }

            return 0;
        }
    }
}
