// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;

var sale = new SaleWithTax(25, 1.16m);
sale.Total = 15;

var message = sale.GetInfo();
Console.WriteLine(message);
//Sale sale = new();


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
        return "El total es" + Total + "El impuesto es " + Tax;
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