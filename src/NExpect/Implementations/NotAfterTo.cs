﻿namespace NExpect
{
    public class NotAfterTo<T>: ExpectationContext<T>, INotAfterTo<T>
    {
        public T Actual { get; }
        public NotAfterTo(T actual)
        {
            Actual = actual;
            Negate();
        }
    }
}