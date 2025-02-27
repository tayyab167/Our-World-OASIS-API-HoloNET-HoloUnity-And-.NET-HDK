﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using NextGenSoftware.OASIS.API.Providers.CargoOASIS.Infrastructure.Exceptions;
using NextGenSoftware.OASIS.API.Providers.CargoOASIS.Infrastructure.Factory.ConfigurationProvider;
using NextGenSoftware.OASIS.API.Providers.CargoOASIS.Infrastructure.Factory.TokenStorage;

namespace NextGenSoftware.OASIS.API.Providers.CargoOASIS.Infrastructure.Factory.SignatureProviders
{
    public class MemoryCacheSignatureProvider : ISignatureProvider
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfigurationProvider _configuration;
        private readonly ITokenStorage _tokenStorage;
        private readonly string _key;

        public MemoryCacheSignatureProvider()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            _configuration = ConfigurationFactory.GetLocalStorageConfigurationProvider();
            _tokenStorage = TokenStorageFactory.GetMemoryCacheTokenStorage();
            _key = "_signature";
        }

        public async Task<(bool, string)> GetSignature()
        {
            try
            {
                var singingMessage = await _configuration.GetKey("cargoSingingMessage");
                var privateKey = await _configuration.GetKey("cargoPrivateKey");
                var hostUrl = await _configuration.GetKey("cargoHostUrl");
                
                if (string.IsNullOrEmpty(privateKey))
                    return (true, "Cargo private key not set in configuration file!");
                
                if (string.IsNullOrEmpty(hostUrl))
                    return (true, "Host url not set in configuration file!");
                
                if (string.IsNullOrEmpty(singingMessage))
                    return (true, "Singing message not set in configuration file!");
                
                var token = await _tokenStorage.GetToken();
                var account = new Account(privateKey);
                var web3 = new Web3(account, hostUrl);
                
                var signature = _memoryCache.Get(_key);
                if (signature != null) return (false, signature.ToString());
                
                signature = await web3.Eth.Sign.SendRequestAsync(singingMessage, token);
                _memoryCache.Set(_key, signature);
                return (false, signature.ToString());
            }
            catch (UserNotRegisteredException e)
            {
                return (true, e.Message);
            }
            catch (Exception e)
            {
                return (true, e.Message);
            }
        }
    }
}