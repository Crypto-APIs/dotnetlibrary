﻿using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.GenerateAddress
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Address.GenerateAddress<GenerateEthAddressResponse>(NetworkCoin);

            AssertNullErrorMessage(response);

            var address = response.Payload.Address;
            Assert.IsFalse(string.IsNullOrEmpty(address), $"'{nameof(address)}' must not be null");

            var getAddressResponse = Manager.Blockchains.Address.GetAddress<GetEthAddressResponse>(NetworkCoin, address);

            AssertNullErrorMessage(getAddressResponse);
            Assert.IsFalse(string.IsNullOrEmpty(getAddressResponse.Payload.Address),
                $"'{nameof(getAddressResponse.Payload.Address)}' must not be null");
            Assert.AreEqual(address, getAddressResponse.Payload.Address, "'Address' is wrong");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}