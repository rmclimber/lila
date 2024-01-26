using Lila;

namespace LilaTests
{
    public class SimpleLabelTests
    {
        private string goodNameOrPath = "foo";
        private string goodPositive = "3";
        private string goodNegative = "-3";
        private string badFloat = "3.56";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyName()
        {
            var ex = Assert.Throws<ArgumentException>(() => new SimpleLabel(
                "", goodNameOrPath, goodPositive));
        }
        
        [Test]
        public void EmptyPath()
        {
            var ex = Assert.Throws<ArgumentException>(() => new SimpleLabel(
                goodNameOrPath, "", goodPositive));
        }

        
        [Test]
        public void GoodNameAndPath()
        {
            SimpleLabel sl = new SimpleLabel(goodNameOrPath, goodNameOrPath, goodPositive);
            Assert.That(sl.ImgName, Is.EqualTo(goodNameOrPath));
            Assert.That(sl.ImgPath, Is.EqualTo(goodNameOrPath));
        }

        [Test]
        public void BadFloatLabel()
        {
            var ex = Assert.Throws<ArgumentException>(() => new SimpleLabel(
                goodNameOrPath, goodNameOrPath, badFloat));
        }

        [Test]
        public void GoodIntLabels()
        {
            SimpleLabel sl = new SimpleLabel(goodNameOrPath, goodNameOrPath, goodPositive);
            Assert.That(sl.Label, Is.EqualTo(goodPositive));
            sl.Label = goodNegative;
            Assert.That(sl.Label, Is.EqualTo(goodNegative));
        }
    }
}