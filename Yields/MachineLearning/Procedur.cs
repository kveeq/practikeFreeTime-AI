using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.MachineLearning
{
    public enum ProcedureTypes
    {
        Null = 0,
        Kapelnica = 1,
        Ukol = 2,
        /*
            *** другие обобщенные типы анализов - например анализ крови и т.д.  ***
            * без уточнение *
                                    .....
       */
    }
    class Procedure
    {
        private string handlingText;
        private ProcedureTypes ProcedureType { get; set; }
        public Procedure(string textForHandle)
        {
            handle(textForHandle);
        }

        public object HandleText()
        {
            while (true)
            {
                if (ProcedureType == ProcedureTypes.Null)
                {
                    /*
                        ***
                        * спрашивать какой именно тип анализа крови они хотят делать
                        ***
                    */
                    Class1.AnswerEvent?.Invoke("Скажите какую процедуру вы хотите сделать: Поставить капельницу, сделать укол");
                    string handlingStrBloodType = Class1.QuestionEvent?.Invoke();
                    handle(handlingStrBloodType);
                }
                else
                {
                    Class1.AnswerEvent?.Invoke("Проходите в кабинет...");
                    // Console.WriteLine("Пройдите в кабинет... ");
                    break;
                }
            }

            return true;
        }

        private void handle(string textForHandle)
        {
            handlingText = textForHandle.DelProbels() + ' ';
            string[] handlingTextArr = handlingText.Split(' ');
            foreach (var item in handlingTextArr)
            {
                if (item.Contains("укол"))
                {
                    ProcedureType = ProcedureTypes.Ukol;
                    break;
                }
                else if(item.Contains("капельниц") || item.Contains("систем"))
                {
                    ProcedureType = ProcedureTypes.Kapelnica;
                    break;
                }
                // *** дальше проверяем по ключевым словам и указываем тип процедуры ***
                /*
                    ...  
                */
            }
        }
    }
}
