using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Hanoy10012018
{
    class MyStack
    {
        ArrayList ar = new ArrayList();
        int size = 0;

        public int PopStack()//Взять кольцо
        {
            int e = Convert.ToInt32(ar[size-1]);
            ar.RemoveAt(size-1);
            size--;
            return e;
        }

      public void PushStack(int e)//положить кольцо
        {
            ar.Add(e);
            size++;
        }

      public bool StackIsEmpty()
        {
            if (size > 0)
                return false;
            else
                return true;
        }
    }
}
