﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class BchMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "bitcoincash:qqu895wz2c07j0snr7auuyaqel09x28nrcwklyv03w";
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Bch;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Mainnet;
    }
}