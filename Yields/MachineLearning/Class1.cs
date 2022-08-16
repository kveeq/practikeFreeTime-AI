using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yields.MachineLearning
{
    public class Class1
    {
        public string? Text { get; set; }
        private bool isSdat = false;
        private bool isAnaliz = false;
        private bool isDoctor = false;
        private bool isKonsult = false;

        public Class1(string text)
        {
            Text = text.DelProbels();
            Text = Text?.Replace(",", "");
            string[]? str = Text?.Split(' ');
            foreach (string? item in str)
            {
                if(item.Trim().ToLower() == "сдать")
                {
                    isSdat = true;
                }
                if(item.Trim().ToLower() == "анализ" || item.Trim().ToLower() == "анализы")
                {
                    isAnaliz = true;
                }
                if(item.Trim().ToLower() == "доктору" || item.Trim().ToLower() == "доктор")
                {
                    isDoctor = true;
                }
                if(item.Trim().ToLower() == "консультация" || item.Trim().ToLower().Contains("консульт"))
                {
                    isKonsult = true;
                }
            }
        }

        public object Handling()
        {
            bool isTerapevt = false;
            if(isSdat)
            {
                if (isAnaliz)
                {
                    Analiz analiz = new Analiz(Text);
                    // заглушка
                    // Console.WriteLine("Записали вас на сдачу анализов...");
                }    
            }
            if(isKonsult)
            {
                Console.WriteLine("какая у вас проблема?...");
                string? problemStr = Console.ReadLine();
                string[]? problemStrArr = problemStr?.Split(' ');
                foreach (var item in problemStrArr)
                {
                    if(item.Trim().ToLower() == "живот" || item.Trim().ToLower().Contains("живот"))
                    {
                        isTerapevt = true;
                    }
                }

                if(isTerapevt)
                {
                    Console.WriteLine("Записали вас к терапевту... кабинет...");
                }
            }

            return true;
        }
    }
}