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
        public AnalizTypes AnalizType { get; set; }
        private string handlingText;


        public Analiz(string textForHandle)
        {
            handlingText = textForHandle.DelProbels();
            string[] handlingTextArr = handlingText.Split(' ');
            foreach (var item in handlingTextArr)
            {
                if (item.Contains("кров"))
                {
                    AnalizType = AnalizTypes.Blood;
                    BloodAnaliz bloodAnaliz = new(handlingText);
                    bloodAnaliz.HandleText();
                    break;
                }
                // *** дальше проверяем по ключевым словам и указываем тип анализа ***
                /*
                    ...  
                */
            }
        }

        // сделать так же как в классе анализа крови
    }

    public enum AnalizTypes
    {
        Blood = 0,
        Ur = 1,
        /*
            *** другие обобщенные типы анализов - например анализ крови и т.д.  ***
            * без уточнение *
                                    .....
       */
    }
}
