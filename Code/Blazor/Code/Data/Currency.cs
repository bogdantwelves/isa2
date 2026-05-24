using Abc.Aids;
using Abc.Data.Common;

namespace Abc.Data;
public sealed class Currency: NamedEntity {
    [Random (3,5,"0123456789")] public string NumericCode { get; set; } = "";
    [Random(2,4,"ABCDEFG")]public string MajorUnitSymbol { get; set; } = "";
    [Random(1,1,"abcdefg")]public string MinorUnitSymbol { get; set; } = "";
    [Random(0,1,4)]public double RatioOfMinorUnit { get; set; }
    public bool IsIsoCurrency { get; set; }
}