using System;
using Abc.Data.Common;

namespace Abc.Data;

public class CountryCurrency: DetailedEntity{
    public Guid? CountryId { get; set; }
    public Guid? CurrencyId { get; set; }    
    public Currency Currency { get; set; }      
}
