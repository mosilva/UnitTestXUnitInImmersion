using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class PalindromeUnitTests
    {
        private Palindrome _sut;

        public PalindromeUnitTests()
        {
            _sut = new Palindrome();
        }

        [Theory]
        [InlineData("1235")]
        [InlineData("A123na")]
        [InlineData("da")]
        [InlineData("ééé")]
        [InlineData("   ")]

        public void IsPalindrome_InvalidWordOrPhrase_ShouldThrowInvalidArgumentException(string wordPhrase)
        {
            Assert.Throws<InvalidAmountArgumentException>(() => _sut.IsPalindrome(wordPhrase));
        }

        [Theory]
        [InlineData("house")]
        [InlineData("My favourite color is blue")]

        public void IsPalindrome_NotPalindrome_ReturnFalse(string wordPhrase)
        {
            Assert.False(_sut.IsPalindrome(wordPhrase));
        }

        [Theory]
        [InlineData("civic")]
        [InlineData("arara")]
        [InlineData(" civic")]

        public void IsPalindrome_CorrectPalindromeWord_ReturnTrue(string wordPhrase)
        {
            Assert.True(_sut.IsPalindrome(wordPhrase));
        }

        [Theory]
        [InlineData("Do geese see God")]
        [InlineData("a mae te ama")]

        public void IsPalindrome_CorrectPalindromePhrase_ReturnTrue(string wordPhrase)
        {
            Assert.True(_sut.IsPalindrome(wordPhrase));
        }

    }
}
