﻿using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetXPubReceiveAddressesLtc()
    {
      var xpub = "11114KwzX8UNK72aiPKLR9QwW1WRR7hKkousmMqKEPDeGm59roW4uMctvqRpY2HEyGeZ9r7dp9XKXwb2QHhSZRUauY46F3ZgWxXGjLM9nsYnEF";
      var startIndex = 0;
      var finishIndex = 3;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetXPubReceiveAddresses<GetXPubAddressesResponse>(
        NetworkCoin.LtcMainNet, xpub, startIndex, finishIndex);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetXPubReceiveAddressesLtc executed successfully, " +
          $"\"{response.Addresses.Count}\" addresses were created "
        : $"GetXPubReceiveAddressesLtc error: {response.ErrorMessage}");
    }
  }
}