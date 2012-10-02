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
        public void numbers_convert_as_expected(int number, string expectedNumeral)
        {
            var numeral = _roman.Convert(number);

            Assert.That(numeral, Is.EqualTo(expectedNumeral));
        }
    }


    public class Roman
    {
        private int _number = 0;

        // string[] _baseLetters = new string[]{"V", "X"};
        public string Convert(int number)
        {
            _number = number;
            var numeral = "";
            for (var i = 0; i < number; i++)
            {
                numeral = numeral + SetBaseLetter("V", 5);
                //numeral = numeral + SetBaseLetter("X", 10);

                if (_number < 4 &&  _number != 0)
                {
                    numeral = numeral + "I";
                }
                if (_number == 9)
                {
                    numeral = "IX";
                }
                if (_number == 10)
                {
                    numeral = "X";
                }
            }
            return numeral;
        }

        private string SetBaseLetter(string baseLetter, int baseNumber)
        {
            if (_number == baseNumber - 1)
            {
                _number = _number - (baseNumber - 1);
                return "I" + baseLetter;
            }
            if (_number == baseNumber)
            {
                _number = _number - baseNumber;
                return baseLetter;
            }
            if (_number == baseNumber+1)
            {
                _number = _number - (baseNumber + 1); 
                return baseLetter + "I";
            }
             return "";
        }
    }

}
