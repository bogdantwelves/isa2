using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Aids;
public abstract class TestAids<TClass>: TestAids where TClass : class, new(){
    protected TClass obj;
    [TestInitialize] public virtual void Initialize() => type = typeof(TClass);
    protected const BindingFlags publicDeclared = BindingFlags.Public 
        | BindingFlags.Instance
        | BindingFlags.DeclaredOnly
        | BindingFlags.Static;
    
    protected static IEnumerable<string> getPropeties 
        => Abc.Aids.GetType.PropertyNames<TClass>(publicDeclared);

    protected static IEnumerable<string> getMethods 
        => Abc.Aids.GetType.MethodNames<TClass>(publicDeclared,false); 
    protected void isProperty<T>(string name) {
        var p = typeof(TClass).GetProperty(name);
        Assert.IsNotNull(p, noPropery(name));
        Assert.AreEqual(typeof(T), p.PropertyType, wrongType<T>(name, p));
    }

    private static string wrongType<T>(string name, PropertyInfo p) 
        => $"Property '{name}' in class '{typeof(TClass).Name}' is of type '{p.PropertyType.Name}', expected '{typeof(T).Name}'";
    private static string noPropery(string name) 
        => $"There is no public property {name} in {typeof(TClass).Name}";
}

public abstract class TestAids
{
    protected Type type {get; set;}
    [TestMethod] public void IsCorrectClassTest(){
        var className = type?.Name;
        var testClassName = GetType().Name;
        Assert.AreEqual(className + "Tests", testClassName);
    }
    public void areEqual<T>(T expected, T actual) => Assert.AreEqual(expected,actual);
    public void areSame(object expected, object actual) => Assert.AreSame(expected, actual);
}