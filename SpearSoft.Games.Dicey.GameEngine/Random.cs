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

        public static void GetByte(Die die)
        {
            var i = Generator.Next(1,6);
            var result = Convert.ToByte(i);

            die.Value = result;

        }

        //public static byte[] GetBytes()
        //{
        //    byte[] array = new byte[4];

        //    Generator.NextBytes(array);
        //    return array;
        //}


    }
}
