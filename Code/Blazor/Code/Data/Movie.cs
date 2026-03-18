using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Abc.Data.Common;


namespace Abc.Data;

public class Movie: NamedEntity{
    [DisplayName("Title")]public override string Name { get; set; }
    [DisplayName("ReleaseDate")]public override DateTime? ValidFrom { get; set;}
    public string Genre { get; set; }
    [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
}
