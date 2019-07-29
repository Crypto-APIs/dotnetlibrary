﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.NewTransaction
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        protected override void BeforeTest()
        {
            Assert.AreEqual(2, InputAddresses.Count());
            Assert.AreEqual(1, OutputAddresses.Count());
            Assert.AreEqual(InputAddresses.Sum(a => a.Value), OutputAddresses.Sum(a => a.Value));
        }

        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, InputAddresses, OutputAddresses, Fee, Wifs);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Txid));
        }

        [TestMethod]
        public void WrongInputsAddresses()
        {
            var inputAddresses = new List<TransactionAddress>
            {
                new TransactionAddress("qwe", 0.54),
            };
            var response = Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, inputAddresses, OutputAddresses, Fee, Wifs);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Address is not valid", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongOutputsAddresses()
        {
            var outputAddresses = new List<TransactionAddress>
            {
                new TransactionAddress("qwe", 0.54),
            };
            var response = Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, InputAddresses, outputAddresses, Fee, Wifs);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Address is not valid", response.ErrorMessage);
        }

        [TestMethod]
        public void SendLessThanGet()
        {
            var output = OutputAddressesDictionary.First();
            var outputAddresses = new List<TransactionAddress>
            {
                new TransactionAddress(output.Key, output.Value * 10),
            };
            var response = Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, InputAddresses, outputAddresses, Fee, Wifs);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Sum of input values is different then sum of output values", response.ErrorMessage);
        }

        [TestMethod]
        public void SendGreaterThanGet()
        {
            var output = OutputAddressesDictionary.First();
            var outputAddresses = new List<TransactionAddress>
            {
                new TransactionAddress(output.Key, output.Value / 10),
            };
            var response = Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, InputAddresses, outputAddresses, Fee, Wifs);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An InputAddresses was inappropriately allowed.")]
        public void NullInputAddresses()
        {
            List<TransactionAddress> inputAddresses = null;
            Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, inputAddresses, OutputAddresses, Fee, Wifs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An OutputAddresses was inappropriately allowed.")]
        public void NullOutputAddresses()
        {
            List<TransactionAddress> outputAddresses = null;
            Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, InputAddresses, outputAddresses, Fee, Wifs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An InputAddresses was inappropriately allowed.")]
        public void EmptyInputAddresses()
        {
            var inputAddresses = new List<TransactionAddress>();
            Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, inputAddresses, OutputAddresses, Fee, Wifs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An OutputAddresses was inappropriately allowed.")]
        public void EmptyOutputAddresses()
        {
            var outputAddresses = new List<TransactionAddress>();
            Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, InputAddresses, outputAddresses, Fee, Wifs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Fee was inappropriately allowed.")]
        public void InvalidFee()
        {
            Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, InputAddresses, OutputAddresses, new Fee(-1), Wifs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Wifs was inappropriately allowed.")]
        public void NullWifs()
        {
            Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, InputAddresses, OutputAddresses, Fee, wifs: null);
        }

        [TestMethod]
        public void FeeTooMuch()
        {
            var fee = int.MaxValue;
            var response = Manager.Blockchains.Transaction.NewTransaction(
                Coin, Network, InputAddresses, OutputAddresses, new Fee(fee), Wifs);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("", response.ErrorMessage);
        }

        private IEnumerable<TransactionAddress> GetTransactionAddresses(Dictionary<string, double> addresses)
        {
            return addresses.Select(address => new TransactionAddress(address.Key, address.Value));
        }

        private IEnumerable<TransactionAddress> InputAddresses =>
            _inputAddresses ?? (_inputAddresses = GetTransactionAddresses(InputAddressesDictionary));

        private IEnumerable<TransactionAddress> OutputAddresses =>
            _outputAddresses ?? (_outputAddresses = GetTransactionAddresses(OutputAddressesDictionary));

        private IEnumerable<TransactionAddress> _inputAddresses;
        private IEnumerable<TransactionAddress> _outputAddresses;

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
        protected abstract Dictionary<string, double> InputAddressesDictionary { get; }
        protected abstract Dictionary<string, double> OutputAddressesDictionary { get; }
        protected abstract List<string> Wifs { get; }
        protected Fee Fee { get; } = new Fee(0.00001500);
    }
}