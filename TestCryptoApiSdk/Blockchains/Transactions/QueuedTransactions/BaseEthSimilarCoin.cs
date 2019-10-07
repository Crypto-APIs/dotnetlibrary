﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdk.Blockchains.Transactions.QueuedTransactions
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.QueuedTransactions<QueuedTransactionsResponse>(NetworkCoin);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.IsTrue(response.Transactions.Any(), "Collection must not be empty");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}