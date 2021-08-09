using System;
using System.Collections.Generic;
using System.Linq;

namespace HW13.Task2.Queue
{
    abstract class CustomQueue<T>
    {
        private List<T> _queueItems = new List<T>();

        public void Enqueue(T queueItem)
        {
            _queueItems.Add(queueItem);
        }

        public T Dequeue()
        {
            T queueItem = _queueItems[0];
            _queueItems.RemoveAt(0);
            return queueItem;
        }

        public T Peek()
        {
            return _queueItems[0];
        }
    }
}
