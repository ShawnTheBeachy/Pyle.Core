using System;

namespace Pyle.Core.Enums.Maps
{
    internal static class SortMap
    {
        internal static string Match(Sort sort)
        {
            switch (sort)
            {
                case Sort.Activity:
                    return "activity";
                case Sort.Creation:
                    return "creation";
                case Sort.Votes:
                    return "votes";
                default:
                    throw new InvalidOperationException("Sort must be one of type Activity, Creation or Votes.");
            }
        }
    }
}
