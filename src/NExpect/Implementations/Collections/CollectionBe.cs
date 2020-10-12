using System;
using System.Collections.Generic;
using NExpect.Implementations.Fluency;
using NExpect.Implementations.Strings;
using NExpect.Interfaces;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global

namespace NExpect.Implementations.Collections
{
    internal class CollectionBe<T> :
        ExpectationContextWithLazyActual<IEnumerable<T>>,
        IHasActual<IEnumerable<T>>,
        ICollectionBe<T>
    {
        public ICollectionEquivalent<T> Equivalent =>
            ContinuationFactory.Create<IEnumerable<T>, CollectionEquivalent<T>>(ActualFetcher, this);

        public ICollectionEqual<T> Equal =>
            ContinuationFactory.Create<IEnumerable<T>, CollectionEqual<T>>(ActualFetcher, this);

        public ICollectionDeep<T> Deep =>
            ContinuationFactory.Create<IEnumerable<T>, CollectionDeep<T>>(ActualFetcher, this);

        public ICollectionIntersection<T> Intersection =>
            ContinuationFactory.Create<IEnumerable<T>, CollectionIntersection<T>>(ActualFetcher, this);

        public ICollectionAn<T> An =>
            ContinuationFactory.Create<IEnumerable<T>, CollectionAn<T>>(ActualFetcher, this);

        public ICollectionFor<T> For =>
            ContinuationFactory.Create<IEnumerable<T>, CollectionFor<T>>(ActualFetcher, this);

        public ICollectionOrdered<T> Ordered =>
            ContinuationFactory.Create<IEnumerable<T>, CollectionOrdered<T>>(ActualFetcher, this);

        public CollectionBe(Func<IEnumerable<T>> actualFetcher) : base(actualFetcher)
        {
        }
    }
}