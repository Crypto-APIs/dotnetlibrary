﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class ExchangesSupportingPairs : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.ExchangesSupportingPairs(Asset1, Asset2);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.ExchangesSupportingPairs(Asset1, Asset2, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.ExchangesSupportingPairs(Asset1, Asset2, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.ExchangesSupportingPairs(Asset1, Asset2, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset1 of null was inappropriately allowed.")]
        public void TestNullAsset1()
        {
            Manager.Exchanges.ExchangesSupportingPairs(asset1: null, asset2: Asset2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset2 of null was inappropriately allowed.")]
        public void TestNullAsset2()
        {
            Manager.Exchanges.ExchangesSupportingPairs(Asset1, asset2: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset1.Id of null was inappropriately allowed.")]
        public void TestNullId1()
        {
            Manager.Exchanges.ExchangesSupportingPairs(new Asset(), Asset2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset2.Id of null was inappropriately allowed.")]
        public void TestNullId2()
        {
            Manager.Exchanges.ExchangesSupportingPairs(Asset1, new Asset());
        }

        [TestMethod]
        public void TestIncorrectAsset1()
        {
            var asset = new Asset("QWEE'WQ1");

            var response = Manager.Exchanges.ExchangesSupportingPairs(asset, Asset2);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Infos);
            Assert.IsFalse(response.Infos.Any());
        }

        [TestMethod]
        public void TestIncorrectAsset2()
        {
            var asset = new Asset("QWEEW'Q1");

            var response = Manager.Exchanges.ExchangesSupportingPairs(Asset1, asset);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Infos);
            Assert.IsFalse(response.Infos.Any());
        }

        private Asset Asset1 { get; } = new Asset("5b1ea92e584bf50020130612");
        private Asset Asset2 { get; } = new Asset("5b755dacd5dd99000b3d92b2");
    }
}