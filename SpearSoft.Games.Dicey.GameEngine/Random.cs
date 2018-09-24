using System;
using System.Collections.Generic;
using System.Text;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public static class Rand
    {
        private static Random Generator { get; set; }

        static Rand()
        {
            Generator = new Random();
        }

        public static byte GetByte()
        {
            var i = Generator.Next(1,6);
            var result = Convert.ToByte(i);

            return result;

        }

        //public static byte[] GetBytes()
        //{
        //    byte[] array = new byte[4];

        //    Generator.NextBytes(array);
        //    return array;
        //}


    }
}
