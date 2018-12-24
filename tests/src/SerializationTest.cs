using System;
using System.IO;
using Xunit;
using ConfigManager;

namespace ConfigManagerTests
{
    public class SerializationTest
    {
        private class Person
        {
            public string Name;
            public uint Age;
            public string Profession;

            public Person(string name, uint age, string prof)
            {
                Name = name;
                Age = age;
                Profession = prof;
            }
        }

        private const string _expectedConfigLocation = "config/test/person.json";

        private Configuration<Person> _config;
        private Person _person;

        public SerializationTest()
        {
            _config = new Configuration<Person>(_expectedConfigLocation);
            _person = new Person("Jordan", 25, "Software Dev");
        }

        [Fact]
        public void TestWriteFile()
        {
            _config.WriteJSON(_person, _expectedConfigLocation);

            Assert.NotEqual(0, GetConfigFileSize());

            DeleteConfigFile();        
        }

        [Fact]
        public void TestReadFile()
        {
            _config.WriteJSON(_person, _expectedConfigLocation);

            Assert.NotEqual(0, GetConfigFileSize());
            
            _config.ReadJSON();

            Assert.NotNull(_config.Data);
            Assert.NotNull(_config.Data.Name);
            Assert.NotNull(_config.Data.Age);
            Assert.NotNull(_config.Data.Profession);

            DeleteConfigFile();
        }

        private long GetConfigFileSize()
        {
            return new FileInfo(_expectedConfigLocation).Length;
        }

        private void DeleteConfigFile()
        {
            if(File.Exists(_expectedConfigLocation))
            {
                File.Delete(_expectedConfigLocation);
            }
        }
    }
}