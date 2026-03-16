using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloneTests;

[TestClass]
public sealed class CloneTests
{
    private class Adress{
        public string City { get; set; }
    }
    private class Person{
        public string Name { get; set; }
        public Adress Adress { get; set; }
    }
    private static Person person;
    [ClassInitialize] public static void ClassInitialize(TestContext context){
        person = new Person{
            Name = "John Doe",
            Adress = new Adress{
                City = "New York"
            }
        };
    }
    private Person clone;
    [TestInitialize] public void TestInitialize() => clone = Abc.Aids.Clone.Object(person);
    [TestCleanup] public void TestCleanup() => clone = null;
    [TestMethod] public void CloneTest() => Assert.AreNotSame(person, clone);
    [TestMethod] public void ChangePersonNameTest(){
        clone.Name = "Bla bla";
        Assert.AreNotEqual("John Doe", clone.Name);
    }

    public void NotSameAdress() => Assert.AreNotSame(person.Adress, clone.Adress);

    [TestMethod] public void ChangeCityTest(){
        clone.Adress.City = "Bla bla";
        Assert.AreNotEqual("New York", person.Adress.City);
    }
    [TestMethod] public void ChangeAdressTets()
    {
        clone.Adress = new Adress{City = "Bla bla"};
        Assert.AreNotEqual("New York", person.Adress.City);
    }
}
