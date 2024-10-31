// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;

   Console.WriteLine("Enter the current tax");
string currentTax = Console.ReadLine();
Console.WriteLine("Current tax is " +  currentTax+ ".");


var sale = new SaleWithTax(25, decimal.Parse(currentTax));
//Sale sale = new();
sale.Total = 15 + decimal.Parse(currentTax);

var message = sale.GetInfo();
Console.WriteLine(message);

class SaleWithTax : Sale
{
    public decimal Tax { get; set; }
    public SaleWithTax(decimal total, decimal tax) : base(total)
    {
        Tax = tax;
        GetInfo();
    }

    public override string GetInfo()
    {
        return "El total es " + Total + ", y el impuesto es " + Tax;
    }

    public string GetInfo(string message)
    {
        return message;
    }

    public string GetInfo(int someNum)
    {
        return someNum.ToString();
    }
}

class Sale
{
    public decimal Total { get; set; }

    private decimal _some;
    protected string _name;
    public Sale(decimal total)
    {
        Total = total;
        _some = 8;
        _name = string.Empty;
    }

    public virtual string GetInfo()
    {
        return "El total es " + Total;
    }
}
