using System;
using System.IO;
using AndaForceUtils.Serialization;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Serialization
{
    [TestFixture]
    public class ConfigurationLoaderTest
    {
        public const String Filename = "cd.xml";
        public const String ErrorMessage = "Wrong restoration";

        public class ConfigData : IConfigurationObject
        {
            public int A;
            public float B;
            public String C;

            public void InitDefault()
            {
                A = 1;
                B = 2.0f;
                C = "3";
            }
        }

        [Test]
        public void TestSaveFileThenLoadFromFile()
        {
            var initial = new ConfigData();
            initial.InitDefault();
            ConfigurationLoader.SaveConfiguration(initial, Filename, null, OnSaveError);

            var restored = ConfigurationLoader.LoadConfiguration<ConfigData>(Filename);

            Assert.AreEqual(initial.A, restored.A, ErrorMessage);
            Assert.AreEqual(initial.A, restored.A, ErrorMessage);
            Assert.AreEqual(initial.A, restored.A, ErrorMessage);
        }

        [Test]
        public void TestSaveFileThenLoadFromString()
        {
            var initial = new ConfigData();
            initial.InitDefault();
            ConfigurationLoader.SaveConfiguration(initial, Filename, null, OnSaveError);

            using (var streamReader = new StreamReader(Filename))
            {
                var restored = ConfigurationLoader.LoadConfigurationFromString<ConfigData>(streamReader.ReadToEnd());
                Assert.AreEqual(initial.A, restored.A, ErrorMessage);
                Assert.AreEqual(initial.A, restored.A, ErrorMessage);
                Assert.AreEqual(initial.A, restored.A, ErrorMessage);

                streamReader.Close();
            }
        }

        private void OnSaveError(String message)
        {
            throw new Exception("Something wrong with save: " + message);
        }

        [TestFixtureTearDown]
        public void ClearFiles()
        {
            if (File.Exists(Filename))
            {
                File.Delete(Filename);
            }
        }
    }
}