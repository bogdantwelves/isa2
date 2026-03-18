namespace Abc.Data.Common;

public abstract class NamedEntity: DetailedEntity {
    public virtual string Name { get; set; } = "";
    public virtual string Code { get; set; } = "";
}
