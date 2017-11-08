using System;

namespace Pyle.Core
{
    public class ClientResponse<T>
    {
        public Error Error { get; set; }
        public bool HasMore { get; set; }
        public T Response { get; set; }

        internal object FirstOrDefault() => throw new NotImplementedException();
    }
}
