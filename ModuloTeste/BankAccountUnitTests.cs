using Domain;
using Domain.Exceptions;

namespace ModuloTeste
{
    public class BankAccountUnitTests
    {
        private decimal _valueValidAmount = 1000;

        [Fact]
        public void Constructor_Initialize_ZeroBalance()
        {
            BankAccount sut = new BankAccount();

            Assert.Equal(Decimal.Zero, sut.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Deposit_InvalidAmount_ShouldThrowInvalidArgumentException(decimal valueInvalidTest)
        {
            BankAccount sut = new BankAccount();

            Action methodTest = () => sut.Deposit(valueInvalidTest);

            Assert.Throws<InvalidAmountArgumentException>(methodTest);           
        }

        [Fact]

        public void Deposit_ValidAmount_ShouldUpdateBalance()
        {
            var sut = new BankAccount();

            sut.Deposit(_valueValidAmount);

            Assert.Equal(_valueValidAmount,sut.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]

        public void WithDraw_InvalidAmount_ShouldThrowInvalidArgumentException(decimal valueInvalidTest)
        {
            var sut = new BankAccount();

            Assert.Throws<InvalidAmountArgumentException>(() => sut.WithDraw(valueInvalidTest));
        }


        [Theory]
        [InlineData(5)]

        public void WithDraw_NotEnoughBalance_ShouldThrowNotEnoughBalanceException(decimal valueInvalidTest)
        {
            var sut = new BankAccount();

            Assert.Throws<NotEnoughBalanceException>(() => sut.WithDraw(valueInvalidTest));
        }


        [Theory]
        [InlineData(10000)]
        public void WithDraw_ValidateAmountWithEnoughBalance_ShouldUpdateBalance(decimal valueInvalidTest)
        {
            var sut = new BankAccount();
            sut.Deposit(valueInvalidTest);

            sut.WithDraw(_valueValidAmount);

            Assert.Equal(valueInvalidTest - _valueValidAmount, sut.Balance);
        }



    }
}