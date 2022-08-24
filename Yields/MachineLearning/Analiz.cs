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
        public Patient Recivier { get; set; }
        private string handlingText;


        public Analiz(string textForHandle)
        {
            handle(textForHandle);
        }

        public object HandleText()
        {
            while (true)
            {
                if (AnalizType == AnalizTypes.Null)
                {
                    /*
                        ***
                        * спрашивать какой именно тип анализа крови они хотят делать
                        ***
                    */
                    Class1.AnswerEvent?.Invoke("Скажите какой анализ хотите сдать: крови, UR");
                    string handlingStrBloodType = Class1.QuestionEvent?.Invoke();
                    handle(handlingStrBloodType);
                }
                else
                {
                    // Console.WriteLine("Пройдите в кабинет... ");
                    break;
                }
            }

            return true;
        }

        public object GetAnaliz()
        {
            while (true)
            {
                if (Recivier == null)
                {
                    /*
                        ***
                        * спрашивать какой именно тип анализа крови они хотят делать
                        ***
                    */
                    Class1.AnswerEvent?.Invoke("Скажите свое ФИО");
                    string handlingStrPatFio = Class1.QuestionEvent?.Invoke();
                    if (handlingStrPatFio != "")
                    {
                        Recivier = new Patient();
                        Recivier.Fio = handlingStrPatFio;
                        Class1.AnswerEvent?.Invoke("Пройдите в кабинет...");
                    }
                }
                else
                {
                    // Console.WriteLine("Пройдите в кабинет... ");
                    break;
                }
            }

            return true;
        }

        // сделать так же как в классе анализа крови
        private void handle(string textForHandle)
        {
            handlingText = textForHandle.DelProbels() + ' ';
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
    }

    public enum AnalizTypes
    {
        Null = 0,
        Blood = 1,
        Ur = 2,
        /*
            *** другие обобщенные типы анализов - например анализ крови и т.д.  ***
            * без уточнение *
                                    .....
       */
    }
}
