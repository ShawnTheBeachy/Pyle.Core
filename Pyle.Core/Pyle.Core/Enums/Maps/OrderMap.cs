using System;

namespace Pyle.Core.Enums.Maps
{
    internal static class OrderMap
    {
        internal static string Match(Order order)
        {
            switch (order)
            {
                case Order.Ascending:
                    return "asc";
                case Order.Descending:
                    return "desc";
                default:
                    throw new InvalidOperationException("Order must be one of type Ascending or Descending.");
            }
        }
    }
}
