﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
                NetworkCoin, Address);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
                NetworkCoin, Address, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
                NetworkCoin, Address, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
                NetworkCoin, Address, skip, limit);
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var address = "qwe";
            var response = Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
                NetworkCoin, address);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Address is not valid");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(NetworkCoin, null);
        }

        protected abstract string Address { get; }
        protected abstract NetworkCoin NetworkCoin { get; }
    }
}