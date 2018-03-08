using NUnit.Framework;
using Purity2;
using System;

namespace TestPurity
{
    public class Class1
    {
        [Test]
        public void WhenTransferDateIsFuture_ThenValidationPasses()
        {
            var transfer = new MakeTransfer { Date = new DateTime(2016, 12, 12) };
            var validator = new DateNotPastValidator();
            var actual = validator.IsValid(transfer);
            Assert.AreEqual(true, actual);
        }
    }
    public class DateNotPastValidatorTest
    {
        static DateTime presentDate = new DateTime(2016, 12, 12);
        private class FakeDateTimeService : IDateTimeService
        {
            public DateTime UtcNow => presentDate;
        }

        // those calls are essentially functions too
        [TestCase(+1, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = true)]
        [TestCase(-1, ExpectedResult = false)]
        public bool WhenTransferDateIsPAst_ThenValidationFails(int offset)
        {
            // passing that fake makes call to validator pure
            // and makes test consistent
            var sut = new DateNotPastValidatorPure(new FakeDateTimeService());
            var cmd = new MakeTransfer { Date = presentDate.AddDays(offset) };
            return sut.IsValid(cmd);
        }

    }
}
