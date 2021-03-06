﻿using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetXPubReceiveAddressesBtc()
    {
      var xpub = "xpub68MP6APrnq8Pp5wpL77MWevxkTE62PLnhM9u71xxHxJMrnKvLKaXWfoGNhyUEr7LmwPf4k872fbL2yeimSae3JBQUnD5uaMnuzuEsjkz6Zk";
      var startIndex = 0;
      var finishIndex = 3;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetXPubReceiveAddresses<GetXPubAddressesResponse>(
        NetworkCoin.BtcMainNet, xpub, startIndex, finishIndex);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetXPubReceiveAddressesBtc executed successfully, " +
          $"\"{response.Addresses.Count}\" addresses were created "
        : $"GetXPubReceiveAddressesBtc error: {response.ErrorMessage}");
    }
  }
}