﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdk.Exchanges.Ohlcv
{
    [TestClass]
    public class HistoricalOhlcvWithEndPeriod : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Ohlcv.Historical(Symbol, Period, StartPeriod, EndPeriod);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Ohlcv.Historical(Symbol, Period, StartPeriod, EndPeriod, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Ohlcv.Historical(Symbol, Period, StartPeriod, EndPeriod, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Ohlcv.Historical(Symbol, Period, StartPeriod, EndPeriod, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(RequestException), "EndPeriod is less than StartPeriod.")]
        public void TestIncorrectTimeInterval()
        {
            var startPeriod = new DateTime(DateTime.Now.Year, 01, 01);
            var endPeriod = new DateTime(DateTime.Now.Year - 1, 01, 01);
            Manager.Exchanges.Ohlcv.Historical(Symbol, Period, startPeriod, endPeriod);
        }

        [TestMethod]
        public void TestIncorrectEndTimeFromFeature()
        {
            var endPeriod = new DateTime(DateTime.Now.Year + 1, 01, 01);
            var response = Manager.Exchanges.Ohlcv.Historical(Symbol, Period, StartPeriod, endPeriod);

            AssertNotNullResponse(response);
            if (IsAdditionalPackagePlan)
            {
                AssertNullErrorMessage(response);
                Assert.IsNotNull(response.Ohlcv, "Response.Ohlcv must not be null");
                Assert.IsTrue(response.Ohlcv.Any(), "Collection must not be empty");
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        private Symbol Symbol { get; } = new Symbol("5b7add17b2fc9a000157cc0a");
        private Period Period { get; } = new Period("1day");
        private DateTime StartPeriod { get; } = new DateTime(2019, 04, 15);
        private DateTime EndPeriod { get; } = new DateTime(2019, 05, 01);
    }
}