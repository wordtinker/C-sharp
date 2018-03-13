using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace _12.Immutable
{
    public enum AccountStatus
    { Requested, Active, Frozen, Dormant, Closed }
    // must be immutable too
    public sealed class Transaction { }
    // seee sealed here
    public sealed class AccountState
    {
        public AccountStatus Status { get; }
        public decimal AllowedOverdraft { get; }
        // should expose as Ienumerable
        public ImmutableList<Transaction> TransactionHistory { get; }

        public AccountState(AccountStatus Status = AccountStatus.Requested
            , decimal AllowedOverdraft = 0
            , IEnumerable<Transaction> Transactions = null)
        {
            this.Status = Status;
            this.AllowedOverdraft = AllowedOverdraft;
            TransactionHistory = ImmutableList.CreateRange
                (Transactions ?? Enumerable.Empty<Transaction>());
        }

        public AccountState Add(Transaction t)
            => new AccountState(
                Transactions : TransactionHistory.Add(t),
                Status: this.Status,
                AllowedOverdraft: this.AllowedOverdraft
            );
        public AccountState With
            ( AccountStatus? Status = null
            , decimal? AllowedOverdraft = null)
            => new AccountState(
                // if it's null use current value
                Status: Status ?? this.Status,
                AllowedOverdraft : AllowedOverdraft ?? this.AllowedOverdraft,
                // prevent arbitrary changes
                Transactions: this.TransactionHistory);
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
