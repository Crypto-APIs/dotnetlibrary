﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class ExchangeRatesInExchangeTimestamp : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset, Exchange, TimeStamp);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset, Exchange, TimeStamp, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset, Exchange, TimeStamp.Date, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset, Exchange, TimeStamp, skip, limit);
        }

        private Asset BaseAsset { get; } = new Asset("5b755dacd5dd99000b3d92b2");
        private Exchange Exchange { get; } = new Exchange("5b1ea9d21090c200146f7366");
        private DateTime TimeStamp { get; } = new DateTime(2019, 02, 03);
    }
}