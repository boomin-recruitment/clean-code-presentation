public class DiscountManager
{
  public decimal ApplyDiscount(decimal price, int accountStatus, int timeOfHavingAccountInYears)
  {
    decimal priceAfterDiscount = 0;
    decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > 5) ? (decimal)5/100 : (decimal)timeOfHavingAccountInYears/100; 
    if (accountStatus == 1)
    {
      priceAfterDiscount = price;
    }
    else if (accountStatus == 2)
    {
      priceAfterDiscount = (price - (0.1m * price)) - (discountForLoyaltyInPercentage * (price - (0.1m * price)));
    }
    else if (accountStatus == 3)
    {
      priceAfterDiscount = (0.7m * price) - (discountForLoyaltyInPercentage * (0.7m * price));
    }
    else if (accountStatus == 4)
    {
      priceAfterDiscount = (price - (0.5m * price)) - (discountForLoyaltyInPercentage * (price - (0.5m * price)));
    }
 
    return priceAfterDiscount;
  }
}
