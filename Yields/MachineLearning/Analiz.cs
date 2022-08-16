using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.MachineLearning
{
    public class Analiz
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private string handlingText;

        public Analiz(string textForHandle)
        {
            handlingText = textForHandle.DelProbels();

            foreach (var item in handlingText)
            {

            }
        }
    }
}
