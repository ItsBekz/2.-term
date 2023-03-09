using System;

namespace TestProject1
{
    public class Tests
    {
        Person person;
        [SetUp]
        public void Setup()
        {
            person = new Person("John", "Doe", -1, JobTypes.Programmer);
        }

        [Test]
        public void PersonTest()
        {
            //ARRANGE
            
            
            //ACT
            person.AssignNewJob("Comedian");
            person.HappyBirthday();
            
            //ASSERT
            Assert.AreEqual("John Doe", person.GetFullName());
            Assert.AreEqual(1, person.GetAge());
            Assert.AreEqual(JobTypes.Comedian, person.GetJob());
        }
    }
}