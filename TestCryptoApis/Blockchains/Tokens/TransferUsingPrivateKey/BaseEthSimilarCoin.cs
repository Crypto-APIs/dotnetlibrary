﻿using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Tokens.TransferUsingPrivateKey
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [Ignore] // todo: no funds for full testing
        [TestMethod]
        public void GeneralTest()
        {
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, FromAddress, ToAddress, Contract, gasPrice, gasLimit, amount, PrivateKey);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex),
                $"'{nameof(response.Payload.Hex)}' must not be null");
        }

        [Ignore] // todo: "insufficient funds for gas * price + value" for Ropsten
        [TestMethod]
        public void NotEnoughTokens()
        {
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, FromAddress, ToAddress, Contract, gasPrice, gasLimit, amount, PrivateKey);

            AssertErrorMessage(response, "Not enough tokens");
        }

        [TestMethod]
        public void InvalidFromAddress()
        {
            var fromAddress = "1'23";
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, fromAddress, ToAddress, Contract, gasPrice, gasLimit, amount, PrivateKey);

            AssertErrorMessage(response, $"{fromAddress}  is not a valid Ethereum address");
        }

        [TestMethod]
        public void InvalidToAddress()
        {
            var toAddress = "12'3";
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, FromAddress, toAddress, Contract, gasPrice, gasLimit, amount, PrivateKey);

            AssertErrorMessage(response, $"{toAddress}  is not a valid Ethereum address");
        }

        [TestMethod]
        public void InvalidContract()
        {
            var contract = "1'23";
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, FromAddress, ToAddress, contract, gasPrice, gasLimit, amount, PrivateKey);

            AssertErrorMessage(response, $"{contract}  is not a valid Ethereum address");
        }

        [Ignore] //todo: "Internal Server Error" for Ropsten
        [TestMethod]
        public void InvalidPrivateKey()
        {
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            var privateKey = "1'23";

            var response = Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, FromAddress, ToAddress, Contract, gasPrice, gasLimit, amount, privateKey);

            AssertErrorMessage(response, "Not enough tokens");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void NullFromAddress()
        {
            string fromAddress = null;
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, fromAddress, ToAddress, Contract, gasPrice, gasLimit, amount, PrivateKey);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void NullToAddress()
        {
            string toAddress = null;
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, FromAddress, toAddress, Contract, gasPrice, gasLimit, amount, PrivateKey);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Contract of null was inappropriately allowed.")]
        public void NullContract()
        {
            string contract = null;
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, FromAddress, ToAddress, contract, gasPrice, gasLimit, amount, PrivateKey);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Contract of null was inappropriately allowed.")]
        public void NullPrivateKey()
        {
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 115;
            string privateKey = null;

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, FromAddress, ToAddress, Contract, gasPrice, gasLimit, amount, privateKey);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasPrice was inappropriately allowed.")]
        public void InvalidGasPrice()
        {
            double gasPrice = 0;
            double gasLimit = 60000;
            double amount = 115;

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, FromAddress, ToAddress, Contract, gasPrice, gasLimit, amount, PrivateKey);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasLimit was inappropriately allowed.")]
        public void InvalidGasLimit()
        {
            double gasPrice = 11500000000;
            double gasLimit = 0;
            double amount = 115;

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, FromAddress, ToAddress, Contract, gasPrice, gasLimit, amount, PrivateKey);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An Amount was inappropriately allowed.")]
        public void InvalidAmount()
        {
            double gasPrice = 11500000000;
            double gasLimit = 60000;
            double amount = 0;

            Manager.Blockchains.Token.Transfer<TransferTokensResponse>(
                NetworkCoin, FromAddress, ToAddress, Contract, gasPrice, gasLimit, amount, PrivateKey);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }
        protected abstract string Contract { get; }
        private string PrivateKey { get; } = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";
    }
}