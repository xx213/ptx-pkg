using System;

namespace PTXClassLibrary
{
    internal class StubRectCalc_Engine
    {
        internal static DateTime CalculateNewDate(DateTime memDOL, int v)
        {
            return memDOL.AddDays(v);
            //throw new NotImplementedException();
        }
    }
}