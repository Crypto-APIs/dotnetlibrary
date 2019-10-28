﻿using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseCollectionTestWithoutSkip
    {
        [TestMethod]
        public void TestInvalidAddress()
        {
            var address = "qw'e";
            var response = Manager.Blockchains.Address.GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
                NetworkCoin, address);

            AssertErrorMessage(response, "Internal Server Error");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void TestBtcNullAddress()
        {
            string address = null;
            Manager.Blockchains.Address.GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
                NetworkCoin, address);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Address.GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
                NetworkCoin, Address);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Address.GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
                NetworkCoin, Address, limit: limit);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string Address { get; }
    }
}