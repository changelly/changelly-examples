using System;

namespace ChangellyApi
{
    class Program
    {
        static void Main()
        {
            var currenciesResult = Changelly.GetCurrencies("1");
            if (currenciesResult.IsSuccessful)
            {
                Console.WriteLine(" GetCurrencies    => Successful");
                Console.WriteLine($" Currencies Count => {currenciesResult.Currencies.Count}");
            }
            else
            {
                Console.WriteLine(" GetCurrencies    => Failed");
                Console.WriteLine($" Error Message    => {currenciesResult.Error}");
            }

            Console.WriteLine("");


            var currenciesFullResult = Changelly.GetCurrenciesFull("2");
            if (currenciesFullResult.IsSuccessful)
            {
                Console.WriteLine(" GetCurrenciesFull => Successful");
                Console.WriteLine($" Currencies Count  => {currenciesFullResult.Currencies.Count}");
            }
            else
            {
                Console.WriteLine(" GetCurrenciesFull => Failed");
                Console.WriteLine($" Error Message    => {currenciesFullResult.Error}");
            }

            Console.WriteLine("");


            var validateAddressResult = Changelly.ValidateAddress("2", "doge", "A2eo8N1fbBzUppTvCJxpom3JK2tk3EFMaJ");
            if (validateAddressResult.IsSuccessful)
            {
                Console.WriteLine(" ValidateAddress  => Successful");
                Console.WriteLine($" Is Valid Address => {validateAddressResult.ValidationResult}");
            }
            else
            {
                Console.WriteLine(" ValidateAddress  => Failed");
                Console.WriteLine($" Error Message    => {validateAddressResult.Error}");
            }

            Console.WriteLine("");


            var minAmountResult = Changelly.GetMinAmount("3", "btc", "eth");
            if (minAmountResult.IsSuccessful)
            {
                Console.WriteLine(" GetMinAmount   => Successful");
                Console.WriteLine($" MinAmount      => {minAmountResult.MinAmount}");
            }
            else
            {
                Console.WriteLine(" GetMinAmount   => Failed");
                Console.WriteLine($" Error Message => {minAmountResult.Error}");
            }

            Console.WriteLine("");


            var exchangeAmountResult = Changelly.GetExchangeAmount("4", "btc", "eth", 1m);
            if (exchangeAmountResult.IsSuccessful)
            {
                Console.WriteLine(" GetExchangeAmount => Successful");
                Console.WriteLine($" Amount            => {exchangeAmountResult.Amount}");
            }
            else
            {
                Console.WriteLine(" GetExchangeAmount => Failed");
                Console.WriteLine($" Error Message     => {exchangeAmountResult.Error}");
            }

            Console.WriteLine("");


            var createTransactionResult =
                Changelly.CreateTransaction("5", "btc", "doge", 0.005m, "A2eo8N1fbBzUppTvCJxpom3JK2tk3EFMaJ");
            if (createTransactionResult.IsSuccessful)
            {
                Console.WriteLine(" CreateTransaction => Successful");
                Console.WriteLine($" Transaction Id    => {createTransactionResult.RequestId}");
            }
            else
            {
                Console.WriteLine(" CreateTransaction => Failed");
                Console.WriteLine($" Error Message     => {createTransactionResult.Error}");
            }

            Console.WriteLine("");


            var allTransactionsResult = Changelly.GetAllTransactions("6");
            if (allTransactionsResult.IsSuccessful)
            {
                Console.WriteLine(" GetAllTransactions => Successful");
                Console.WriteLine($" Transactions Count => {allTransactionsResult.Transactions.Count}");
            }
            else
            {
                Console.WriteLine(" GetAllTransactions => Failed");
                Console.WriteLine($" Error Message      => {allTransactionsResult.Error}");
            }

            Console.WriteLine("");


            var transactionStatusResult = Changelly.GetTransactionStatus("7", "btc");
            if (transactionStatusResult.IsSuccessful)
            {
                Console.WriteLine(" GetTransactionStatus => Successful");
                Console.WriteLine($" Transaction Status   => {transactionStatusResult.TransactionStatus}");
            }
            else
            {
                Console.WriteLine(" GetTransactionStatus => Failed");
                Console.WriteLine($" Error Message        => {transactionStatusResult.Error}");
            }

            Console.WriteLine("");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}