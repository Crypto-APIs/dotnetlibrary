﻿using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRinkeby;
        protected override string BlockHash { get; } = Features.CorrectBlockHash.EthRinkenby;
    }
}