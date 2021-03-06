﻿using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.CreateTransactionPassword
{
   // [Ignore] // todo: temporarily ignored
    [TestClass]
    public class EtcMorden : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;
        protected override string FromAddress { get; } = Features.CorrectAddress.EtcMorden;
        protected override string ToAddress { get; } = Features.CorrectAddress2.EtcMorden;
        protected override double Value { get; } = 0.12;
    }
}