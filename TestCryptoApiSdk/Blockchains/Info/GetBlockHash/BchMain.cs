﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class BchMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BchMainNet;
        protected override string BlockHash { get; } = "000000009b7262315dbf071787ad3656097b892abffd1f95a1a022f896f533fc";
    }
}