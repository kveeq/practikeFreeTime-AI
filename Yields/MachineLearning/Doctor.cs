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
        travmatolog = 3,
    }

    public class Doctor
    {
        public Doctor(DoctorSpec spec = DoctorSpec.Null)
        {
            this.spec = spec;
            GetFreeDoctor();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public bool isKusulting { get; set; } = false;
        public DoctorSpec spec { get; set; }
        public int DoctorId { get; set; } // к какому доктору 

        private void GetFreeDoctor()
        {
            DoctorId = 0; // берем свободного врача
                          // все поля заполняем данными найденными из поиска свободного врача

            if (FindFreeDoctor())
            {
                Console.WriteLine($"Нашли для вас {spec}... кабинет...");
            }
            else // если не нашли 
            {
                Console.WriteLine($"свободных врачей пока нет");
            }
        }

        private bool FindFreeDoctor()
        {
            return true; // находим свободного врача по специальности
        }
    }
}
