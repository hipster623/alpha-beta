using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;
using System.Collections.Generic;

namespace Crm2011CodeActivities.Tests
{
    [TestClass]
    public class AlphaBetaTests
    {
        string _sampleText = "<table border=\"1\">" +
                        " <tr>" +
                        "    <td>Row 1 Cell 1</td>" +
                        "    <td>Row 1 Cell 2</td>" +
                        "  </tr>" +
                        "  <tr>" +
                        "    <td>Row 2 Cell 1</td>" +
                        "    <td>Row 2 Cell 2 20068346363</td>" + //TODO: create real test SSN
                        "  </tr>" +
                        "</table>";

        [TestMethod]
        public void CanReadArguments()
        {
            //arrange
            var activity = new AlphaBeta();
            var input = new Dictionary<string, object>() {
                {"TextToParse", _sampleText }
            };

            //act
            var output = WorkflowInvoker.Invoke(activity, input);
            
            //assert
            Assert.AreEqual(input["TextToParse"], output["Found"]);
            Assert.AreEqual(0, output["Prob"]);
        }

        /// <summary>
        /// When supplied with a random text or HTML segment, should find and return a valid SSN.
        /// If there are two or more (n) should return the first one with prob=1/n.
        /// </summary>
        [TestMethod]
        public void ShouldFindSsnInText()
        {
            //arrange
            var activity = new AlphaBeta();
            var input = new Dictionary<string, object>() {
                {"TextToParse", _sampleText }
            };

            //act
            var output = WorkflowInvoker.Invoke(activity, input);
            
            //assert
            Assert.AreEqual("20068346363", output["Found"]);
        }
    }
}
