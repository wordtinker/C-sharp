using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Purity2
{
    public abstract class Command { }
    public sealed class MakeTransfer : Command
    {
        public Guid DebitedAccountId { get; set; }

        public string Beneficiary { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
    public interface IValidator<T>
    {
        bool IsValid(T t);
    }
    public sealed class BicFormatValidator : IValidator<MakeTransfer>
    {
        // pure
        static readonly Regex regex = new Regex("^[A-Z]{6}[A-Z1-9]{5}$");
        public bool IsValid(MakeTransfer cmd)
            => regex.IsMatch(cmd.Bic);
    }
    public class DateNotPastValidator : IValidator<MakeTransfer>
    {
        // not pure, depends on I/O of DateTime
        public bool IsValid(MakeTransfer cmd)
            => (DateTime.UtcNow.Date <= cmd.Date.Date);
    }


    /// <summary>
    /// Encapsulates the impure behavior in an interface
    /// </summary>
    public interface IDateTimeService
    {
        DateTime UtcNow { get; }
    }
    public class DefaultDateTimeService : IDateTimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
    public class DateNotPastValidatorPure : IValidator<MakeTransfer>
    {
        private readonly IDateTimeService clock;

        public DateNotPastValidatorPure(IDateTimeService clock)
        {
            this.clock = clock;
        }
        /// <summary>
        /// When running normally, you’ll compose your objects so that you get the “real” impure
        /// implementation that checks the system clock.
        /// When running unit tests, you’ll inject a “fake” pure implementation that does something
        /// predictable, such as always returning the same DateTime, enabling you to write tests that are
        /// repeatable.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool IsValid(MakeTransfer request) => clock.UtcNow.Date <= request.Date.Date;
    }
    // Can avoid interface explosion with direct injection of values, 
    // still testable and pure but may lack safety and separation of concern.
    public class DateNotPastValidatorPureWithValue : IValidator<MakeTransfer>
    {
        private DateTime today;

        public DateNotPastValidatorPureWithValue(DateTime today)
        {
            this.today = today;
        }
        public bool IsValid(MakeTransfer cmd) => (today <= cmd.Date.Date);
    }
    // Can avoid interface explosion with function injection
    // as long as it is safe to inject functions.
    public sealed class BicExistsValidator : IValidator<MakeTransfer>
    {
        private Func<IEnumerable<string>> getValidCodes;

        public BicExistsValidator(Func<IEnumerable<string>> getValidCodes)
        {
            this.getValidCodes = getValidCodes;
        }
        public bool IsValid(MakeTransfer cmd) => getValidCodes().Contains(cmd.Bic);
    }

    class Program
    {
        static void Main(string[] args)
        {
            // General approach
            // 1.Define an interface (such as IDateTimeService) that abstracts the impure operations
            // consumed in the class under test.
            // 2. Put the impure implementation(such as DateTime.UtcNow) in a class that implements that
            // interface (such as DefaultDateTimeService).
            // 3. In the class under test, require the interface in the constructor, store it in a field, and
            // consume it as needed.
            // 4. Introduce some bootstrapping logic(manually or with the help of a framework)
            // so that the correct implementation will be injected whenever the class under test is instantiated.
            // 5. Create and inject a fake implementation for the purposes of unit testing.

            // NB explosion in the number of header interfaces.
        }
}
}
