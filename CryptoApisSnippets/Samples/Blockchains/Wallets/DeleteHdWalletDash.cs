﻿using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHdWalletDash(string walletName)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(
        NetworkCoin.DashMainNet, walletName);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteHdWalletDash executed successfully, " +
          $"\"{response.Payload.Message}\" status was returned"
        : $"DeleteHdWalletDash error: {response.ErrorMessage}");
    }
  }
}