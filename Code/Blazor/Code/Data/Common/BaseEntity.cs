using System.ComponentModel.DataAnnotations;
using Abc.Aids;

namespace Abc.Data.Common;

public abstract class BaseEntity {
    public virtual Guid Id { get; set; } = Guid.NewGuid();
   [Random(-50, -1)] public virtual DateTime? ValidFrom { get; set; }
    [Random(2, 10)]public virtual DateTime? ValidTo { get; set; }
    [Timestamp] public virtual byte[] Timestamp { get; set; } = [];
}
