// Match interfaces of different classes

public interface IPaypalPayment
{
    void MakePayment(decimal amount);
}

public interface IStripePayment
{
    void ProcessPayment(decimal amount);
}

public class PaypalPayment : IPaypalPayment
{
    public void MakePayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} using PayPal.");
    }
}

public class StripePayment : IStripePayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} using Stripe.");
    }
}

public interface IPaymentAdapter
{
    void Pay(decimal amount);
}

public class PaypalAdapter : IPaymentAdapter
{
    private readonly IPaypalPayment _paypalPayment;
    public PaypalAdapter(PaypalPayment paypalPayment)
    {
        _paypalPayment = paypalPayment;
    }
    public void Pay(decimal amount)
    {
        _paypalPayment.MakePayment(amount);
    }
}

public class StripeAdapter : IPaymentAdapter
{
    private readonly IStripePayment _stripePayment;
    public StripeAdapter(StripePayment stripePayment)
    {
        _stripePayment = stripePayment;
    }
    public void Pay(decimal amount)
    {
        _stripePayment.ProcessPayment(amount);
    }
}

public class  Program
{
    public static void Main(string[] args)
    {
        IPaymentAdapter paypalAdapter = new PaypalAdapter(new PaypalPayment());
        paypalAdapter.Pay(100.00m);
        IPaymentAdapter stripeAdapter = new StripeAdapter(new StripePayment());
        stripeAdapter.Pay(200.00m);
    }
}