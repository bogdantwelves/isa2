using Abc.Aids;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Abc.Shared.Components;

public interface IEditorAdapter {
    string DisplayName { get; }
    PropertyInfo PropInfo { get; }
    Type Editor { get; }
    Type Validator { get; }
    IDictionary<string, object> EditorParams { get; }
    IDictionary<string, object> ValidationParams { get; }
}

public sealed partial class EditorAdapter(ComponentBase c, object item, string propName): IEditorAdapter {
    public PropertyInfo PropInfo => ad?.PropInfo;
    public string DisplayName => hasName ? toName : string.Empty;
    public Type Editor => underlyingType.isString() ? typeof(InputText)
                        : underlyingType.isBool() ? typeof(InputCheckbox)
                        : underlyingType.isDate() ? generic(typeof(InputDate<>), propType)
                        : underlyingType.isNumeric() ? generic(typeof(InputNumber<>), propType)
                        : null;
    public Type Validator => generic(typeof(ValidationMessage<>), propType);
    public IDictionary<string, object> EditorParams
        => new Dictionary<string, object> {
            ["id"] = propName,
            ["name"] = inputName,
            ["class"] = "form-control",
            ["Value"] = ad.PropValue,
            ["ValueChanged"] = valChanged(),
            ["ValueExpression"] = valExpression()
        };
    public IDictionary<string, object> ValidationParams
        => new Dictionary<string, object> {
            ["For"] = valExpression(),
            ["class"] = "text-danger"
        };

    internal readonly IPropertyAdapter ad = new PropertyAdapter(item, propName);
    internal EventCallback<TValue> changed<TValue>()
        => EventCallback.Factory.Create<TValue>(c, value => {
            ad.SetValue(value);
            return Task.CompletedTask;
        });
    internal Expression<Func<TValue>> expression<TValue>() {
        var i = Expression.Constant(item);
        var p = Expression.Property(Expression.Convert(i, ad.ItemType), ad.PropInfo);
        return Expression.Lambda<Func<TValue>>(p);
    }
    internal const BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic;
    internal bool hasName => !string.IsNullOrWhiteSpace(propName);
    internal string inputName => (ad?.ItemType is null) ? propName : $"{ad.ItemType.Name}.{propName}";
    internal object makeGeneric(MethodInfo n) => n.MakeGenericMethod(ad.PropType).Invoke(this, null);
    internal static MethodInfo method(string name) => typeof(EditorAdapter).GetMethod(name, flags);
    [GeneratedRegex("(\\B[A-Z])")] internal static partial Regex myRegex();
    internal Type propType => ad?.PropType;
    internal string toName => myRegex().Replace(propName, " $1");
    internal Type underlyingType => ad?.UnderlyingType ?? typeof(object);
    internal object valChanged() => makeGeneric(method(nameof(changed)));
    internal object valExpression() => makeGeneric(method(nameof(expression)));
    internal static Type generic(Type editor, Type t) => editor.MakeGenericType(t);

}
