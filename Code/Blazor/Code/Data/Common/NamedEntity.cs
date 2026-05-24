using Abc.Aids;

namespace Abc.Data.Common;

public abstract class NamedEntity: DetailedEntity {
    [Random(2,5)]public virtual string Name { get; set; } = "";
    [Random(2,4)]public virtual string Code { get; set; } = "";
}
