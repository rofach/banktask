using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Oschad : ICard
{
    private string cardNumber;
    private string bankName = "oschad";
    private double balance;
    private double creditBalance = 50000;
    private double creditLimit = 50000;
    public string CardNumber
    {
        get => cardNumber;
    }

    public string Bank
    {
        get => bankName;
    }

    public double Balance
    {
        get => balance;
    }

    public double CreditBalance
    {
        get => creditBalance;
        set => creditBalance = value;
    }
    public double CreditLimit
    {
        get => creditLimit;
        set => creditLimit = value;
    }

    public Oschad(string cardNumber)
    {
        this.cardNumber = cardNumber;
    }

    public double SendCommission(double opAmount)
    {
        return opAmount * 1.00;
    }

    public double InterBankSendCommsisson(double opAmount)
    {
        return opAmount * 1.04;
    }

    public double ReceiveCommission(double opAmount)
    {
        return opAmount * 1.00;
    }
    public double InterBankReceiveCommsisson(double opAmount)
    {
        return opAmount * 0.98;
    }
    public double CreditCom(double value)
    {
        return value * 0.9;
    }

    public void Add(double value)
    {
        balance += value;
    }

    public void Withdraw(double value)
    {
        balance -= value;
    }
}

