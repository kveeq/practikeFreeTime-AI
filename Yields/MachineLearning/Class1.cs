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
        private readonly bool isZabrat = false;
        private readonly bool isProcedures = false;
        private readonly bool isZakl = false;
        private readonly bool isTest = false;
        private readonly bool isUzi = false;
        private readonly bool isUndefined = false;

        public Class1(string text)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrWhiteSpace(text))
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
                else if (item.Trim().ToLower() == "заб" || item.Trim().ToLower() == "забрать")
                {
                    isZabrat = true;
                }
                else if (item.Trim().ToLower().Contains("капельниц") || item.Contains("систем") || item.Trim().ToLower().Contains("процедур") || item.Trim().ToLower().Contains("укол"))
                {
                    isProcedures = true;
                }
                else if (item.Trim().ToLower() == "анализ" || item.Trim().ToLower() == "анализы")
                {
                    isAnaliz = true;
                }
                else if (item.Trim().ToLower() == "доктору" || item.Trim().ToLower() == "доктор" || item.Trim().ToLower() == "врачу" || item.Contains("врач"))
                {
                    isDoctor = true;
                }
                else if (item.Trim().ToLower().Contains("заключен") || item.Trim().ToLower().Contains("справк"))
                {
                    isZakl = true;
                }
                else if (item.Trim().ToLower() == "консультация" || item.Trim().ToLower().Contains("консульт"))
                {
                    isKonsult = true;
                }
                else if (item.Trim().ToLower() == "тест" || item.Trim().ToLower().Contains("тест"))
                {
                    isTest = true;
                }
                else if (item.Trim().ToLower() == "узи" || item.Trim().ToLower().Contains("узи"))
                {
                    isUzi = true;
                }
            }

            if (!isSdat && !isAnaliz && !isDoctor && !isKonsult && !isZabrat && !isProcedures && !isZakl && !isTest && !isUzi)
                isUndefined = true;

        }

        public object Handling()
        {
            if (isUndefined)
            {
                Console.WriteLine("мы вас не поняли!");
                return false;
            }

            if (isAnaliz)
            {
                Analiz analiz = new(Text);
                if (isSdat)
                {
                    analiz.HandleText();
                    // заглушка
                    // Console.WriteLine("Записали вас на сдачу анализов...");
                }
                if (isZabrat)
                {
                    analiz.GetAnaliz();
                }
            }

            if (isDoctor && !isZakl)
            {
                if (!isKonsult)
                {
                    IsKonsultDoctorHandle();
                }
            }

            if (isZakl)
            {
                Lazy<Doctor> doctor = null;
                string povt = "";
                while (doctor == null)
                {
                    AnswerEvent?.Invoke("К какому доктору?... " + povt);
                    string problemStr = Console.ReadLine();
                    string[] problemStrArr = problemStr?.Split(' ');
                    foreach (var item in problemStrArr)
                    {
                        if (item.Trim().ToLower().Contains("терапевт"))
                        {
                            doctor = new(new Doctor(isKonsult, DoctorSpec.Terapevt));
                        }
                        else if (item.Trim().ToLower().Contains("хирург"))
                        {
                            doctor = new(new Doctor(isKonsult, DoctorSpec.Hirurg));
                        }
                        else if (item.Trim().ToLower().Contains("травматолог"))
                        {
                            doctor = new(new Doctor(isKonsult, DoctorSpec.Travmatolog));
                        }
                        else if (item.Trim().ToLower().Contains("невролог"))
                        {
                            doctor = new(new Doctor(isKonsult, DoctorSpec.Nevrolog));
                        }
                    }

                    if (doctor == null)
                        povt = "Назовите специальность доктора...";
                }
            }

            if (isTest)
            {
                Test test = new Test(Text);
                test.handle();
            }

            if(isUzi)
            {
                Uzi uzi = new Uzi(Text);
                uzi.hundle();
            }

            if (isKonsult)
            {
                IsKonsultDoctorHandle();
            }

            if(isProcedures)
            {
                Procedure proc = new Procedure(Text);
                proc.HandleText();
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
                    if (item.Trim().ToLower() == "живот" || item.Trim().ToLower().Contains("живот") || item.Trim().ToLower().Contains("терапевт"))
                    {
                        doctor = new(new Doctor(isKonsult, DoctorSpec.Terapevt));
                    }
                    else if(item.Trim().ToLower().Contains("невролог")) // доделать с диагнозами
                    {
                        doctor = new(new Doctor(isKonsult, DoctorSpec.Nevrolog));
                    }
                    else if(item.Trim().ToLower().Contains("хирург")) // доделать с диагнозами
                    {
                        doctor = new(new Doctor(isKonsult, DoctorSpec.Hirurg));
                    }
                    else if(item.Trim().ToLower().Contains("травматолог")) // доделать с диагнозами
                    {
                        doctor = new(new Doctor(isKonsult, DoctorSpec.Travmatolog));
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