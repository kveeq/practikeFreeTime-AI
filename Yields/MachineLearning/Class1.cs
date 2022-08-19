using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yields.MachineLearning
{
    public class Class1
    {
        internal static Action<string> AnswerEvent;
        internal static Func<string> QuestionEvent;
        public string? Text { get; set; }
        private readonly bool isSdat = false;
        private readonly bool isAnaliz = false;
        private readonly bool isDoctor = false;
        private readonly bool isKonsult = false;
        private readonly bool isUndefined = false;

        public Class1(string text)
        {
            if(String.IsNullOrEmpty(text) || String.IsNullOrWhiteSpace(text))
            {
                isUndefined = true;
                return;
            }
            
            Text = text?.DelProbels();
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
                    Analiz analiz = new(Text);
                    analiz.HandleText();
                    // заглушка
                    // Console.WriteLine("Записали вас на сдачу анализов...");
                }
            }

            if (isDoctor)
            {
                if (!isKonsult)
                {
                    IsKonsultDoctorHandle();
                }
            }

            if (isKonsult)
            {
                IsKonsultDoctorHandle();
            }

            return true;
        }

        private void IsKonsultDoctorHandle()
        {
            Lazy<Doctor> doctor = null;
            string povt = "";
            while (doctor == null)
            {
                AnswerEvent?.Invoke("какая у вас проблема?... " + povt);
                string problemStr = Console.ReadLine();
                string[] problemStrArr = problemStr?.Split(' ');
                foreach (var item in problemStrArr)
                {
                    if (item.Trim().ToLower() == "живот" || item.Trim().ToLower().Contains("живот"))
                    {
                        doctor = new(new Doctor(isKonsult, DoctorSpec.Terapevt));
                    }
                }
                if (doctor == null)
                    povt = "I not understand you...";
            }

            //if (doctor?.spec == Doctor)
            //{
            //    Console.WriteLine(isKonsult ? "Записали вас на консультацию к терапевту... кабинет..." : "Записали вас к терапевту на прием... кабинет...");
            //}
        }
    }
}