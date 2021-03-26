using System;

namespace edu21Money
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Money();
            try
            {
                Console.WriteLine("Введите сумму в желаемой валлюте (€, $, ₽)");
                var firstValue = new Money();
                firstValue.value = Console.ReadLine();
                Console.WriteLine("Введите сумму в желаемой валлюте (€, $, ₽)");
                var secondValue = new Money ();
                secondValue.value = Console.ReadLine();

                result = firstValue + secondValue;
                Console.WriteLine($"{result.value} ₽");

                result = firstValue - secondValue;
                Console.WriteLine($"{result.value} ₽");

                Console.WriteLine($"{firstValue > secondValue}");
                Console.WriteLine($"{firstValue < secondValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            Console.ReadKey();
        }
    }

    public static class Сurrencies
    {
        public const decimal Ruble = 1m;
        public const decimal Dollar = 76.1535m;
        public const decimal Euro = 90.0515m;
    }

    public class Money
    {
        private decimal Value;

        public string value
        {
            get => Value.ToString();
            set
            {
                Value = ParseValue(value);
            }
        }

        public static Money operator +(Money firstValue, Money secondValue)
        {
            return new Money { Value = firstValue.Value + secondValue.Value };
        }

        public static Money operator -(Money firstValue, Money secondValue)
        {
            return new Money { Value = firstValue.Value - secondValue.Value };
        }
        public static bool operator >(Money firstValue, Money secondValue)
        {
            return firstValue.Value > secondValue.Value;
        }
        public static bool operator <(Money firstValue, Money secondValue)
        {
            return firstValue.Value < secondValue.Value;
        }

        private static decimal ParseValue(string value)
        {
            var lastSymbol = !string.IsNullOrEmpty(value) ? value.Substring(value.Length - 1) : "";
            value = !string.IsNullOrEmpty(value) ? value.Substring(0, value.Length - 1) : "";

            return lastSymbol switch
            {
                "₽" => decimal.Parse(value),
                "$" => decimal.Parse(value) * Сurrencies.Dollar,
                "€" => decimal.Parse(value) * Сurrencies.Euro,
                _ => throw new Exception("Неизвестная ошибка"),
            };
        }
    }
}
