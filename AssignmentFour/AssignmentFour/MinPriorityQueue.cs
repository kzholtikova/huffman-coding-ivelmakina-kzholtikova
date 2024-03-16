namespace Assignment4
{
    public class PriorityQueue
    {
        private List<MinHeapNode> _heapq = new();

        private int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        
        private int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }
        
        private int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }
        
        public void Enqueue(MinHeapNode node)
        {
            _heapq.Add(node);
            HeapifyUp(Count() - 1);
        }

        public MinHeapNode Dequeue()
        {
            if (_heapq.Count == 0)
            {
                throw new InvalidOperationException("Priority queue is empty.");
            }
        
            MinHeapNode minValue = _heapq[0];
            _heapq[0] = _heapq[Count() - 1];
            _heapq.RemoveAt(Count() - 1);
            HeapifyDown(0);
            
            return minValue;
        }

        private void Swap(int i, int j)
        {
            (_heapq[i], _heapq[j]) = (_heapq[j], _heapq[i]);
        }
        
        private void HeapifyUp(int index)
        {
            while (index > 0 && _heapq[index].Freq < _heapq[ParentIndex(index)].Freq)
            {
                Swap(index, ParentIndex(index));
                index = ParentIndex(index);
            }
        }
        
        private void HeapifyDown(int index)
        {
            int minIndex = index;
            
            if (LeftChildIndex(index) < _heapq.Count() && _heapq[LeftChildIndex(index)].Freq < _heapq[minIndex].Freq)
            {
                minIndex = LeftChildIndex(index);
            }

            if (RightChildIndex(index) < _heapq.Count() && _heapq[RightChildIndex(index)].Freq < _heapq[minIndex].Freq)
            {
                minIndex = RightChildIndex(index);
            }

            if (index != minIndex)
            {
                Swap(index, minIndex);
                HeapifyDown(minIndex);
            }
        }

        public int Count()
        {
            return _heapq.Count();
        }

        public override string ToString()
        {
            string heapqStr = "";
            for (int i = 0; i < _heapq.Count(); i++)
            {
                heapqStr += $"{_heapq[i]} ";
            }

            return heapqStr;
        }
    }
}
