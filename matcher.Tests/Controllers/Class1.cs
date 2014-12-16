using System;
using System.Diagnostics;
using matcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Love2think.Tests.Matchertest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            string str1 = "hello";
            string str2 = "he 1llo";


            //execute
            GetMatches match = new GetMatches();
            int distance = match.LevenshteinDistance(str1, str2);
            //assert
            Debug.WriteLine(distance);

            Assert.AreEqual(16, distance);



        }
    }
}
