using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestConstraints
{
    public class ForexDealer
    {
        private IForexConvertor _forex;
        public ForexDealer(IForexConvertor _convertor)
        {
            _forex = _convertor;
        }
        public int convertINRtoCountryForex(int countryCode, int inrAmount) {
            if (countryCode > 100)
                throw new InvalidOperationException("country code cannot be above 100!!");

            if (!_forex.isCountryAvailable(countryCode))
                throw new InvalidOperationException("country code not available!! ");

            // ForexConvertor convertor = new ForexConvertor();
            int amount = (inrAmount/ _forex.GetConversionRates(countryCode));
            return amount;

        }
    }
}
