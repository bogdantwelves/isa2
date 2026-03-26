using Abc.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Abc.Tests.Aids;

[TestClass] public class TypeExtensionTests: TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(TypeExtension);
    [TestMethod] public void isBoolTest()
    {
        Assert.IsTrue(TypeExtension.isBool(typeof(bool)));
        Assert.IsTrue(typeof(bool).isBool());
        Assert.IsFalse(TypeExtension.isBool(typeof(string)));
    }
    [TestMethod] public void isBoolNullableTest()
    {
        Assert.IsTrue(TypeExtension.isBool(typeof(bool?)));
    }
    [TestMethod] public void isStringTest() {
    }
    [TestMethod] public void isDateTest() {Assert.Inconclusive();}
    [DataRow(typeof(sbyte))]
    [DataRow(typeof(sbyte?))]
    [DataRow(typeof(byte))]
    [DataRow(typeof(byte?))]
    [DataRow(typeof(int))]
    [DataRow(typeof(int?))]
    [TestMethod] public void isNumericTest(Type t) {
        Assert.IsTrue(TypeExtension.isNumeric(t));
        Assert.IsTrue(t.isNumeric());
    }
}
