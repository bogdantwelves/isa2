using System;
using Abc.Data;

namespace Abc.Infra;

public class Repos
{
    public class MoviesRepo(ApplicationDbContext c = null)
     : EfBaseRepo<ApplicationDbContext, Movie>(c), IMoviesRepo
    {
        
    }
    public class CurrenciesRepo(ApplicationDbContext c = null)
     : EfBaseRepo<ApplicationDbContext, Currency>(c), ICurrenciesRepo
    {
        
    }
    public class CountriesRepo(ApplicationDbContext c = null)
     : EfBaseRepo<ApplicationDbContext, Country>(c), ICountriesRepo
    {
        
    }
        public class CountryCurrenciesRepo(ApplicationDbContext c = null)
        : EfBaseRepo<ApplicationDbContext, CountryCurrency>(c), ICountryCurrenciesRepo
        {
            
        }
        public class MoneyRepo(ApplicationDbContext c = null)
        : EfBaseRepo<ApplicationDbContext, Money>(c), IMoneyRepo
        {
            
        }
}
