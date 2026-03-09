namespace Abc.Data.Common;

public abstract class NamedEntity: DetailedEntity {
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
}
