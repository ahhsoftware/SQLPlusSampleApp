using NUnit.Framework;
using System;

namespace SqlPlusDemo.Tests
{
    public class MiscTests
    {
        [Test]
        public void GetDateTest()
        {
            var output = ServiceFactory.Data().GetSQLDateTime();
            Console.WriteLine(output.ReturnValue);
        }
    }
}
