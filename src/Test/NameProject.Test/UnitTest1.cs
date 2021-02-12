using NameProject.Domain.Util;
using System;
using System.Collections.Generic;
using Xunit;

namespace NameProject.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestNames()
        {
            var names = new List<string>() { "Joao Silva", "Joao Silva Neto", "Joao Neto", "Joao dos Santos", "Guimaraes" };
            var expected = new List<string>() { "SILVA, Joao", "SILVA NETO, Joao", "NETO, Joao", "SANTOS, Joao dos", "GUIMARAES" };

            var result = names.ConvertNames();

            Assert.Equal(expected, result);
        }
    }
}
