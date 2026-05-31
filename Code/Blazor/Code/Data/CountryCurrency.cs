using System;
using Abc.Aids;
using Abc.Data.Common;

namespace Abc.Data;

public class CountryCurrency: DetailedEntity{
    [Select(typeof(Country), nameof(Country.Code))] public Guid? CountryId { get; set; }
    [Select(typeof(Currency), nameof(Currency.Code))] public Guid? CurrencyId { get; set; }    
    public Currency Currency { get; set; } 
    public Country Country { get; set; }     
}
