using SimpleDiff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDiffTest
{
    public static class FakeData
    {
        public static readonly List<DiffItem> DifferentSizeItems = new()
        {
            new DiffItem { Id = 1, Type = DiffType.Left, Value = "Ales" },
            new DiffItem { Id = 1, Type = DiffType.Right, Value = "Ale" }
        };

        public static readonly List<DiffItem> EqualValuesItems = new()
        {
            new DiffItem { Id = 1, Type = DiffType.Left, Value = "Ales" },
            new DiffItem { Id = 1, Type = DiffType.Right, Value = "Ales" }
        };

        public static readonly List<DiffItem> SameLengthDifferentValuesItems = new ()
        {
            new DiffItem { Id = 1, Type = DiffType.Left, Value =    "sdasdasdasdzzdasdawtatsdaz" },
            new DiffItem { Id = 1, Type = DiffType.Right, Value =   "sdasdasdtwetwedasdawtatsdp" }
        };
    }
}
