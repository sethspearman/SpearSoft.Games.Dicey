using NUnit.Framework;

namespace SpearSoft.Games.Dicey.GameEngine.Tests
{
    [TestFixture]
    public class DiceTests
    {
        [Test]
        public void DiceDieCountEqualsFive()
        {
            //arrange
            var dice = new Dice();

            //act - testing constructor
            
            //assert
            Assert.IsTrue(dice.Count==5);
        }

        [Test]
        public void Dice_ToByteArray_Return5ByteLength()
        {

            //arrange
            var d = new Dice();
            var result = true;

            //act - 100 rolls
            for (int i = 0; i < 100; i++)
            {
                d.Roll();

                byte[] bytes = d.ToByteArray();

                if (bytes.Length != 5)
                {
                    result = false;
                    break;
                }
            }

            //assert
            Assert.IsTrue(result);

        }

        [Test]
        public void Dice_ToByteArray_ConvertsDiceValuesToMatchingArray()
        {
            //arrange
            var d = new Dice();
            var result = true;

            //act - 100 rolls
            for (int i = 0; i < 100; i++)
            {
                d.Roll();

                byte[] bytes = d.ToByteArray();

                for (var index = 0; index < d.Count; index++)
                {
                    var die = d[index];
                    if (die.Value != bytes[index])
                    {
                        result = false;
                        break;
                    }
                }

                d.Roll();
            }

            //assert
            Assert.IsTrue(result);

        }
    }
}