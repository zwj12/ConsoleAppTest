using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Interop
{
    public class InteropTest
    {
        static public unsafe void unsafeTest()
        {
            int* p1, p2, p3;
            int var = 20;
            int* p = &var;
            Console.WriteLine("{0}", var);
            Console.WriteLine("{0}", *p);
            Console.WriteLine("{0}", (int)p);
        }

        static  public  void MarshalTest()
        {
            unsafe
            {
                int var = 20;
                int* p = &var;
                Console.WriteLine("{0}", var);
                Console.WriteLine("{0}", *p);
                Console.WriteLine("{0}", (int)p);
            }


            string stringA = "I seem to be turned around!";
            int copylen = stringA.Length;

            // Allocate HGlobal memory for source and destination strings
            IntPtr sptr = Marshal.StringToHGlobalAnsi(stringA);
            IntPtr dptr = Marshal.AllocHGlobal(copylen + 1);

            // The unsafe section where byte pointers are used.
            unsafe
            {
                byte* src = (byte*)sptr.ToPointer();
                byte* dst = (byte*)dptr.ToPointer();

                if (copylen > 0)
                {
                    // set the source pointer to the end of the string
                    // to do a reverse copy.
                    src += copylen - 1;

                    while (copylen-- > 0)
                    {
                        *dst++ = *src--;
                    }
                    *dst = 0;
                }
            }
            string stringB = Marshal.PtrToStringAnsi(dptr);

            Console.WriteLine("Original:\n{0}\n", stringA);
            Console.WriteLine("Reversed:\n{0}", stringB);

            // Free HGlobal memory
            Marshal.FreeHGlobal(dptr);
            Marshal.FreeHGlobal(sptr);
        }
    }
}
