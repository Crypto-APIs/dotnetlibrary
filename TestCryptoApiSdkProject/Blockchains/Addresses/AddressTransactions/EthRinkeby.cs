﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        protected override string Address { get; } = "0x54b7bc5bea3845198ff2936761087fc488504eed";
        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Rinkeby;
    }
}