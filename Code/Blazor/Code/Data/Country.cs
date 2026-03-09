using System;
using Abc.Data.Common;

namespace Abc.Data;

public sealed class Country: NamedEntity {
     public string OfficialName { get; set; } = "";
     public string NativeName { get; set; } = "";
     public string NumericCode { get; set; } = "";
     bool IsIsoCountry { get; set; }
     bool IsLoyaltyProgram { get; set; }
     public string IsoCode { get; set; } = "";
}

