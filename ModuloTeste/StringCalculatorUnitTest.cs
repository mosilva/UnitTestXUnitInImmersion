using Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class StringCalculatorUnitTest
    {

        [Theory]
        [InlineData("")]
        [InlineData(null)]

        public void Add_WhenStringIsEmptyOrNull_ShouldBeReturnZero(string numbers)
        {
            var sut = new StringCalculator();
            var result = sut.Add(numbers);

            result.Should().Be(0);

        }

        [Theory]
        [InlineData("1,2,3")]
        [InlineData("1,,1")]

        public void Add_InvalidInputString_ShouldBeReturnZero(string numbers)
        {
            var sut = new StringCalculator();

            Action add = () => sut.Add(numbers);

            add.Should().Throw<ArgumentException>().WithMessage("*numbers");

        }

        [Fact]
        public void Add_WhenValidInput_ReturnSum()
        {
            var sut = new StringCalculator();

            var result = sut.Add("1,3");

            result.Should().Be(4);
        }


        #region FirstMethodsNoRefactoring
        /*
        [Fact]
        public void Add_WhenEmptyString_ShouldBeReturnZero()
        {
            var sut = new StringCalculator();
            var result = sut.Add("");

            result.Should().Be(0);

        }

        [Fact]
        public void Add_WhenStringIsNull_ShouldBeReturnZero()
        {
            var sut = new StringCalculator();
            var result = sut.Add(null);

            result.Should().Be(0);

        }

        [Fact]
        public void Add_WhenMoreThanTwoNumbers_ShouldThrowArgumentException()
        {
            var sut = new StringCalculator();

            Action add = () => sut.Add("1,2,3");

            add.Should().Throw<ArgumentException>().WithMessage("*numbers");
        }



        [Fact]
        public void Add_WhenConsecutiveCommas_ShouldThrowArgumentException()
        {
            var sut = new StringCalculator();

            Action add = () => sut.Add("1,,1");

            add.Should().Throw<ArgumentException>().WithMessage("*numbers");
        }


        [Fact]
        public void Add_WhenContainsNonNumber_ShouldThrowArgumentException()
        {
            var sut = new StringCalculator();

            Action add = () => sut.Add("1,a");

            add.Should().Throw<ArgumentException>().WithMessage("*numbers");
        }
        */
        #endregion


    }
}
