using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Aids;

public abstract class BaseTests<TClass>: TestAids<TClass> where TClass : class, new(){
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
}
