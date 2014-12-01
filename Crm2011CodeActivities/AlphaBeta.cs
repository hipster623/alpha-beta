using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Text.RegularExpressions;

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
            //PSEUDO
            //get text
            var text = TextToParse.Get(context);
            //find all numbers in text
            var numbers = FindAllNumbers(text);

            //discard anyone not 11 digits, do Luhn mod 10 on them, put hits in candidate array
            var candidatesCorrectLength = numbers.Where(x => (x.Length == 11)).ToList();
            var candidates = candidatesCorrectLength.Where(y => DoLuhnMod10(y)).ToList();

            Found.Set(context, candidates.FirstOrDefault());
            Prob.Set(context, candidates.Count);
        }

        public bool DoLuhnMod10(string y)
        {
            return true;
        }

        private List<string> FindAllNumbers(string text)
        {            
            // Split on one or more non-digit characters.
            string[] numbers = Regex.Split(text, @"\D+");
            
            return new List<string>(numbers);
        }
    }
}
