using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TextMatch.Domain.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Ensure_Expected_Result_Returned_With_Polly_As_subtext()
        {
            string text = "Polly put the kettle on, Polly put the kettle on, Polly put the kettle on we’ll all have tea";
            string subText = "Polly";
            IList<int> a = new TextMatch().Match(text, subText);

            Assert.AreEqual(a[0], 1);
            Assert.AreEqual(a[1], 26);
            Assert.AreEqual(a[2], 51);
        }
        
        [TestMethod]
        public void Ensure_Expected_Result_Returned_With_aa_As_subtext()
        {
            string text = "aaaa";
            string subText = "aa";
            IList<int> a = new TextMatch().Match(text, subText);

            Assert.AreEqual(a[0], 1);
            Assert.AreEqual(a[1], 2);
            Assert.AreEqual(a[2], 3);
        }
        
        [TestMethod]
        public void Ensure_Expected_Result_Returned_With_Nonalphabetic_subtext()
        {
            string text = "Polly put the kettle on, Polly put the kettle on, Polly put the kettle on we’ll all have tea";
            string subText = "ll (ell ell)";
            IList<int> a = new TextMatch().Match(text, subText);

            Assert.AreEqual(a[0], 3);
            Assert.AreEqual(a[1], 28);
            Assert.AreEqual(a[2], 53);
            Assert.AreEqual(a[3], 78);
            Assert.AreEqual(a[4], 82);
        }

        [TestMethod]
        public void Ensure_Expected_Result_Returned_With_Alphanumeric_subtext()
        {
            string text = "Polly put the kettle on, Polly put the kettle on, Polly put the kettle on we’ll all have tea";
            string subText = "***Polly***";
            IList<int> a = new TextMatch().Match(text, subText);

            Assert.AreEqual(a[0], 1);
            Assert.AreEqual(a[1], 26);
            Assert.AreEqual(a[2], 51);
        }


        [TestMethod]
        public void Ensure_Expected_Result_Returned_With_Alphanumeric_subtext_And_Text()
        {
            string text = "123Polly put the kettle on, 5Polly5 put the kettle on, ---Polly--- put the kettle on we’ll all have tea";
            string subText = "***Polly***";
            IList<int> a = new TextMatch().Match(text, subText);

            Assert.AreEqual(a[0], 4);
            Assert.AreEqual(a[1], 30);
            Assert.AreEqual(a[2], 59);
        }
    }
}
