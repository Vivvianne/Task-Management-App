using System;

namespace TaskManagement.Domain.Services
{
    /// <summary>
    /// Represents remote add test
    /// </summary>
    public class RemoteAdd : MarshalByRefObject
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
