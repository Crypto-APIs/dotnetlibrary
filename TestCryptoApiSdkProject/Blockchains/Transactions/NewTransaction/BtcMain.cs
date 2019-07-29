﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.NewTransaction
{
    [Ignore] // todo: temporarily ignored
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Btc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Mainnet;

        protected override Dictionary<string, double> InputAddressesDictionary => _inputAddresses ?? (_inputAddresses = new Dictionary<string, double>
        {
            { "1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9",0.54},
            { "1K2huCLxy9tXWc5Yn8ow6vqPGvTaCXHo5q",1.00}
        });

        protected override Dictionary<string, double> OutputAddressesDictionary => _outputAddresses ?? (_outputAddresses = new Dictionary<string, double>
        {
            { "1EdcP2TSFsiQHNGvbbgsxgH7HfaFC54GwF", 1.54},
        });

        protected override List<string> Wifs { get; } = new List<string>();

        private Dictionary<string, double> _inputAddresses;
        private Dictionary<string, double> _outputAddresses;
    }
}