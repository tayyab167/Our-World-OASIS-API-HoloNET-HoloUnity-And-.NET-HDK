﻿
using NextGenSoftware.OASIS.API.Core;

namespace NextGenSoftware.OASIS.STAR
{ 
    public class Holon : OASIS.API.Core.Holon, IHolon
    {
       public string RustHolonType { get; set; }
    }
}
