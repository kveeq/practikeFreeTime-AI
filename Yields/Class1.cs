using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields
{
    public class Class1 : IComparer
    {
        public void Sort(Array mark)
        {
            for (int? j = 0; j < mark.Length; j++)
            {
                for (int i = 0; i < mark.Length - 1; i++)
                {
                    //if (mark.GetValue(i).CompareTo(mark.GetValue(i + 1)) > 0)
                    //{
                    //    // для swap используется кортеж
                    //    (mark[i + 1], mark[i]) = (mark[i], mark[i + 1]);
                    //}
                }
            }
        }

        public int CompareTo(Array? other)
        {
            throw new NotImplementedException();
        }

        public int Compare(object? x, object? y)
        {
            throw new NotImplementedException();
        }
    }
}
