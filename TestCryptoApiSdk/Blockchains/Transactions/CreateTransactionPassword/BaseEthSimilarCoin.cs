﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.Transactions.CreateTransactionPassword
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [Ignore]
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, Value, Password);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex));
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, fromAddress, ToAddress, Value, Password);

            AssertErrorMessage(response, $"{fromAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, toAddress, Value, Password);

            AssertErrorMessage(response, $"{toAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongPassword()
        {
            var password = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, Value, password);

            AssertErrorMessage(response, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Value was inappropriately allowed.")]
        public void InvalidValue()
        {
            var value = -1;
            Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, value, Password);
        }

        [TestMethod]
        public void TestValueMoreThanBalance()
        {
            var value = double.MaxValue;
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, value, Password);

            AssertErrorMessage(response, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress was inappropriately allowed.")]
        public void NullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, fromAddress, ToAddress, Value, Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress was inappropriately allowed.")]
        public void NullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, toAddress, Value, Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Password was inappropriately allowed.")]
        public void NullPassword()
        {
            string password = null;
            Manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, Value, password);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }
        protected abstract double Value { get; }

        private string Password { get; } = "123456";
    }
}