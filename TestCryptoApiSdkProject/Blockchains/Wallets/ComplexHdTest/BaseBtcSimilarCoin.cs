﻿using System;
using System.Linq;
using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Wallets.ComplexHdTest
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var walletName = $"{Coin}{Network}GeneralWallet";
            var addressCount = 3;
            var password = "0123456789";
            var response = Manager.Blockchains.Wallet.CreateHdWallet(Coin, Network, walletName, addressCount, password);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(walletName, response.Wallet.Name);
            Assert.AreEqual(addressCount, response.Wallet.Addresses.Count);

            // GetWallets
            var getWalletsResponse = Manager.Blockchains.Wallet.GetHdWallets(Coin, Network);

            Assert.IsNotNull(getWalletsResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getWalletsResponse.ErrorMessage));
            Assert.IsTrue(getWalletsResponse.Wallets.Any());
            Assert.AreEqual(1, getWalletsResponse.Wallets.Count(w => w == walletName));

            // GetWalletInfo
            var getResponse = Manager.Blockchains.Wallet.GetHdWalletInfo(Coin, Network, walletName);

            Assert.IsNotNull(getResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getResponse.ErrorMessage));
            Assert.AreEqual(walletName, getResponse.Wallet.Name);
            Assert.AreEqual(addressCount, getResponse.Wallet.Addresses.Count);

            // GenerateAddress
            var newAddressCount = 4;
            var generateResponse = Manager.Blockchains.Wallet.GenerateHdAddress(Coin, Network, walletName, newAddressCount, password);

            Assert.IsNotNull(generateResponse);
            Assert.IsTrue(string.IsNullOrEmpty(generateResponse.ErrorMessage));
            Assert.AreEqual(walletName, generateResponse.Wallet.Name);
            Assert.AreEqual(addressCount + newAddressCount, generateResponse.Wallet.Addresses.Count);

            // DeleteHdWallet
            var deleteResponse = Manager.Blockchains.Wallet.DeleteHdWallet(Coin, Network, walletName);

            Assert.IsNotNull(deleteResponse);
            Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
            Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
        }

        [TestMethod]
        public void WeakPassword()
        {
            var walletName = $"{Coin}{Network}WeakPasswordWallet";
            var addressCount = 3;
            var password = "123456";
            var response = Manager.Blockchains.Wallet.CreateHdWallet(Coin, Network, walletName, addressCount, password);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("'password' is too weak. Min size is 10 characters, actual is 6", response.ErrorMessage);
        }

        [TestMethod]
        public void ExistingWallet()
        {
            var addressCount = 3;
            var password = "0123456789";
            var walletName = $"{Coin}{Network}ExistingWallet";

            // Create the first wallet
            var response = Manager.Blockchains.Wallet.CreateHdWallet(Coin, Network, walletName, addressCount, password);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(walletName, response.Wallet.Name);

            // Create the second wallet
            var response2 = Manager.Blockchains.Wallet.CreateHdWallet(Coin, Network, walletName, addressCount, password);

            Assert.IsNotNull(response2);
            Assert.IsFalse(string.IsNullOrEmpty(response2.ErrorMessage));
            Assert.AreEqual($"Wallet '{walletName}' already exists", response2.ErrorMessage);

            // DeleteWallet
            var deleteResponse = Manager.Blockchains.Wallet.DeleteHdWallet(Coin, Network, walletName);

            Assert.IsNotNull(deleteResponse);
            Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
            Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An address count was inappropriately allowed.")]
        public void EmptyAddresses()
        {
            var walletName = $"{Coin}{Network}EmptyAddressesWallet";
            var password = "0123456789";
            Manager.Blockchains.Wallet.CreateHdWallet(Coin, Network, walletName, -1, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A password count was inappropriately allowed.")]
        public void NullPassword()
        {
            var walletName = $"{Coin}{Network}NullPasswordWallet";
            Manager.Blockchains.Wallet.CreateHdWallet(Coin, Network, walletName, 3, password: null);
        }

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
    }
}