﻿using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.DecodeTransaction
{
    [Ignore]  // todo: temporarily ignored
    [TestClass]
    public class DogeTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DogeTestNet;
        protected override string HexEncodedInfo { get; } = ""; // todo: set corrected value
    }
}