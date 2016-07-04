using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using FakeItEasy;
using TextMatch.Domain;
using TextMatch.Web.Actions;
using TextMatch.Web.Models;
using System.Collections.Generic;

namespace TextMatch.Web.Tests
{
    [TestClass]
    public class StringMatchActionTestfixture
    {
        [TestMethod]
        public void Ensure_Action_Returns_Oncomplete()
        {
            var logger = A.Fake<ILogger>();
            var stringMatch = A.Fake<ITextMatch>();

            A.CallTo(() => stringMatch.Match(null, null)).WithAnyArguments().Returns(new List<int>() { 1, 2, 3 });

            var action = new StringMatchAction<dynamic>(logger, stringMatch)
            {
                OnComplete = (m) => new { success = true, model = m },
                OnFailed = () => new { success = false }
            }.Execute(new TestMatchViewModel()
            {
                SubText = "test",
                Text = "test test"
            });
            
            Assert.IsNotNull(action);
            Assert.IsTrue(action.success);
            Assert.IsTrue(action.model.Output.Count == 3);
        }

        [TestMethod]
        public void Ensddure_Action_Returns_OnFailed_If_Exception()
        {
            var logger = A.Fake<NLog.ILogger>();
            var stringMatch = A.Fake<ITextMatch>();

            A.CallTo(() => stringMatch.Match(null, null)).WithAnyArguments().Throws(new Exception());

            var action = new StringMatchAction<dynamic>(logger, stringMatch)
            {
                OnComplete = (m) => new { success = true, model = m },
                OnFailed = () => new { success = false }
            }.Execute(new TestMatchViewModel()
            {
                SubText = "test",
                Text = "test test"
            });

            Assert.IsNotNull(action);
            Assert.IsFalse(action.success);
            A.CallTo(() => logger.Log(LogLevel.Fatal, "Error getting substring positions", new Exception())).WithAnyArguments().MustHaveHappened();
        }
    }
}
