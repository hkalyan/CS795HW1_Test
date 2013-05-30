using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CS795HW1_Test
{
    [TestClass]
    public class UnitTest1
    {
        public DsecApp Create_DSecApp_Instance()
        {
            DsecApp dapp = new DsecApp();
            return dapp;
        }
        [TestMethod]
        public void Returns_True_For_Login_hkalyan()
        {
            Assert.IsTrue(Create_DSecApp_Instance().Check_Username("hkalyan"));
        }

        [TestMethod]
        public void Returns_True_For_Login_mukka()
        {
            Assert.IsTrue(Create_DSecApp_Instance().Check_Username("mukka"));
        }

        [TestMethod]
        public void Returns_False_For_Login_test()
        {
            Assert.IsFalse(Create_DSecApp_Instance().Check_Username("test"));
        }

        [TestMethod]
        public void Returns_False_For_EmptyString()
        {
            Assert.IsFalse(Create_DSecApp_Instance().Check_Username(""));
        }

        [TestMethod]
        public void Returns_False_For_InvalidCharactersInString()
        {
            Assert.IsFalse(Create_DSecApp_Instance().Check_Username("@#$"));
        }

        [TestMethod]
        public void Returns_True_For_Key12()
        {
            Assert.IsTrue(Create_DSecApp_Instance().Check_Key("12"));
        }

        [TestMethod]
        public void Returns_True_For_Key13()
        {
            Assert.IsTrue(Create_DSecApp_Instance().Check_Key("13"));
        }

        [TestMethod]
        public void Returns_False_For_Key200()
        {
            Assert.IsFalse(Create_DSecApp_Instance().Check_Key("200"));
        }

        [TestMethod]
        public void Returns_False_For_BlankKey()
        {
            Assert.IsFalse(Create_DSecApp_Instance().Check_Key(" "));
        }

    }
}
