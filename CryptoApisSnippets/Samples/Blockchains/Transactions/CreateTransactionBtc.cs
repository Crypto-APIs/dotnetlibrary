﻿using System;
using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateTransactionBtc()
    {
      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9", 0.54),
        new TransactionAddress("1K2huCLxy9tXWc5Yn8ow6vqPGvTaCXHo5q", 1.0),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("1EdcP2TSFsiQHNGvbbgsxgH7HfaFC54GwF", 1.54),
      };
      var fee = new Fee("mtFYoSowT3i649wnBDYjCjewenh8AuofQb", 0.00023141);

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
        NetworkCoin.BtcMainNet, inputs, outputs, fee);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateTransactionBtc executed successfully, " +
          $"HexEncodedInfo is \"{response.Payload.Hex}\""
        : $"CreateTransactionBtc error: {response.ErrorMessage}");
    }
  }
}