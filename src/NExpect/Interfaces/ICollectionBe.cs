using System.Collections.Generic;

namespace NExpect.Interfaces
{
    /// <summary>
    /// Provides the ".Be" grammar continuation for collections
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICollectionBe<T> : ICanAddMatcher<IEnumerable<T>>
    {
        /// <summary>
        /// Prepares to do an out-of-order match with an expected collection
        /// </summary>
        ICollectionEquivalent<T> Equivalent { get; }
    }
}