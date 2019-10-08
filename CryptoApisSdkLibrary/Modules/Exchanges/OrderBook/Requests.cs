﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using CryptoApisSdkLibrary.Misc;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Exchanges.OrderBook
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest OrderBook(Exchange exchange, Asset baseAsset, Asset quoteAsset)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.ExchangeId))
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.ExchangeId)}");
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.AssetId))
                throw new ArgumentNullException($"{nameof(baseAsset)}.{nameof(baseAsset.AssetId)}");
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.AssetId))
                throw new ArgumentNullException($"{nameof(quoteAsset)}.{nameof(quoteAsset.AssetId)}");

            var request = Request.Get($"{Consts.OrderBook}/{exchange.ExchangeId}_SPOT_{baseAsset.AssetId}_{quoteAsset.AssetId}/snapshot");

            return request;
        }


        private CryptoApiRequest Request { get; }
    }
}