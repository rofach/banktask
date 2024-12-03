using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public class Operations
{
    static public void AddFromTo(ICard card1, ICard card2, double value)
    {
        if (value > card1.Balance)
        {
            MessageBox.Show("недостатньо коштів");
        }
        else if (card1.Bank == card2.Bank)
        {
            
            card1.Withdraw(card1.SendCommission(value));
            card2.Add(card2.ReceiveCommission(value));
        }
        else
        {
            card1.Withdraw(card1.InterBankSendCommsisson(value));
            card2.Add(card2.InterBankReceiveCommsisson(value));
        }
    }

    static public void AddBal(ICard card, double value)
    {
        card.Add(value);
    }

    static public void GetCredit(ICard card, double value)
    {
        if (value <= card.CreditBalance)
        {
            card.CreditBalance -= value;
        }
        else
        {
            MessageBox.Show("кредит перевищує ліміт");
        }
    }
    static public void AddToCreditBal(ICard card, double value)
    {
        if (card.CreditBalance < card.CreditLimit)
        {
            card.CreditBalance += card.CreditCom(value);
            double diff = card.CreditBalance - card.CreditLimit;
            if (diff > 0)
            {
                card.Add(diff);
                card.CreditBalance = card.CreditLimit;
            }
        }
    }

}

