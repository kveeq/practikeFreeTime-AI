using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.MachineLearning
{
    public enum DoctorSpec
    {
        Null = 0,
        Terapevt = 1,
        Hirurg = 2,
        Travmatolog = 3,
        Nevrolog = 4,
    }

    public class Doctor
    {
        public Doctor(bool onKonsult, DoctorSpec spec = DoctorSpec.Null)
        {
            this.spec = spec;
            GetFreeDoctor();
            OnKonsult = onKonsult;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        // консультирует ли врач
        public bool isKonsulting { get; set; } = false; 
        // пациент на консультацию? если врач не консультирует то и пациент не может к нему не консультацию
        public bool OnKonsult { get; set; } 
        public DoctorSpec spec { get; set; }
        public int DoctorId { get; set; } // к какому доктору 

        private void GetFreeDoctor()
        {
            DoctorId = 0; // берем свободного врача
                          // все поля заполняем данными найденными из поиска свободного врача

            if (FindFreeDoctor())
            {
                Class1.AnswerEvent?.Invoke($"Нашли для вас {spec}... кабинет...");
            }
            else // если не нашли 
            {
                Class1.AnswerEvent?.Invoke($"свободных врачей пока нет");
            }
        }

        private bool FindFreeDoctor()
        {
            return true; // находим свободного врача по специальности
        }
    }
}
