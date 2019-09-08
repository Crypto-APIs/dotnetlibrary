﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Tokens
{
    public interface IBlockchainTokenModule
    {
        /// <summary>
        /// Get token balances of adressess, as well as to transfer tokens from one address to another.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="address">Address with tokens.</param>
        /// <param name="contract">Contract address.</param>
        /// <see cref=""/>
        GetBalanceTokenResponse GetBalance(EthSimilarCoin coin, EthSimilarNetwork network, string address, string contract);

        /// <summary>
        /// Get token balances of adressess, as well as to transfer tokens from one address to another.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="address">Address with tokens.</param>
        /// <param name="contract">Contract address.</param>
        /// <see cref=""/>
        Task<GetBalanceTokenResponse> GetBalanceAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string address, string contract);

        /// <summary>
        /// Transfer Tokens using password.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="contract">Contract address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="password">Password.</param>
        /// <param name="amount">The amount of token is per unit.</param>
        /// <see cref=""/>
        TransferTokensResponse Transfer(EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, string password, double amount);

        /// <summary>
        /// Transfer Tokens using password.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="contract">Contract address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="password">Password.</param>
        /// <param name="amount">The amount of token is per unit.</param>
        /// <see cref=""/>
        Task<TransferTokensResponse> TransferAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, string password, double amount);

        /// <summary>
        /// Transfer Tokens using private key.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="contract">Contract address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="amount">The amount of token is per unit.</param>
        /// <param name="privateKey">Private key.</param>
        /// <see cref=""/>
        TransferTokensResponse Transfer(EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, double amount, string privateKey);

        /// <summary>
        /// Transfer Tokens using private key.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="contract">Contract address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="amount">The amount of token is per unit.</param>
        /// <param name="privateKey">Private key.</param>
        /// <see cref=""/>
        Task<TransferTokensResponse> TransferAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, double amount, string privateKey);

        /// <summary>
        /// Get list of each transfer for the specified address.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="address">Address with tokens.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <see cref=""/>
        GetTokensResponse GetTokens(EthSimilarCoin coin, EthSimilarNetwork network, string address, int skip = 0, int limit = 50);

        /// <summary>
        /// Get list of each transfer for the specified address.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="address">Address with tokens.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <see cref=""/>
        Task<GetTokensResponse> GetTokensAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string address, int skip = 0, int limit = 50);
    }
}