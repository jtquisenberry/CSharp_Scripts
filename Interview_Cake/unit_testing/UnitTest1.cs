using System;
using Xunit;

namespace unit_testing
{
    
    
    
    public class UnitTest1
    {
    
        public UnitTest1()
        {
            
        }
    
    
    
        [Fact]
        public void Test1()
        {
            Assert.Equal("abc","abc");
        }
    }
}
