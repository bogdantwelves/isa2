using System;
using Abc.Data.Common;
using Abc.Aids;


namespace Abc.Data;

public sealed class Country: NamedEntity {
     [Random(5,16)]public string OfficialName { get; set; } = "";
     [Random(5,16)]public string NativeName { get; set; } = "";
     [Random(1,3,"0123456789")]public string NumericCode { get; set; } = "";
     bool IsIsoCountry { get; set; }
     bool IsLoyaltyProgram { get; set; }
     [Random(1,3,"KLMNOPQRS")]public string IsoCode { get; set; } = "";
     public IEnumerable<CountryCurrency> Currencies { get; set; } = [];
}

