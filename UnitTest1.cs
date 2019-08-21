using System;
using Xunit;
using UnitTestConstraints;
using Moq;

namespace MoqExamples
{
    public class TestForexDealer
    {
        [Fact]
        public void ForexDealer_correctCountryCode_success()
        {
            //ForexConvertor convertor = new ForexConvertor();
            Mock<IForexConvertor> convertor = new Mock<IForexConvertor>();
            convertor.Setup(x => x.isCountryAvailable( It.IsInRange<int>(10,20, Range.Inclusive)  )   ).Returns(true);
            convertor.Setup(x => x.GetConversionRates(It.IsAny<int>())).Returns(70);
            ForexDealer dealer = new ForexDealer(convertor.Object);
            int value = dealer.convertINRtoCountryForex(20, 700); //20 is for US
            Assert.Equal(10, value);
            convertor.Verify(x => x.isCountryAvailable(20));
        }
    }
}
