﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.WebhookNotifications.DeleteHook
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var response = Manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(NetworkCoin);
            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);

            foreach (var hook in response.Hooks)
            {
                var deleteResponse = Manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(NetworkCoin, hook.Id);
                Assert.IsNotNull(deleteResponse);
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message));
                Assert.AreEqual($"Webhook with id: {hook.Id} was successfully deleted!", deleteResponse.Payload.Message);
            }

            var secondResponse = Manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(NetworkCoin);
            AssertNotNullResponse(secondResponse);
            AssertNullErrorMessage(secondResponse);
            AssertEmptyCollection(nameof(secondResponse.Hooks), secondResponse.Hooks);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A HookId of null was inappropriately allowed.")]
        public void DeleteNullHookId()
        {
            string hookId = null;
            Manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(NetworkCoin, hookId);
        }

        [TestMethod]
        public void DeleteInvalidHookId()
        {
            var hookId = "qwe";
            var response = Manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(NetworkCoin, hookId);

            AssertNotNullResponse(response);
            if (IsAdditionalPackagePlan)
            {
                AssertErrorMessage(response, $"Could not delete webhook with id: {hookId}");
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}