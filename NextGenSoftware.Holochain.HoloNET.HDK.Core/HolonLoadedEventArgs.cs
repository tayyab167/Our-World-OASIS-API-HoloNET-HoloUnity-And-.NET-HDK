﻿
using NextGenSoftware.Holochain.HoloNET.Client.Core;
using NextGenSoftware.OASIS.API.Core;
using System;
using System.Collections.Generic;

namespace NextGenSoftware.Holochain.HoloNET.HDK.Core
{
    public class ZomesLoadedEventArgs : EventArgs
    {
        public List<IZome> Zomes { get; set; }
    }

    public class HolonLoadedEventArgs : EventArgs
    {
        public IHolon Holon { get; set; }
    }

    public class HolonsLoadedEventArgs : EventArgs
    {
        public List<IHolon> Holons { get; set; }
    }

    public class HolonSavedEventArgs : EventArgs
    {
        public IHolon Holon { get; set; }
    }

    public class ZomeErrorEventArgs : EventArgs
    {
        public string EndPoint { get; set; }
        public string Reason { get; set; }
        public Exception ErrorDetails { get; set; }
        public HoloNETErrorEventArgs HoloNETErrorDetails { get; set; }
    }
}
