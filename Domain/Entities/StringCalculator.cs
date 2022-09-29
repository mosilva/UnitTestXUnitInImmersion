namespace Domain.Entities
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var list = numbers.Split(",");

            var exceedsCount = list.Length > 2;
            var consecutiveCommas = list.Any(x => x == "");
            var nonNumbers = list.Any(x => int.TryParse(x, out _));

            if (exceedsCount || consecutiveCommas || !(nonNumbers))
                throw new ArgumentException(nameof(numbers));

            var sum = list.Sum(x => Convert.ToInt32(x));

            return sum;
        }
    }
}
