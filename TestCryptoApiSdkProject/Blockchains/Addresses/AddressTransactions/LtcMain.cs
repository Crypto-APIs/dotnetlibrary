﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class LtcMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "LL9nMSQrfp2RKwSdDZwHSDsyX44kTXqrKw";
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Ltc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Mainnet;
    }
}