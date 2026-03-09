using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data;

public abstract class BaseTests<TClass> where TClass : class, new(){
    private TClass obj;
    private const BindingFlags publicDeclared = BindingFlags.Public 
        | BindingFlags.Instance
        | BindingFlags.DeclaredOnly
        | BindingFlags.Static;
    [TestInitialize] public void TestInitialize() => obj = new TClass();
    [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    [TestMethod] public void IsCorrectClassTest(){
        var className = typeof(TClass).Name;
        var testClassName = GetType().Name;
        Assert.AreEqual(className + "Tests", testClassName);
    }
    [TestMethod] public void IsClassTestedTest(){
        var testMethods = GetType().GetMethods().Select(x => x.Name);
        var classMembers = typeof(TClass).GetMembers(publicDeclared)
            .Select(i => i.Name);
       foreach (var m in classMembers)
        {
            if(!testMethods.Contains(m+"Test")){
              Assert.Inconclusive(  $"{m} is not tested");
            }
        }
    }
    private static IEnumerable<string> getPropeties 
        => Aids.GetType.PropertyNames<TClass>(publicDeclared);

    private static IEnumerable<string> getMethods => Array
        .FindAll(typeof(TClass)
        .GetMethods(publicDeclared),i => !i.IsSpecialName)
        .Select(i => i.Name);
    
}
