using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.MachineLearning
{
    public class Uzi
    {
        private UziTypes UziType { get; set; } = UziTypes.Null;
        private string handlingText;

        public Uzi(string hundleStr)
        {
            this.handlingText = hundleStr;
            handle(hundleStr);
        }   

        public object hundle()
        {
            while (true)
            {
                if (UziType == UziTypes.Null)
                {
                    /*
                        ***
                        * спрашивать какой именно тип анализа крови они хотят делать
                        ***
                    */
                    Class1.AnswerEvent?.Invoke("Скажите какой тип УЗИ вы хотите сделать: Брюшной полости, почек");
                    string handlingStrBloodType = Class1.QuestionEvent?.Invoke();
                    handle(handlingStrBloodType);
                }
                else
                {
                    Class1.AnswerEvent?.Invoke($"Пройдите в кабинет... для УЗИ {UziType}");
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
                if (item.Contains("брюш") || item.Contains("брюх"))
                {
                    UziType = UziTypes.BrushPolost;
                    break;
                }
                else if(item.Contains("почк") || item.Contains("почек"))
                {
                    UziType = UziTypes.Pochki;
                    break;
                }
                // *** дальше проверяем по ключевым словам и указываем тип анализа ***
                /*
                    ...  
                */
            }
        }
    }

    public enum UziTypes
    {
        Null = 0,
        BrushPolost = 1,
        Pochki = 2,
        /*
            *** другие обобщенные типы анализов - например анализ крови и т.д.  ***
            * без уточнение *
                                    .....
       */
    }
}
