namespace Abc.Aids;
[AttributeUsage(AttributeTargets.Property)]
public sealed class SelectAttribute (Type t, string displayProperty = "") : Attribute{
    public Type EntityType { get; } = t;
    public string DisplayProperty { get; } = string.IsNullOrWhiteSpace(displayProperty) ? "Name" : displayProperty;
}