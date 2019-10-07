﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.Transactions.GetInfoByBlockHashAndTransactionIndex
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(NetworkCoin, BlockHash, TransactionIndex);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.TransactionHash));
        }

        [TestMethod]
        public void InvalidBlockHash()
        {
            var blockHash = "qwe";
            var response = Manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(NetworkCoin, blockHash, TransactionIndex);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Transaction not found");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Url of null was inappropriately allowed.")]
        public void NullBlockHash()
        {
            string blockHash = null;
            Manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(NetworkCoin, blockHash, TransactionIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Url of null was inappropriately allowed.")]
        public void InvalidTransactionIndex()
        {
            var transactionIndex = -5;
            Manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(NetworkCoin, BlockHash, transactionIndex);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string BlockHash { get; }
        protected abstract int TransactionIndex { get; }
    }
}