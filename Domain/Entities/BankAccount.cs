using Domain.Exceptions;
using Domain.InfraData;

namespace Domain.Entities
{
    public class BankAccount
    {
        private readonly IBankAccountRespository _repository;
        public decimal Balance => _balance;

        private decimal _balance;

        public BankAccount(IBankAccountRespository respository, decimal initialBalance = Decimal.Zero)
        {
            _balance = initialBalance;
            _repository = respository;
        }


        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountArgumentException("Valor informado não é valido", nameof(amount));
            }

            _balance += amount;
            _repository.UpdateAccount(this);
        }


        public void WithDraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountArgumentException("Valor informado não é valido", nameof(amount));
            }

            if (amount > _balance)
            {
                throw new NotEnoughBalanceException("Valor informado não é valido", nameof(amount));
            }


            _balance -= amount;
            _repository.UpdateAccount(this);

        }



    }
}