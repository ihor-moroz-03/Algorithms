﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Enumeration
    {
        public static string CycleNext(this IEnumerator<string> enumerator)
        {
            if (enumerator.MoveNext()) return enumerator.Current;
            enumerator.Reset();
            if (!enumerator.MoveNext()) throw new ArgumentException("Enumerable is empty", nameof(enumerator));
            return enumerator.Current;
        }
    }
}
