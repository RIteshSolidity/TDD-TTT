using System;

namespace UnitTestConstraints
{

    public interface IForexConvertor {
        int GetConversionRates(int countryCode);
        bool isCountryAvailable(int countryCode);
    }
    public class ForexConvertor : IForexConvertor
    {
        public int GetConversionRates(int countryCode) {
            throw new NotImplementedException("This method is not yet implemented!!");
        }

        public bool isCountryAvailable(int countryCode)
        {
            return true;
        }
    }
}
