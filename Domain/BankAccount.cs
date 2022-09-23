using Domain.Exceptions;

namespace Domain
{
    public class BankAccount
    {
        public decimal Balance => _balance;

        private decimal _balance;

        public BankAccount()
        {
            _balance = Decimal.Zero;
        }


        public void Deposit(decimal amount)
        {
            if(amount <= 0)
            {
                throw new InvalidAmountArgumentException("Valor informado não é valido",nameof(amount));
            }

            _balance += amount;
        }


        public void WithDraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountArgumentException("Valor informado não é valido", nameof(amount));
            }

            if (amount > _balance )
            {
                throw new NotEnoughBalanceException("Valor informado não é valido", nameof(amount));
            }


            _balance -= amount;
        }



    }
}