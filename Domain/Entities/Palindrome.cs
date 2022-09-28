using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Palindrome
    {
        Regex patern = new Regex(@"^([a-zA-Z\s]{3,}$)");
        public bool IsPalindrome(string wordPhrase)
        {
            if (!(patern.IsMatch(wordPhrase)))
            {
                throw new InvalidAmountArgumentException("The word or phrase is invalid"
                    , nameof(wordPhrase));
            }

            wordPhrase = wordPhrase.ToLower().Replace(" ", "");

            char[] arrayWordPhrase = wordPhrase.ToCharArray();

            Array.Reverse(arrayWordPhrase);

            string ReverseWordPhWordPhrase = new string(arrayWordPhrase);

            return wordPhrase.Equals(ReverseWordPhWordPhrase);
        }


    }
}
