public enum AccountStatus
{
    NotRegistered = 1,
    SimpleCustomer = 2,
    ValuableCustomer = 3,
    MostValuableCustomer = 4
}

public static class Constants
{
    public const int MAXIMUM_DISCOUNT_FOR_LOYALTY = 5;
    public const decimal DISCOUNT_FOR_SIMPLE_CUSTOMERS = 0.1m;
    public const decimal DISCOUNT_FOR_VALUABLE_CUSTOMERS = 0.3m;
    public const decimal DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS = 0.5m;
}

public static class PriceExtensions
{
    public static decimal ApplyDiscountForAccountStatus(this decimal price, decimal discountSize)
    {
        return price - (discountSize * price);
    }

    public static decimal ApplyDiscountForTimeOfHavingAccount(this decimal price, int timeOfHavingAccountInYears)
    {
        decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY) ? (decimal)Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY / 100 : (decimal)timeOfHavingAccountInYears / 100;
        return price - (discountForLoyaltyInPercentage * price);
    }
}

public class DiscountManager
{
    private readonly IAccountDiscountCalculatorFactory _factory;
    private readonly ILoyaltyDiscountCalculator _loyaltyDiscountCalculator;

    public DiscountManager(IAccountDiscountCalculatorFactory factory, ILoyaltyDiscountCalculator loyaltyDiscountCalculator)
    {
        _factory = factory;
        _loyaltyDiscountCalculator = loyaltyDiscountCalculator;
    }

    public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
    {
        decimal priceAfterDiscount = 0;
        priceAfterDiscount = _factory.GetAccountDiscountCalculator(accountStatus).ApplyDiscount(price);
        priceAfterDiscount = _loyaltyDiscountCalculator.ApplyDiscount(priceAfterDiscount, timeOfHavingAccountInYears);
        return priceAfterDiscount;
    }
}
