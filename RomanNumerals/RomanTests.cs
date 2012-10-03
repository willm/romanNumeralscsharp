using NUnit.Framework;

namespace RomanNumerals
{
    [TestFixture]
    public class RomanTests
    {
        private Roman _roman = new Roman();

        [Test]
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(15, "XV")]
        public void numbers_convert_as_expected(int number, string expectedNumeral)
        {
            var numeral = _roman.Convert(number);

            Assert.That(numeral, Is.EqualTo(expectedNumeral));
        }
    }
    public class Number
    {
        public int Arabic { get; set; }
        public string Roman { get; set; }
    }

    public class Roman
    {
        private int _number = 0;
        private readonly Number _five = new Number{Arabic = 5, Roman = "V"};
        private readonly Number _one = new Number{Arabic = 1, Roman = "I"};
        private readonly Number _ten = new Number{Arabic = 10, Roman = "X"};

        public string Convert(int initialNumber)
        {
            _number = initialNumber;
            var numeral = "";
            for (var i = 0; i < initialNumber; i++)
            {
                numeral = numeral + SetBaseLetter(_one, _five);
                numeral = numeral + SetBaseLetter(_one, _ten);
                numeral = numeral + SetBaseLetter(_five, _ten);

                if (_number < 4 &&  _number != 0)
                {
                    numeral = numeral + "I";
                }
            }
            return numeral;
        }

        private string SetBaseLetter(Number prefix, Number baseNumber)
        {
            if (_number == baseNumber.Arabic - prefix.Arabic)
            {
                _number = _number - (baseNumber.Arabic - prefix.Arabic);
                return prefix.Roman + baseNumber.Roman;
            }
            if (_number == baseNumber.Arabic)
            {
                _number = _number - baseNumber.Arabic;
                return baseNumber.Roman;
            }
            if (_number == baseNumber.Arabic + prefix.Arabic)
            {
                _number = _number - (baseNumber.Arabic + prefix.Arabic); 
                return baseNumber.Roman + prefix.Roman;
            }
            return "";
        }
    }

}
