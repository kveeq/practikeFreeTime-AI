using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.MachineLearning
{
    public class BloodAnaliz
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BloodAnalizTypes BloodAnalizType = BloodAnalizTypes.Null;
        public string handlingText;

        public BloodAnaliz(string inText)
        {
            handle(inText);
        }

        public object HandleText()
        {
            while (true)
            {
                if (BloodAnalizType == BloodAnalizTypes.Null)
                {
                    /*
                        ***
                        * спрашивать какой именно тип анализа крови они хотят делать
                        ***
                    */
                    Console.WriteLine("Скажите тип анализа крови: биохимия, клинический, общий");
                    string handlingStrBloodType = Console.ReadLine();
                    handle(handlingStrBloodType);
                }
                else
                {
                    Console.WriteLine("Пройдите в кабинет... ");
                    break;
                }
            }
            return true;
        }

        private void handle(string inText)
        {
            handlingText = inText;
            string[] strArr = handlingText.Split(' ');
            foreach (var item in strArr)
            {
                if (item.Contains("биохим"))
                {
                    BloodAnalizType = BloodAnalizTypes.BioHim;
                    break;
                }
                if (item.Contains("клинич"))
                {
                    BloodAnalizType = BloodAnalizTypes.Klinik;
                    break;
                }
                if (item.Contains("общ"))
                {
                    BloodAnalizType = BloodAnalizTypes.Common;
                }
            }
        }
    }

    public enum BloodAnalizTypes
    {
        Null = 0,
        BioHim = 1,
        Klinik = 2,
        Common = 3,
    }
}
