﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Info.GetBlockHeight
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetBlockHeigh(Coin, Network, BlockHeight);
            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(BlockHeight, response.HashInfo.Height);
        }

        [TestMethod]
        public void IncorrectedBlock()
        {
            var response = Manager.Blockchains.Info.GetBlockHeigh(Coin, Network, blockHeight: -123);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Block not found", response.ErrorMessage);
        }

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
        protected abstract int BlockHeight { get; }
    }
}