﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Framework.Infrastructure.MessageBus.RabbitMQ
{
    public class DefaultClusterHostSelectionStrategy<T> : IClusterHostSelectionStrategy<T>, IEnumerable<T>
    {
        private readonly IList<T> items = new List<T>();
        private int currentIndex = 0;
        private int startIndex = 0;

        public virtual void Add(T item)
        {
            items.Add(item);
            startIndex = items.Count - 1;
        }

        public virtual T Current()
        {
            if (items.Count == 0)
            {
                throw new Exception("No items in collection");
            }

            return items[currentIndex];
        }

        public virtual bool Next()
        {
            if (currentIndex == startIndex) return false;
            if (Succeeded) return false;

            IncrementIndex();

            return true;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Success()
        {
            Succeeded = true;
            startIndex = currentIndex;
        }

        public virtual bool Succeeded { get; private set; }

        private bool firstUse = true;

        public DefaultClusterHostSelectionStrategy()
        {
            Succeeded = false;
        }

        public virtual void Reset()
        {
            Succeeded = false;
            if (firstUse)
            {
                firstUse = false;
                return;
            }
            IncrementIndex();
        }

        private void IncrementIndex()
        {
            currentIndex++;
            if (currentIndex == items.Count)
            {
                currentIndex = 0;
            }
        }
    }
}
