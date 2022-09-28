using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Palindrome
    {
        static Regex patern = new Regex(@"^([a-zA-Z]");
        public static bool IsPalindrome(string wordPhrase)
        {
            

            if ((!patern.IsMatch(wordPhrase))){
                throw new InvalidAmountArgumentException("The word or phrase is invalid",nameof(wordPhrase));
            }

            char[] arrayWordPhrase = wordPhrase.ToCharArray();

            Array.Reverse(arrayWordPhrase);

            string ReverseWordPhWordPhrase = new string(arrayWordPhrase);

            return wordPhrase.Equals(ReverseWordPhWordPhrase);
        }


    }
}
