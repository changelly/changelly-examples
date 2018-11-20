using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChangellyApi
{
    public static class Changelly
    {
        private const string BaseUrl = "https://api.changelly.com";
        private const string PublicKey = "Your Public Key";
        private const string SecretKey = "Your Secret Key";

        #region Synchronous Methods

        public static ChangellyCurrenciesResult GetCurrencies(string requestId)
        {
            var result = new ChangellyCurrenciesResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getCurrencies",
                        @params = new { }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, content.ReadAsByteArrayAsync().Result);
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = client.PostAsync("", content).Result;
                    var rs = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var currenciesResponse = JsonConvert.DeserializeObject<ChangellyCurrenciesResponse>(rs);

                        result.RequestId = currenciesResponse.Id;
                        if (currenciesResponse.Error == null)
                        {
                            result.Currencies.AddRange(currenciesResponse.Result);
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = currenciesResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }

                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static ChangellyCurrenciesFullResult GetCurrenciesFull(string requestId)
        {
            var result = new ChangellyCurrenciesFullResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getCurrenciesFull",
                        @params = new { }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, content.ReadAsByteArrayAsync().Result);
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = client.PostAsync("", content).Result;
                    var rs = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var currenciesResponse = JsonConvert.DeserializeObject<ChangellyCurrenciesFullResponse>(rs);

                        result.RequestId = currenciesResponse.Id;
                        if (currenciesResponse.Error == null)
                        {
                            result.Currencies.AddRange(currenciesResponse.Result);
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = currenciesResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static ChangellyValidateAddressResult ValidateAddress(string requestId, string coinSymbol,
            string walletAddress)
        {
            var result = new ChangellyValidateAddressResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "validateAddress",
                        @params = new
                        {
                            currency = coinSymbol,
                            address = walletAddress
                        }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, content.ReadAsByteArrayAsync().Result);
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = client.PostAsync("", content).Result;
                    var rs = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var validateAddressResponse =
                            JsonConvert.DeserializeObject<ChangellyValidateAddressResponse>(rs);

                        result.RequestId = validateAddressResponse.Id;
                        if (validateAddressResponse.Error == null)
                        {
                            result.ValidationResult = validateAddressResponse.Result.Result;
                            result.ValidationMessage = validateAddressResponse.Result.Message;
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = validateAddressResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static ChangellyMinAmountResult GetMinAmount(string requestId, string fromCoinSymbol,
            string toCoinSymbol)
        {
            var result = new ChangellyMinAmountResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getMinAmount",
                        @params = new
                        {
                            from = fromCoinSymbol,
                            to = toCoinSymbol
                        }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, content.ReadAsByteArrayAsync().Result);
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = client.PostAsync("", content).Result;
                    var rs = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var minAmountResponse = JsonConvert.DeserializeObject<ChangellyMinAmountResponse>(rs);

                        result.RequestId = minAmountResponse.Id;
                        if (minAmountResponse.Error == null)
                        {
                            result.MinAmount = minAmountResponse.Result;
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = minAmountResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static ChangellyExchangeAmountResult GetExchangeAmount(string requestId, string fromCoinSymbol,
            string toCoinSymbol, decimal amount)
        {
            var result = new ChangellyExchangeAmountResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getExchangeAmount",
                        @params = new
                        {
                            from = fromCoinSymbol,
                            to = toCoinSymbol,
                            amount = amount.ToString(CultureInfo.InvariantCulture)
                        }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, content.ReadAsByteArrayAsync().Result);
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = client.PostAsync("", content).Result;
                    var rs = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var exchangeAmountResponse = JsonConvert.DeserializeObject<ChangellyExchangeAmountResponse>(rs);

                        result.RequestId = exchangeAmountResponse.Id;
                        if (exchangeAmountResponse.Error == null)
                        {
                            result.Amount = exchangeAmountResponse.Result;
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = exchangeAmountResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static ChangellyCreateTransactionResult CreateTransaction(string requestId, string fromCoinSymbol,
            string toCoinSymbol, decimal amount, string destinationWallet)
        {
            var result = new ChangellyCreateTransactionResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "createTransaction",
                        @params = new
                        {
                            from = fromCoinSymbol,
                            to = toCoinSymbol,
                            amount = amount.ToString(CultureInfo.InvariantCulture),
                            address = destinationWallet
                        }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, content.ReadAsByteArrayAsync().Result);
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = client.PostAsync("", content).Result;
                    var rs = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var createTransaction = JsonConvert.DeserializeObject<ChangellyCreateTransactionResponse>(rs);

                        result.RequestId = createTransaction.Id;
                        if (createTransaction.Error == null)
                        {
                            result.ApiExtraFee = createTransaction.Result.ApiExtraFee;
                            result.ChangellyFee = createTransaction.Result.ChangellyFee;
                            result.PayinExtraId = createTransaction.Result.PayinExtraId;
                            result.AmountExpectedFrom = createTransaction.Result.AmountExpectedFrom;
                            result.Status = createTransaction.Result.Status;
                            result.CurrencyFrom = createTransaction.Result.CurrencyFrom;
                            result.CurrencyTo = createTransaction.Result.CurrencyTo;
                            result.AmountTo = createTransaction.Result.AmountTo;
                            result.PayInAddress = createTransaction.Result.PayInAddress;
                            result.PayOutAddress = createTransaction.Result.PayOutAddress;
                            result.CreatedAt = createTransaction.Result.CreatedAt;
                            result.KycRequired = createTransaction.Result.KycRequired;
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = createTransaction.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static ChangellyAllTransactionsResult GetAllTransactions(string requestId)
        {
            var result = new ChangellyAllTransactionsResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getTransactions",
                        @params = new { }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, content.ReadAsByteArrayAsync().Result);
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = client.PostAsync("", content).Result;
                    var rs = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var transactionsResponse = JsonConvert.DeserializeObject<ChangellyAllTransactionsResponse>(rs);

                        result.RequestId = transactionsResponse.Id;
                        if (transactionsResponse.Error == null)
                        {
                            result.Transactions.AddRange(transactionsResponse.Result);
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = transactionsResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static ChangellyTransactionStatusResult GetTransactionStatus(string requestId, string transactionId)
        {
            var result = new ChangellyTransactionStatusResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getStatus",
                        @params = new
                        {
                            id = transactionId
                        }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, content.ReadAsByteArrayAsync().Result);
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = client.PostAsync("", content).Result;
                    var rs = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var transactionStatusResponse =
                            JsonConvert.DeserializeObject<ChangellyTransactionStatusResponse>(rs);

                        result.RequestId = transactionStatusResponse.Id;
                        if (transactionStatusResponse.Error == null)
                        {
                            result.TransactionStatus = ToTransactionStatus(transactionStatusResponse.Result);
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = transactionStatusResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                    result.TransactionStatus = ChangellyTransactionStatus.ErrorParsing;
                }
            }

            return result;
        }

        #endregion


        #region Asynchronous Methods

        public static async Task<ChangellyCurrenciesResult> GetCurrenciesAsync(string requestId)
        {
            var result = new ChangellyCurrenciesResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getCurrencies",
                        @params = new { }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, await content.ReadAsByteArrayAsync());
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = await client.PostAsync("", content);
                    var rs = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var currenciesResponse = JsonConvert.DeserializeObject<ChangellyCurrenciesResponse>(rs);

                        result.RequestId = currenciesResponse.Id;
                        if (currenciesResponse.Error == null)
                        {
                            result.Currencies.AddRange(currenciesResponse.Result);
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = currenciesResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static async Task<ChangellyCurrenciesFullResult> GetCurrenciesFullAsync(string requestId)
        {
            var result = new ChangellyCurrenciesFullResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getCurrenciesFull",
                        @params = new { }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, await content.ReadAsByteArrayAsync());
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = await client.PostAsync("", content);
                    var rs = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var currenciesResponse = JsonConvert.DeserializeObject<ChangellyCurrenciesFullResponse>(rs);

                        result.RequestId = currenciesResponse.Id;
                        if (currenciesResponse.Error == null)
                        {
                            result.Currencies.AddRange(currenciesResponse.Result);
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = currenciesResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static async Task<ChangellyValidateAddressResult> ValidateAddressAsync(string coinSymbol,
            string walletAddress)
        {
            var result = new ChangellyValidateAddressResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "validateAddress",
                        @params = new
                        {
                            currency = coinSymbol,
                            address = walletAddress
                        }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, await content.ReadAsByteArrayAsync());
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = await client.PostAsync("", content);
                    var rs = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var validateAddressResponse =
                            JsonConvert.DeserializeObject<ChangellyValidateAddressResponse>(rs);

                        result.RequestId = validateAddressResponse.Id;
                        if (validateAddressResponse.Error == null)
                        {
                            result.ValidationResult = validateAddressResponse.Result.Result;
                            result.ValidationMessage = validateAddressResponse.Result.Message;
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = validateAddressResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static async Task<ChangellyMinAmountResult> GetMinAmountAsync(string requestId, string fromCoinSymbol,
            string toCoinSymbol)
        {
            var result = new ChangellyMinAmountResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getMinAmount",
                        @params = new
                        {
                            from = fromCoinSymbol,
                            to = toCoinSymbol
                        }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, await content.ReadAsByteArrayAsync());
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = await client.PostAsync("", content);
                    var rs = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var minAmountResponse = JsonConvert.DeserializeObject<ChangellyMinAmountResponse>(rs);

                        result.RequestId = minAmountResponse.Id;
                        if (minAmountResponse.Error == null)
                        {
                            result.MinAmount = minAmountResponse.Result;
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = minAmountResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static async Task<ChangellyExchangeAmountResult> GetExchangeAmountAsync(string requestId,
            string fromCoinSymbol, string toCoinSymbol, decimal amount)
        {
            var result = new ChangellyExchangeAmountResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getExchangeAmount",
                        @params = new
                        {
                            from = fromCoinSymbol,
                            to = toCoinSymbol,
                            amount = amount.ToString(CultureInfo.InvariantCulture)
                        }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, await content.ReadAsByteArrayAsync());
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = await client.PostAsync("", content);
                    var rs = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var exchangeAmountResponse = JsonConvert.DeserializeObject<ChangellyExchangeAmountResponse>(rs);

                        result.RequestId = exchangeAmountResponse.Id;
                        if (exchangeAmountResponse.Error == null)
                        {
                            result.Amount = exchangeAmountResponse.Result;
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = exchangeAmountResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static async Task<ChangellyCreateTransactionResult> CreateTransactionAsync(string requestId,
            string fromCoinSymbol, string toCoinSymbol, decimal amount, string destinationWallet)
        {
            var result = new ChangellyCreateTransactionResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "createTransaction",
                        @params = new
                        {
                            from = fromCoinSymbol,
                            to = toCoinSymbol,
                            amount = amount.ToString(CultureInfo.InvariantCulture),
                            address = destinationWallet
                        }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, await content.ReadAsByteArrayAsync());
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = await client.PostAsync("", content);
                    var rs = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var createTransaction = JsonConvert.DeserializeObject<ChangellyCreateTransactionResponse>(rs);

                        result.RequestId = createTransaction.Id;
                        if (createTransaction.Error == null)
                        {
                            result.ApiExtraFee = createTransaction.Result.ApiExtraFee;
                            result.ChangellyFee = createTransaction.Result.ChangellyFee;
                            result.PayinExtraId = createTransaction.Result.PayinExtraId;
                            result.AmountExpectedFrom = createTransaction.Result.AmountExpectedFrom;
                            result.Status = createTransaction.Result.Status;
                            result.CurrencyFrom = createTransaction.Result.CurrencyFrom;
                            result.CurrencyTo = createTransaction.Result.CurrencyTo;
                            result.AmountTo = createTransaction.Result.AmountTo;
                            result.PayInAddress = createTransaction.Result.PayInAddress;
                            result.PayOutAddress = createTransaction.Result.PayOutAddress;
                            result.CreatedAt = createTransaction.Result.CreatedAt;
                            result.KycRequired = createTransaction.Result.KycRequired;
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = createTransaction.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static async Task<ChangellyAllTransactionsResult> GetAllTransactionsAsync(string requestId)
        {
            var result = new ChangellyAllTransactionsResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getTransactions",
                        @params = new { }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, await content.ReadAsByteArrayAsync());
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = await client.PostAsync("", content);
                    var rs = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var transactionsResponse = JsonConvert.DeserializeObject<ChangellyAllTransactionsResponse>(rs);

                        result.RequestId = transactionsResponse.Id;
                        if (transactionsResponse.Error == null)
                        {
                            result.Transactions.AddRange(transactionsResponse.Result);
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = transactionsResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                }
            }

            return result;
        }

        public static async Task<ChangellyTransactionStatusResult> GetTransactionStatusAsync(string requestId,
            string transactionId)
        {
            var result = new ChangellyTransactionStatusResult();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(BaseUrl);

                    var body = JsonConvert.SerializeObject(new
                    {
                        id = "id",
                        jsonrpc = "2.0",
                        method = "getStatus",
                        @params = new
                        {
                            id = transactionId
                        }
                    });
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    string hmac = Sha512Hmac(SecretKey, await content.ReadAsByteArrayAsync());
                    client.DefaultRequestHeaders.Add("api-key", PublicKey);
                    client.DefaultRequestHeaders.Add("sign", hmac);

                    var response = await client.PostAsync("", content);
                    var rs = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var transactionStatusResponse =
                            JsonConvert.DeserializeObject<ChangellyTransactionStatusResponse>(rs);

                        result.RequestId = transactionStatusResponse.Id;
                        if (transactionStatusResponse.Error == null)
                        {
                            result.TransactionStatus = ToTransactionStatus(transactionStatusResponse.Result);
                            result.IsSuccessful = true;
                        }
                        else
                        {
                            result.Error = transactionStatusResponse.Error.Message;
                        }
                    }
                    else
                    {
                        result.Error = rs;
                    }
                }
                catch (Exception e)
                {
                    result.IsSuccessful = false;
                    result.Error = e.Message;
                    result.TransactionStatus = ChangellyTransactionStatus.ErrorParsing;
                }
            }

            return result;
        }

        #endregion Asynchronous Methods

        public static ChangellyTransactionStatus ToTransactionStatus(string status)
        {
            switch (status)
            {
                case "waiting":
                    return ChangellyTransactionStatus.Waiting;
                case "confirming":
                    return ChangellyTransactionStatus.Confirming;
                case "exchanging":
                    return ChangellyTransactionStatus.Exchanging;
                case "sending":
                    return ChangellyTransactionStatus.Sending;
                case "finished":
                    return ChangellyTransactionStatus.Finished;
                case "failed":
                    return ChangellyTransactionStatus.Failed;
                case "refunded":
                    return ChangellyTransactionStatus.Refunded;
                case "overdue":
                    return ChangellyTransactionStatus.Overdue;
                case "hold":
                    return ChangellyTransactionStatus.Hold;
            }

            return ChangellyTransactionStatus.ErrorParsing;
        }

        public static string Sha512Hmac(string key, byte[] textBytes, bool lowerCase = true)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            var hmacSha512 = new HMACSHA512(keyBytes);
            string hmac = BitConverter.ToString(hmacSha512.ComputeHash(textBytes)).Replace("-", string.Empty);
            return lowerCase ? hmac.ToLower() : hmac.ToUpper();
        }
    }

    public class ChangellyError
    {
        [JsonProperty("code")] public int Code { get; set; }
        [JsonProperty("message")] public string Message { get; set; }
    }

    public enum ChangellyTransactionStatus
    {
        ErrorParsing,
        Waiting,
        Confirming,
        Exchanging,
        Sending,
        Finished,
        Failed,
        Refunded,
        Overdue,
        Hold
    }

    #region GetCurrencies

    public class ChangellyCurrenciesResponse
    {
        [JsonProperty("jsonrpc")] public string Jsonrpc { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("result")] public List<string> Result { get; set; }
        [JsonProperty("error")] public ChangellyError Error { get; set; }
    }

    public class ChangellyCurrenciesResult
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
        public string RequestId { get; set; }
        public List<string> Currencies { get; set; }

        public ChangellyCurrenciesResult()
        {
            IsSuccessful = false;
            Error = "";
            RequestId = "";
            Currencies = new List<string>();
        }
    }

    #endregion GetCurrencies

    #region GetCurrenciesFull

    public class ChangellyCurrenciesFullData
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("fullName")] public string FullName { get; set; }
        [JsonProperty("enabled")] public bool Enabled { get; set; }
        [JsonProperty("fixRateEnabled")] public bool FixRateEnabled { get; set; }
        [JsonProperty("payinConfirmations")] public int PayInConfirmations { get; set; }
        [JsonProperty("extraIdName")] public string ExtraIdName { get; set; }
        [JsonProperty("addressUrl")] public string AddressUrl { get; set; }
        [JsonProperty("transactionUrl")] public string TransactionUrl { get; set; }
        [JsonProperty("image")] public string Image { get; set; }
        [JsonProperty("fixedTime")] public int FixedTime { get; set; }
    }

    public class ChangellyCurrenciesFullResponse
    {
        [JsonProperty("jsonrpc")] public string Jsonrpc { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("result")] public List<ChangellyCurrenciesFullData> Result { get; set; }
        [JsonProperty("error")] public ChangellyError Error { get; set; }
    }

    public class ChangellyCurrenciesFullResult
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
        public string RequestId { get; set; }
        public List<ChangellyCurrenciesFullData> Currencies { get; set; }

        public ChangellyCurrenciesFullResult()
        {
            IsSuccessful = false;
            Error = "";
            RequestId = "";
            Currencies = new List<ChangellyCurrenciesFullData>();
        }
    }

    #endregion GetCurrenciesFull

    #region ValidateAddress

    public class ChangellyValidateAddressData
    {
        [JsonProperty("result")] public bool Result { get; set; }
        [JsonProperty("message")] public string Message { get; set; }
    }

    public class ChangellyValidateAddressResponse
    {
        [JsonProperty("jsonrpc")] public string Jsonrpc { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("result")] public ChangellyValidateAddressData Result { get; set; }
        [JsonProperty("error")] public ChangellyValidateAddressData Error { get; set; }
    }

    public class ChangellyValidateAddressResult
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
        public string RequestId { get; set; }
        public bool ValidationResult { get; set; }
        public string ValidationMessage { get; set; }

        public ChangellyValidateAddressResult()
        {
            IsSuccessful = false;
            Error = "";
            RequestId = "";
            ValidationResult = false;
            ValidationMessage = "";
        }
    }

    #endregion ValidateAddress

    #region GetMinAmount

    public class ChangellyMinAmountResponse
    {
        [JsonProperty("jsonrpc")] public string Jsonrpc { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("result")] public decimal Result { get; set; }
        [JsonProperty("error")] public ChangellyError Error { get; set; }
    }

    public class ChangellyMinAmountResult
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
        public string RequestId { get; set; }
        public decimal MinAmount { get; set; }

        public ChangellyMinAmountResult()
        {
            IsSuccessful = false;
            Error = "";
            RequestId = "";
            MinAmount = 0;
        }
    }

    #endregion GetMinAmount

    #region GetExchangeAmount

    public class ChangellyExchangeAmountResponse
    {
        [JsonProperty("jsonrpc")] public string Jsonrpc { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("result")] public decimal Result { get; set; }
        [JsonProperty("error")] public ChangellyError Error { get; set; }
    }

    public class ChangellyExchangeAmountResult
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
        public string RequestId { get; set; }
        public decimal Amount { get; set; }

        public ChangellyExchangeAmountResult()
        {
            IsSuccessful = false;
            Error = "";
            RequestId = "";
            Amount = 0;
        }
    }

    #endregion GetExchangeAmount

    #region CreateTransaction

    public class ChangellyCreateTransactionData
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("apiExtraFee")] public string ApiExtraFee { get; set; }
        [JsonProperty("changellyFee")] public string ChangellyFee { get; set; }
        [JsonProperty("payinExtraId")] public string PayinExtraId { get; set; }
        [JsonProperty("amountExpectedFrom")] public string AmountExpectedFrom { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("currencyFrom")] public string CurrencyFrom { get; set; }
        [JsonProperty("currencyTo")] public string CurrencyTo { get; set; }
        [JsonProperty("amountTo")] public int AmountTo { get; set; }
        [JsonProperty("payinAddress")] public string PayInAddress { get; set; }
        [JsonProperty("payoutAddress")] public string PayOutAddress { get; set; }
        [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }
        [JsonProperty("kycRequired")] public bool KycRequired { get; set; }
    }

    public class ChangellyCreateTransactionResponse
    {
        [JsonProperty("jsonrpc")] public string Jsonrpc { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("result")] public ChangellyCreateTransactionData Result { get; set; }
        [JsonProperty("error")] public ChangellyError Error { get; set; }
    }

    public class ChangellyCreateTransactionResult
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
        public string RequestId { get; set; }
        public string ApiExtraFee { get; set; }
        public string ChangellyFee { get; set; }
        public string PayinExtraId { get; set; }
        public string AmountExpectedFrom { get; set; }
        public string Status { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public int AmountTo { get; set; }
        public string PayInAddress { get; set; }
        public string PayOutAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool KycRequired { get; set; }

        public ChangellyCreateTransactionResult()
        {
            IsSuccessful = false;
            Error = "";
            RequestId = "";
        }
    }

    #endregion CreateTransaction

    #region GetAllTransactions

    public class ChangellyTransactionsData
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("createdAt")] public int CreatedAt { get; set; }
        [JsonProperty("moneyReceived")] public int MoneyReceived { get; set; }
        [JsonProperty("moneySent")] public int MoneySent { get; set; }
        [JsonProperty("payinConfirmations")] public string PayinConfirmations { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("currencyFrom")] public string CurrencyFrom { get; set; }
        [JsonProperty("currencyTo")] public string CurrencyTo { get; set; }
        [JsonProperty("payinAddress")] public string PayinAddress { get; set; }
        [JsonProperty("payinExtraId")] public object PayinExtraId { get; set; }
        [JsonProperty("payinHash")] public string PayinHash { get; set; }
        [JsonProperty("amountExpectedFrom")] public string AmountExpectedFrom { get; set; }
        [JsonProperty("payoutAddress")] public string PayoutAddress { get; set; }
        [JsonProperty("payoutExtraId")] public object PayoutExtraId { get; set; }
        [JsonProperty("payoutHash")] public object PayoutHash { get; set; }
        [JsonProperty("refundHash")] public object RefundHash { get; set; }
        [JsonProperty("amountFrom")] public string AmountFrom { get; set; }
        [JsonProperty("amountTo")] public string AmountTo { get; set; }
        [JsonProperty("networkFee")] public object NetworkFee { get; set; }
        [JsonProperty("changellyFee")] public string ChangellyFee { get; set; }
        [JsonProperty("apiExtraFee")] public string ApiExtraFee { get; set; }
    }

    public class ChangellyAllTransactionsResponse
    {
        [JsonProperty("jsonrpc")] public string Jsonrpc { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("result")] public List<ChangellyTransactionsData> Result { get; set; }
        [JsonProperty("error")] public ChangellyError Error { get; set; }
    }

    public class ChangellyAllTransactionsResult
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
        public string RequestId { get; set; }
        public List<ChangellyTransactionsData> Transactions { get; set; }

        public ChangellyAllTransactionsResult()
        {
            IsSuccessful = false;
            Error = "";
            RequestId = "";
            Transactions = new List<ChangellyTransactionsData>();
        }
    }

    #endregion GetAllTransactions

    #region GetTransactionStatus

    public class ChangellyTransactionStatusResponse
    {
        [JsonProperty("jsonrpc")] public string Jsonrpc { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("result")] public string Result { get; set; }
        [JsonProperty("error")] public ChangellyError Error { get; set; }
    }

    public class ChangellyTransactionStatusResult
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
        public string RequestId { get; set; }
        public ChangellyTransactionStatus TransactionStatus { get; set; }

        public ChangellyTransactionStatusResult()
        {
            IsSuccessful = false;
            Error = "";
            RequestId = "";
            TransactionStatus = ChangellyTransactionStatus.ErrorParsing;
        }
    }

    #endregion GetTransactionStatus
}