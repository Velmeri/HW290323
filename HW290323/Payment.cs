using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW290323
{
    public class Receiver
    {
        bool BankTransfer;
        bool MoneyTransfer;
        bool PayPalTransfer;

        public Receiver(bool bt, bool mt, bool ppt)
        {
            BankTransfer = bt;
            MoneyTransfer = mt;
            PayPalTransfer = ppt;
        }

        public bool GetBankTransfer()
        {
            return BankTransfer;
        }

        public void SetBankTransfer(bool bankTransfer)
        {
            BankTransfer = bankTransfer;
        }

        public bool GetMoneyTransfer()
        {
            return MoneyTransfer;
        }

        public void SetMoneyTransfer(bool moneyTransfer)
        {
            MoneyTransfer = moneyTransfer;
        }

        public bool GetPayPalTransfer()
        {
            return PayPalTransfer;
        }

        public void SetPayPalTransfer(bool payPalTransfer)
        {
            PayPalTransfer = payPalTransfer;
        }
    }

    public abstract class PaymentHandler
    {
        protected PaymentHandler Successor;

        public PaymentHandler GetHandler()
        {
            return Successor;
        }

        public void SetHandler(PaymentHandler successor)
        {
            Successor = successor;
        }

        public abstract void Handle(Receiver receiver);
    }

    public class BankPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.GetBankTransfer())
            {
                Console.WriteLine("Bank transfer");
            }
            else if (Successor != null)
            {
                Successor.Handle(receiver);
            }
        }
    }

    public class MoneyPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.GetMoneyTransfer())
            {
                Console.WriteLine("Transfer through money transfer systems");
            }
            else if (Successor != null)
            {
                Successor.Handle(receiver);
            }
        }
    }

    public class PayPalPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.GetPayPalTransfer())
            {
                Console.WriteLine("Transfer via PayPal");
            }
            else if (Successor != null)
            {
                Successor.Handle(receiver);
            }
        }
    }
}
