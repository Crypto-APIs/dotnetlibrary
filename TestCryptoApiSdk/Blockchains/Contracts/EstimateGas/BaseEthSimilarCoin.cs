﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Contracts.EstimateGas
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Contract.EstimateGas<EthEstimateGasContractResponse>(NetworkCoin);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.IsTrue(response.Payload.GasLimit > 0);
            Assert.IsTrue(response.Payload.GasPrice > 0);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}