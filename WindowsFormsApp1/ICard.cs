using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public interface ICard
{
    string CardNumber { get; }
    string Bank { get; }
    double Balance { get; }
    double CreditBalance { get; set; }
    double CreditLimit { get; set; }
    double SendCommission(double opAmount);
    double InterBankSendCommsisson(double opAmount);
    double ReceiveCommission(double opAmount);
    double InterBankReceiveCommsisson(double opAmount);
    double CreditCom(double value);

    void Add(double value);
    void Withdraw(double value);


}



