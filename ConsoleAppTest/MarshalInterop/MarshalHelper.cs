using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleAppTest.MarshalInterop
{
    public static class MarshalHelper
    {
        public static T ByteArrayToStruct<T>(byte[] byteArray, bool checkSize = true) where T : struct
        {
            T obj = default;
            int size = Marshal.SizeOf(obj);

            if (checkSize == true && byteArray.Length != size)
            {
                throw new ArgumentException($"Byte array size ({byteArray.Length}) does not match the size ({size}) of the struct {typeof(T)}");
            }

            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(byteArray, 0, ptr, size);
                obj = (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return obj;
        }

        public static byte[] StructToByteArray<T>(T obj) where T : struct
        {
            int size = Marshal.SizeOf(obj);
            byte[] byteArray = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(obj, ptr, true);
                Marshal.Copy(ptr, byteArray, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return byteArray;
        }
    }
}
