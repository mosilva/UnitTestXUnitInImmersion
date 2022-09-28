using Domain.Entities;
using Domain.Exceptions;
using Domain.InfraData;
using Moq;

namespace ModuloTeste
{
    public class BankAccountUnitTests
    {
        private BankAccount _sut;
        private MockRepository _mockRepository;
        private Mock<IBankAccountRespository> _bankAccountRepositoryMock;
        private decimal _valueValidAmount = 1000;
        
        public BankAccountUnitTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _bankAccountRepositoryMock = _mockRepository.Create<IBankAccountRespository>();
            _bankAccountRepositoryMock
                .Setup(x => x.UpdateAccount(It.IsAny<BankAccount>()))
                .Verifiable();

            _sut = new BankAccount(_bankAccountRepositoryMock.Object);
        }

        [Fact]
        public void Constructor_Initialize_ZeroBalance()
        {

            Assert.Equal(Decimal.Zero, _sut.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Deposit_InvalidAmount_ShouldThrowInvalidArgumentException(decimal valueInvalidTest)
        {
            Action methodTest = () => _sut.Deposit(valueInvalidTest);

            Assert.Throws<InvalidAmountArgumentException>(methodTest);           
        }

        [Fact]

        public void Deposit_ValidAmount_ShouldUpdateBalance()
        {

            _sut.Deposit(_valueValidAmount);

            Assert.Equal(_valueValidAmount,_sut.Balance);

            _bankAccountRepositoryMock.Verify(x => x.UpdateAccount(It.IsAny<BankAccount>()),Times.Once());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]

        public void WithDraw_InvalidAmount_ShouldThrowInvalidArgumentException(decimal valueInvalidTest)
        {

            Assert.Throws<InvalidAmountArgumentException>(() => _sut.WithDraw(valueInvalidTest));
        }


        [Theory]
        [InlineData(5)]

        public void WithDraw_NotEnoughBalance_ShouldThrowNotEnoughBalanceException(decimal valueInvalidTest)
        {

            Assert.Throws<NotEnoughBalanceException>(() => _sut.WithDraw(valueInvalidTest));
        }


        [Theory]
        [InlineData(10000)]
        public void WithDraw_ValidateAmountWithEnoughBalance_ShouldUpdateBalance(decimal valueInvalidTest)
        {

            _sut.Deposit(valueInvalidTest);

            _sut.WithDraw(_valueValidAmount);

            Assert.Equal(valueInvalidTest - _valueValidAmount, _sut.Balance);

            _bankAccountRepositoryMock.Verify(x => x.UpdateAccount(It.IsAny<BankAccount>()), Times.Exactly(2));


        }



    }
}