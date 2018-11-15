using System;
using Xunit;

namespace LinqUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.False(true);
        }
    }
}
