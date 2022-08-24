using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.MachineLearning
{
    public class Test
    {
        private TestTypes TestType { get; set; } = TestTypes.Null;
        private string handlingText;
        public Test(string Text)
        {
            handlingText = Text;
            handle(Text);
        }
        public object handle()
        {
            while (true)
            {
                if (TestType == TestTypes.Null)
                {
                    /*
                        ***
                        * спрашивать какой именно тип анализа крови они хотят делать
                        ***
                    */
                    Class1.AnswerEvent?.Invoke("Скажите какой тест хотите сдать");
                    string handlingStrBloodType = Class1.QuestionEvent?.Invoke();
                    handle(handlingStrBloodType);
                }
                else
                {
                    Class1.AnswerEvent?.Invoke($"Пройдите в кабинет... для сдачи {TestType} теста");
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
                if (item.Contains("экспрес"))
                {
                    TestType = TestTypes.ExperessPCR;
                    break;
                }
                else if(item.Contains("пцр"))
                {
                    TestType = TestTypes.PCR;
                    break;
                }
                // *** дальше проверяем по ключевым словам и указываем тип анализа ***
                /*
                    ...  
                */
            }
        }
    }

    public enum TestTypes
    {
        Null = 0,
        PCR = 1,
        ExperessPCR = 2,
        /*
            *** другие обобщенные типы анализов - например анализ крови и т.д.  ***
            * без уточнение *
                                    .....
       */
    }
}
