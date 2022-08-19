using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.MachineLearning
{
    public static class CommonServices
    {
        public static string DelProbels(this string inText)
        {
            inText = inText?.Trim().ToLower();
            string outText = "" + inText[0];
            for (int i = 1; i < inText.Length; i++)
            {
                if (inText[i] == ' ' && inText[i-1] == ' ')
                {
                    continue;
                }
                outText += inText[i];
            }
            return outText;
        }
    }
}
