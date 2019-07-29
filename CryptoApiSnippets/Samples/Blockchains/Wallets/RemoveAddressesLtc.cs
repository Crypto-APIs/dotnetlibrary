﻿using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void RemoveAddressesLtc(string walletName, string address)
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.RemoveAddress(
        coin, network, walletName, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"RemoveAddressesLtc executed successfully" 
        : $"RemoveAddressesLtc error: {response.ErrorMessage}");
    }
  }
}