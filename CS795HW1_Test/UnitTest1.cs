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
        public void Returns_True_For_Login_Hari()
        {
            Assert.IsTrue(Create_DSecApp_Instance().Check_Username("Hari"));
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

    }
}
