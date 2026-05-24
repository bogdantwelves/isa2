namespace Abc.Share.Code;
using Abc.Infra;
public class UrlParams(Uri url)
{
    private readonly Dictionary<string,string> d = [];
    public Query Parse()
    {
        var q = url?.Query.TrimStart('?');
        if (string.IsNullOrEmpty(q)) return new Query();
        var pars = q.Split('&', StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in pars) add(p.Split('=', 2));
        return new Query(d);
    } 

    private void add(string[] p)
    {
        if (p.Length != 2) return;
        d[p[0]] = Uri.UnescapeDataString(p[1]);
    }
}