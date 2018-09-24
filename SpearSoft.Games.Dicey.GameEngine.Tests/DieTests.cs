using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;

namespace SpearSoft.Games.Dicey.GameEngine.Tests
{
    [TestFixture()]
    public class DieTests
    {
        [Test]
        public void DieRoll_MaxValue_NotGreaterThan6()
        {
            //arrange
            var d = new Die(1);
            var result = true;
            //act
            for (int i = 0; i < 1000; i++)
            {
                d.Roll();
                if (d.Value>6)
                {
                    result = false;
                    Debug.WriteLine(d.Value.ToString());
                    break;
                }
            }

            Assert.IsTrue(result,"roll method produced value higher than 6");
            
        }

        [Test]
        public void DieRoll_MinValue_NotLessThanOrEqualToZero()
        {
            //arrange
            var d = new Die(1);
            var result = true;
            //act
            for (int i = 0; i < 1000; i++)
            {
                d.Roll();
                if (d.Value <= 0)
                {
                    result = false;
                    Debug.WriteLine(d.Value.ToString());
                    break;
                }
            }
            
            //assert
            Assert.IsTrue(result, "roll method produced value that is less than or equal to 0");
        }

        [Test]
        public void LockedDie_Roll_DoesNotChangeValue()
        {
            //arrange
            var d = new Die (1) {Locked = true};
            var result = true;

            //act
            var currentValue = d.Value;
            for (int i = 0; i < 100; i++)
            {
                d.Roll();
                if (d.Value!=currentValue)
                {
                    result = false;
                    break;
                }
            }

            //assert
            Assert.IsTrue(result);

        }
    }
}