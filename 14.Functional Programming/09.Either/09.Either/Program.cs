using LanguageExt;
using static LanguageExt.Prelude;
using System;

namespace _09.Either
{
    public class Error : NewType<Error, string>
    {
        public Error(string e) : base(e) { }
    }
    public abstract class Command { }
    public sealed class BookTransfer : Command
    {
        public Guid DebitedAccountId { get; set; }

        public string Beneficiary { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

    class BookTransferController
    {
        public void BookTransfer(BookTransfer cmd)
            => Handle(cmd).Match(
                Fail: BadRequest, // Validation failed
                Succ: result =>
                {
                    result.Match(
                        Fail: OnFaulted, // Exception
                        Succ: u => OnSuccess()); // everything is OK
                });

        void BadRequest(Seq<Error> arg)
        {
            foreach (var err in arg)
            {
                Console.WriteLine(err.ToString());
            }
        }
        void OnFaulted(Exception ex)
        {
            Console.WriteLine("Exception!!!");
        }
        void OnSuccess()
        {
            Console.WriteLine("Everything is fine!");
        }

        Validation<Error, Try<Unit>> Handle(BookTransfer cmd)
            => Validate(cmd).Map(Save);

        Validation<Error, BookTransfer> Validate(BookTransfer cmd)
            //=> ValidateBic(cmd)
            //.Bind(ValidateDate);
            /// This uses the | operator as a disjunction computation.  If any items are
            /// Failed then the errors are collected and returned.  If they all pass then
            /// the Success value from the first item is propagated.  This only works when
            /// all the operands are of the same type and you only care about the first
            /// success value.
            => ValidateBic(cmd) | ValidateDate(cmd);

        Validation<Error, BookTransfer> ValidateBic(BookTransfer cmd)
            => cmd.Bic.Length > 5
               ? Success<Error, BookTransfer>(cmd)
               : Fail<Error, BookTransfer>(Error.New("Invalid Bic"));

        Validation<Error, BookTransfer> ValidateDate(BookTransfer cmd)
            // not pure but that's not the point
            => cmd.Date.Date <= DateTime.Now.Date
               ? Success<Error, BookTransfer>(cmd)
               : Fail<Error, BookTransfer>(Error.New("Invalid date"));


        Try<Unit> Save(BookTransfer transfer) => () =>
            {
                // Do some saving that could throw
                return unit;
            };
    }

    class Program
    {
        // Validation and Try are both examples of specialized Either
        static void Main(string[] args)
        {
            var controller = new BookTransferController();
            BookTransfer b1 = new BookTransfer
            {
                Bic = "1234",
                Date = new DateTime(2019, 1, 1)
            };
            BookTransfer b2 = new BookTransfer
            {
                Bic = "1234568",
                Date = new DateTime(2018, 1, 1)
            };
            controller.BookTransfer(b1);
            controller.BookTransfer(b2);
        }
    }
}
