using System;
using Abc.Data;
using Abc.Data.Common;

namespace Abc.Infra;

public sealed class Query(Dictionary<string, string> d = null) {
    public static int[] PageSizes => [7, 15, 25, 50, 100];  
    public int Page => toInt(get(nameof(Page)), 1);
    public int PageSize => toInt(get(nameof(PageSize)), PageSizes[0]);
    public string Sort => get(nameof(Sort));
    public string Dir => get(nameof(Dir));
    private string get(string s) => (d ?? []).TryGetValue(s, out var x) ? x : null;
    private static int toInt(string s, int def) => int.TryParse(s, out var i) ? i : def;
}

public interface IRepo<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAsync(Query q);
    Task<int> CountAsync(Query q);
    Task<TEntity> CreateAsync(TEntity e);
    Task<TEntity> UpdateAsync(TEntity e);
    Task DeleteAsync(Guid id);
}

public interface IMoviesRepo : IRepo<Movie> {}
public interface ICountriesRepo : IRepo<Country> {}
public interface ICurrenciesRepo: IRepo<Currency> {}
public interface ICountryCurrenciesRepo: IRepo<CountryCurrency> {}
public interface IMoneyRepo: IRepo<Money> {}