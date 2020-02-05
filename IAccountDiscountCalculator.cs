public interface IAccountDiscountCalculator
{
    decimal ApplyDiscount(decimal price);
}

public class NotRegisteredDiscountCalculator : IAccountDiscountCalculator
{
    public decimal ApplyDiscount(decimal price)
    {
        return price;
    }
}

public class SimpleCustomerDiscountCalculator : IAccountDiscountCalculator
{
    public decimal ApplyDiscount(decimal price)
    {
        return price - (Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS * price);
    }
}

public class ValuableCustomerDiscountCalculator : IAccountDiscountCalculator
{
    public decimal ApplyDiscount(decimal price)
    {
        return price - (Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS * price);
    }
}

public class MostValuableCustomerDiscountCalculator : IAccountDiscountCalculator
{
    public decimal ApplyDiscount(decimal price)
    {
        return price - (Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS * price);
    }
}