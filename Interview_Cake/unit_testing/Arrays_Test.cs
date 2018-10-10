using System;
using Xunit;
using Xunit.Sdk;
using Xunit.Abstractions;
using System.Diagnostics;

namespace unit_testing001
{
    
    
    
    public class Arrays_Test
    {
    
        private readonly ITestOutputHelper output;
        
        public Arrays_Test(ITestOutputHelper output)
        {
            this.output = output;
        }
    
    
    
        [Fact]
        public void AAAAATest1()
        {
            output.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA\r\nBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
            Debug.WriteLine("Message...");
            Console.WriteLine("abcdefghijklmnopq");
            Assert.Equal("abc","abc");
            Console.WriteLine("abcdefghijklmnopq");
        }
    }
}
