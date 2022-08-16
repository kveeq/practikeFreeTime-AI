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
                    Console.WriteLine("Скажите какой анализ хотите сдать: крови, UR");
                    string handlingStrBloodType = Console.ReadLine();
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

        // сделать так же как в классе анализа крови
        private void handle(string textForHandle)
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
