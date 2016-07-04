using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextMatch.Domain.HelperClasses;

namespace TextMatch.Domain.Tests.HelperClasses
{
    /// <summary>
    /// Summary description for TextHelperClassTestFixture
    /// </summary>
    [TestClass]
    public class TextHelperClassTestFixture
    {
        [TestMethod]
        public void Ensure_Array_Of_Only_Strings_Is_Returned_If_tex_contains_NonalphaCharacters()
        {
            var text = "This is a test*****";

            var result = TextHelperClass.SplitText(text);

            Assert.IsTrue(result.Count == 4);
            Assert.AreEqual(result[0], "This");
            Assert.AreEqual(result[1], "is");
            Assert.AreEqual(result[2], "a");
            Assert.AreEqual(result[3], "test");
        }

        [TestMethod]
        public void Ensure_Length_Of_Text_Returned()
        {
            var text = "abcdefghijklmnopqrstuvwxyz";

            var result = TextHelperClass.LengthOfText(text);

            Assert.IsTrue(result == 26);

        }

        [TestMethod]
        public void Ensure_Text_Converted_To_List_Of_Strings()
        {
            var text = "abcdefghijklmnopqrstuvwxyz";

            var result = TextHelperClass.ToCharArray(text);

            Assert.IsTrue(result.Length == 26);

        }
    }
}
