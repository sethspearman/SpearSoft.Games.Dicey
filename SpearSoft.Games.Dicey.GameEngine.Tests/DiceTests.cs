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
    }
}