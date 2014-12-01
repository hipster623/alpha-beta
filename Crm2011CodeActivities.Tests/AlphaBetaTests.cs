using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;
using System.Collections.Generic;

namespace Crm2011CodeActivities.Tests
{
    [TestClass]
    public class AlphaBetaTests
    {
        [TestMethod]
        public void CanReadArguments()
        {
            //arrange
            var activity = new AlphaBeta();
            var input = new Dictionary<string, object>() {
                {"TextToParse",
                        "<table border=\"1\">"+
                        " <tr>"+
                        "    <td>Row 1 Cell 1</td>"+
                        "    <td>Row 1 Cell 2</td>"+
                        "  </tr>"+
                        "  <tr>"+
                        "    <td>Row 2 Cell 1</td>"+
                        "    <td>Row 2 Cell 2 20068346363</td>"+ //TODO: create real test SSN
                        "  </tr>"+
                        "</table>"},
                    
            };

            //act
            var output = WorkflowInvoker.Invoke(activity, input);
            
            //assert
            Assert.AreEqual(input["TextToParse"], output["Found"]);
            Assert.AreEqual(0, output["Prob"]);
        }
    }
}
