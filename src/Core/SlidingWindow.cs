using System;
using System.Collections.Generic;

namespace Mjcheetham
{
    public sealed class SlidingWindow<T> : IDisposable
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly int _windowSize;

        private bool _isDisposed;

        private int _currentSize;
        private WindowElement _head;
        private WindowElement _tail;

        public SlidingWindow(IEnumerable<T> source, int windowSize)
        {
            _enumerator = source.GetEnumerator();
            _windowSize = windowSize;

            for (int i = 0; i < _windowSize; i++)
            {
                SlideNext();
            }
        }

        public int WindowSize => _windowSize;

        public T this[int i]
        {
            get
            {
                ThrowIfDisposed();
                ArgumentAssert.NonNegative(i, nameof(i));
                ArgumentAssert.LessThan(i, _windowSize, nameof(i));

                WindowElement element = _head;
                while (element != null && i-- > 0)
                {
                    element = element.Next;
                }

                if (element == null)
                {
                    throw new InvalidOperationException();
                }

                return element.Value;
            }
        }

        public bool SlideNext()
        {
            if (_enumerator.MoveNext())
            {
                var newElement = new WindowElement(_enumerator.Current);

                // Enqueue
                if (_tail != null)
                {
                    _tail.Next = newElement;
                }

                _tail = newElement;

                if (_head == null)
                {
                    _head = _tail;
                }
                _currentSize++;

                // Dequeue
                if (_currentSize > _windowSize)
                {
                    _head = _head.Next;
                    _currentSize = _windowSize;
                }

                return true;
            }

            return false;
        }

        public void Reset()
        {
            _enumerator.Reset();
            _head = null;
            _tail = null;
            _currentSize = 0;
        }

        #region IDisposable

        private void ThrowIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(SlidingWindow<T>));
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                _enumerator.Dispose();
            }
        }

        #endregion

        private sealed class WindowElement
        {
            public WindowElement(T value)
            {
                Value = value;
            }

            public readonly T Value;
            public WindowElement Next;
        }
    }
}
