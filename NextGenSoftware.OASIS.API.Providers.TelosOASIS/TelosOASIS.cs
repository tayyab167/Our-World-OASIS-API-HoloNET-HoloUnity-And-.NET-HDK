﻿using NextGenSoftware.OASIS.API.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextGenSoftware.OASIS.API.Providers.TelosOASIS
{
    public class TelosOASIS : OASISStorageBase, IOASISStorage, IOASISNET
    {
        public TelosOASIS()
        {
            this.ProviderName = "TelosOASIS";
            this.ProviderDescription = "Telos Provider";
            this.ProviderType = ProviderType.TelosOASIS;
            this.ProviderCategory = ProviderCategory.StorageAndNetwork;
        }

        public override bool DeleteAvatar(Guid id, bool softDelete = true)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteAvatar(string providerKey, bool softDelete = true)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteAvatarAsync(Guid id, bool softDelete = true)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteAvatarAsync(string providerKey, bool softDelete = true)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteHolon(Guid id, bool softDelete = true)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteHolon(string providerKey, bool softDelete = true)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteHolonAsync(Guid id, bool softDelete = true)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteHolonAsync(string providerKey, bool softDelete = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHolon> GetHolonsNearMe(HolonType Type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPlayer> GetPlayersNearMe()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IAvatar> LoadAllAvatars()
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<IAvatar>> LoadAllAvatarsAsync()
        {
            throw new NotImplementedException();
        }

        public override IAvatar LoadAvatar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override IAvatar LoadAvatar(string username, string password)
        {
            throw new NotImplementedException();
        }

        public override IAvatar LoadAvatar(string username)
        {
            throw new NotImplementedException();
        }

        public override Task<IAvatar> LoadAvatarAsync(string providerKey)
        {
            throw new NotImplementedException();
        }

        public override Task<IAvatar> LoadAvatarAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override Task<IAvatar> LoadAvatarAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public override IAvatar LoadAvatarForProviderKey(string providerKey)
        {
            throw new NotImplementedException();
        }

        public override Task<IAvatar> LoadAvatarForProviderKeyAsync(string providerKey)
        {
            throw new NotImplementedException();
        }

        public override IHolon LoadHolon(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IHolon LoadHolon(string providerKey)
        {
            throw new NotImplementedException();
        }

        public override Task<IHolon> LoadHolonAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<IHolon> LoadHolonAsync(string providerKey)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IHolon> LoadHolons(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IHolon> LoadHolons(string providerKey)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<IHolon>> LoadHolonsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<IHolon>> LoadHolonsAsync(string providerKey)
        {
            throw new NotImplementedException();
        }

        public override IAvatar SaveAvatar(IAvatar Avatar)
        {
            throw new NotImplementedException();
        }

        public override Task<IAvatar> SaveAvatarAsync(IAvatar Avatar)
        {
            throw new NotImplementedException();
        }

        public override IHolon SaveHolon(IHolon holon)
        {
            throw new NotImplementedException();
        }

        public override Task<IHolon> SaveHolonAsync(IHolon holon)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IHolon> SaveHolons(IEnumerable<IHolon> holons)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<IHolon>> SaveHolonsAsync(IEnumerable<IHolon> holons)
        {
            throw new NotImplementedException();
        }

        public override Task<ISearchResults> SearchAsync(ISearchParams searchParams)
        {
            throw new NotImplementedException();
        }
    }
}
