public enum AccountStatus
{
    NotRegistered = 1,
    SimpleCustomer = 2,
    ValuableCustomer = 3,
    MostValuableCustomer = 4
}

public class DiscountManager
{
    public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
    {
        decimal priceAfterDiscount = 0;
        decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > 5) ? (decimal)5 / 100 : (decimal)timeOfHavingAccountInYears / 100;
        switch (accountStatus)
        {
            case AccountStatus.NotRegistered:
                priceAfterDiscount = price;
                break;
            case AccountStatus.SimpleCustomer:
                priceAfterDiscount = (price - (0.1m * price));
                priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                break;
            case AccountStatus.ValuableCustomer:
                priceAfterDiscount = (price - (0.3m * price));
                priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                break;
            case AccountStatus.MostValuableCustomer:
                priceAfterDiscount = (price - (0.5m * price));
                priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                break;
            default:
                throw new NotImplementedException();
        }
        return priceAfterDiscount;
    }
}
