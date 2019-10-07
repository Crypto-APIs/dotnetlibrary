﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.Transactions.CreateTransactionPrivateKey
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, PrivateKey, Value);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex));
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, fromAddress, ToAddress, PrivateKey, Value);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, $"{fromAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, toAddress, PrivateKey, Value);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, $"{toAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongPrivateKey()
        {
            var privateKey = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, privateKey, Value);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Bad Request");
        }

        [TestMethod]
        public void ValueMoreThanBalance()
        {
            var value = double.MaxValue;
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, PrivateKey, value);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Value was inappropriately allowed.")]
        public void InvalidValue()
        {
            var value = -1;
            Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, PrivateKey, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress was inappropriately allowed.")]
        public void NullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, fromAddress, ToAddress, PrivateKey, Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress was inappropriately allowed.")]
        public void NullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, toAddress, PrivateKey, Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A PrivateKey was inappropriately allowed.")]
        public void NullPrivateKey()
        {
            string privateKey = null;
            Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, privateKey, Value);
        }


        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }
        protected abstract double Value { get; }

        private string PrivateKey { get; } = "0x17de216dff24b36c35af535c7d4d9d36f57326f3ee8aaf7fd373715c27a15b7e";
    }
}