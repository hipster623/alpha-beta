using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;

namespace Crm2011CodeActivities
{
    public class AlphaBeta : CodeActivity
    {
        //TODO: crm 2011 wf properties input names?

        public InArgument<string> TextToParse { get; set; }
        public OutArgument<string> Found { get; set; }
        public OutArgument<int> Prob { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            Found.Set(context, TextToParse.Get(context));
            Prob.Set(context, 0);
        }
    }
}
