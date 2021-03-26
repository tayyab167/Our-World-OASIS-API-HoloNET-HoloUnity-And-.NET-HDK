﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using NextGenSoftware.OASIS.API.Core.Enums;
using NextGenSoftware.OASIS.API.Core.Events;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Core.Interfaces;

namespace NextGenSoftware.OASIS.API.Core.Managers
{
    public class HolonManager : OASISManager
    {
       // public List<IOASISStorage> OASISStorageProviders { get; set; }
        
        public delegate void StorageProviderError(object sender, AvatarManagerErrorEventArgs e);

        //TODO: In future more than one storage provider can be active at a time where each call can specify which provider to use.
        public HolonManager(IOASISStorage OASISStorageProvider) : base(OASISStorageProvider)
        {

        }
        public IHolon LoadHolon(Guid id, HolonType type = HolonType.Holon, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).LoadHolon(id, type);
        }
     
        public Task<IHolon> LoadHolonAsync(Guid id, HolonType type = HolonType.Holon, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).LoadHolonAsync(id, type);
        }

        public IHolon LoadHolon(string providerKey, HolonType type = HolonType.Holon, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).LoadHolon(providerKey, type);
        }

        public Task<IHolon> LoadHolonAsync(string providerKey, HolonType type = HolonType.Holon, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).LoadHolonAsync(providerKey, type);
        }


        public IEnumerable<IHolon> LoadHolonsForParent(Guid id, HolonType type = HolonType.Holon, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).LoadHolonsForParent(id, type);
        }

        public Task<IEnumerable<IHolon>> LoadHolonsForParentAsync(Guid id, HolonType type = HolonType.Holon, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).LoadHolonsForParentAsync(id, type);
        }

        public IEnumerable<IHolon> LoadHolonsForParent(string providerKey, HolonType type = HolonType.Holon, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).LoadHolonsForParent(providerKey, type);
        }

        public Task<IEnumerable<IHolon>> LoadHolonsForParentAsync(string providerKey, HolonType type = HolonType.Holon, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).LoadHolonsForParentAsync(providerKey, type);
        }

        public IEnumerable<IHolon> LoadAllHolons(HolonType type = HolonType.Holon, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).LoadAllHolons(type);
        }

        public Task<IEnumerable<IHolon>> LoadAllHolonsAsync(HolonType type = HolonType.Holon, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).LoadAllHolonsAsync(type);
        }

        public IHolon SaveHolon(IHolon holon, ProviderType providerType = ProviderType.Default)
        {
            bool needToChangeBack = false;
            ProviderType currentProviderType = ProviderManager.CurrentStorageProviderType.Value;

            holon = ProviderManager.SetAndActivateCurrentStorageProvider(providerType).SaveHolon(PrepareHolonForSaving(holon));

            foreach (EnumValue<ProviderType> type in ProviderManager.ProvidersThatAreAutoReplicating)
            {
                if (type.Value != providerType && type.Value != ProviderManager.CurrentStorageProviderType.Value)
                {
                    ProviderManager.SetAndActivateCurrentStorageProvider(type.Value).SaveHolon(holon);
                    needToChangeBack = true;
                }
            }

            // Set the current provider back to the original provider.
            if (needToChangeBack)
                ProviderManager.SetAndActivateCurrentStorageProvider(currentProviderType);

            return holon;
        }

        public async Task<IHolon> SaveHolonAsync(IHolon holon, ProviderType providerType = ProviderType.Default)
        {
            bool needToChangeBack = false;
            ProviderType currentProviderType = ProviderManager.CurrentStorageProviderType.Value;

            holon = await ProviderManager.SetAndActivateCurrentStorageProvider(providerType).SaveHolonAsync(PrepareHolonForSaving(holon));

            foreach (EnumValue<ProviderType> type in ProviderManager.ProvidersThatAreAutoReplicating)
            {
                if (type.Value != providerType && type.Value != ProviderManager.CurrentStorageProviderType.Value)
                {
                    await ProviderManager.SetAndActivateCurrentStorageProvider(type.Value).SaveHolonAsync(holon);
                    needToChangeBack = true;
                }
            }

            // Set the current provider back to the original provider.
            if (needToChangeBack)
                ProviderManager.SetAndActivateCurrentStorageProvider(currentProviderType);

            return holon;
        }

        public IEnumerable<IHolon> SaveHolons(IEnumerable<IHolon> holons, ProviderType providerType = ProviderType.Default)
        {
            bool needToChangeBack = false;
            ProviderType currentProviderType = ProviderManager.CurrentStorageProviderType.Value;

            holons = ProviderManager.SetAndActivateCurrentStorageProvider(providerType).SaveHolons(PrepareHolonsForSaving(holons));

            foreach (EnumValue<ProviderType> type in ProviderManager.ProvidersThatAreAutoReplicating)
            {
                if (type.Value != providerType && type.Value != ProviderManager.CurrentStorageProviderType.Value)
                {
                    ProviderManager.SetAndActivateCurrentStorageProvider(type.Value).SaveHolons(holons);
                    needToChangeBack = true;
                }
            }

            // Set the current provider back to the original provider.
            if (needToChangeBack)
                ProviderManager.SetAndActivateCurrentStorageProvider(currentProviderType);

            return holons;
        }

        public async Task<IEnumerable<IHolon>> SaveHolonsAsync(IEnumerable<IHolon> holons, ProviderType providerType = ProviderType.Default)
        {
            bool needToChangeBack = false;
            ProviderType currentProviderType = ProviderManager.CurrentStorageProviderType.Value;

            holons = await ProviderManager.SetAndActivateCurrentStorageProvider(providerType).SaveHolonsAsync(PrepareHolonsForSaving(holons));

            foreach (EnumValue<ProviderType> type in ProviderManager.ProvidersThatAreAutoReplicating)
            {
                if (type.Value != providerType && type.Value != ProviderManager.CurrentStorageProviderType.Value)
                {
                    await ProviderManager.SetAndActivateCurrentStorageProvider(type.Value).SaveHolonsAsync(holons);
                    needToChangeBack = true;
                }
            }

            // Set the current provider back to the original provider.
            if (needToChangeBack)
                ProviderManager.SetAndActivateCurrentStorageProvider(currentProviderType);

            return holons;
        }

        public bool DeleteHolon(Guid id, bool softDelete = true, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).DeleteHolon(id, softDelete);
        }

        public Task<bool> DeleteHolonAsync(Guid id, bool softDelete = true, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).DeleteHolonAsync(id, softDelete);
        }

        public bool DeleteHolon(string providerKey, bool softDelete = true, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).DeleteHolon(providerKey, softDelete);
        }

        public Task<bool> DeleteHolonAsync(string providerKey, bool softDelete = true, ProviderType provider = ProviderType.Default)
        {
            return ProviderManager.SetAndActivateCurrentStorageProvider(provider).DeleteHolonAsync(providerKey, softDelete);
        }

        private IHolon PrepareHolonForSaving(IHolon holon)
        {
            // TODO: I think it's best to include audit stuff here so the providers do not need to worry about it?
            // Providers could always override this behaviour if they choose...
            if (holon.Id != Guid.Empty)
            {
                holon.ModifiedDate = DateTime.Now;

                if (AvatarManager.LoggedInAvatar != null)
                    holon.ModifiedByAvatarId = AvatarManager.LoggedInAvatar.Id;
            }
            else
            {
                holon.IsActive = true;
                holon.CreatedDate = DateTime.Now;

                if (AvatarManager.LoggedInAvatar != null)
                    holon.CreatedByAvatarId = AvatarManager.LoggedInAvatar.Id;
            }

            return holon;
        }

        private IEnumerable<IHolon> PrepareHolonsForSaving(IEnumerable<IHolon> holons)
        {
            List<IHolon> holonsToReturn = new List<IHolon>();

            foreach (IHolon holon in holons)
                holonsToReturn.Add(PrepareHolonForSaving(holon));

            return holonsToReturn;
        }
    }
}
