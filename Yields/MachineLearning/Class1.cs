using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yields.MachineLearning
{
    public class Class1
    {
        public static Action<string> AnswerEvent;
        public static Func<string> QuestionEvent;
        public string? Text { get; set; }
        private bool isSdat = false;
        private bool isAnaliz = false;
        private bool isDoctor = false;
        private bool isKonsult = false;
        private bool isUndefined = false;

        public Class1(string text)
        {
            Text = text.DelProbels();
            Text = Text?.Replace(",", "");
            string[]? str = Text?.Split(' ');
            foreach (string? item in str)
            {
                if (item.Trim().ToLower() == "сдать")
                {
                    isSdat = true;
                }
                else if (item.Trim().ToLower() == "анализ" || item.Trim().ToLower() == "анализы")
                {
                    isAnaliz = true;
                }
                else if (item.Trim().ToLower() == "доктору" || item.Trim().ToLower() == "доктор" || item.Trim().ToLower() == "врачу" || item.Contains("врач"))
                {
                    isDoctor = true;
                }
                else if (item.Trim().ToLower() == "консультация" || item.Trim().ToLower().Contains("консульт"))
                {
                    isKonsult = true;
                }
            }

            if (!isSdat && !isAnaliz && !isDoctor && !isKonsult)
                isUndefined = true;

        }

        public object Handling()
        {
            if(isUndefined)
            {
                Console.WriteLine("мы вас не поняли!");
                return false;
            }
            if (isSdat)
            {
                if (isAnaliz)
                {
                    Analiz analiz = new Analiz(Text);
                    analiz.HandleText();
                    // заглушка
                    // Console.WriteLine("Записали вас на сдачу анализов...");
                }
            }
            if (isDoctor)
            {
                if (!isKonsult)
                {
                    IsKonsultDoctorhandle();
                }
            }
            if (isKonsult)
            {
                IsKonsultDoctorhandle();
            }

            return true;
        }

        private void IsKonsultDoctorhandle()
        {
            AnswerEvent?.Invoke("какая у вас проблема?...");
            string problemStr = Console.ReadLine();
            Doctor doctor;
            string[] problemStrArr = problemStr?.Split(' ');
            foreach (var item in problemStrArr)
            {
                if (item.Trim().ToLower() == "живот" || item.Trim().ToLower().Contains("живот"))
                {
                    doctor = new(isKonsult, DoctorSpec.Terapevt);
                }
            }

            //if (doctor?.spec == Doctor)
            //{
            //    Console.WriteLine(isKonsult ? "Записали вас на консультацию к терапевту... кабинет..." : "Записали вас к терапевту на прием... кабинет...");
            //}
        }
    }
}