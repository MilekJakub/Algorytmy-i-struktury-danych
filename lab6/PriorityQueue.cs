namespace lab6
{
    class PriorityQueue
    {
        public static readonly int Capacity = 10;
        public int[] _arr;
        private int _last = -1;

        private int Left(int parentIndex) => parentIndex * 2 + 1;

        private int Right(int parentIndex) => parentIndex * 2 + 2;

        private int Parent(int child) => (child - 1) / 2;

        public bool Insert(int item)
        {
            //1. Add the element to the bottom level of the heap at the leftmost open space.
            //2. Compare the added element with its parent; if they are in the correct order, stop.
            //3. If not, swap the element with its parent and return to the previous step.
            if (_last == Capacity - 1)
                return false;

            _arr[++_last] = item;
            RebuildUp(_last);
            return true;
        }

        private void RebuildUp(int child)
        {
            while (child != 0)
            {
                int parent = Parent(child);
                if (_arr[parent] < _arr[child])
                {
                    (_arr[parent], _arr[child]) = (_arr[child], _arr[parent]);
                    child = parent;
                }
                else
                    break;
            }
        }

        private void RebuildDown()
        {
            int node = 0;
            while (node <= _last)
            {
                int leftValue = _arr[Left(node)];
                int rightValue = _arr[Right(node)];
                if (_arr[node] >= leftValue && _arr[node] >= rightValue)
                    break;

                if (leftValue > rightValue)
                {
                    //Switch the node value with leftValue
                }


                else
                {
                    //Switch the node value with righValue
                }
            }
        }

        public int Remove()
        {
            int removed = _arr[0];
            _arr[0] = _arr[_last--];
            RebuildDown();
            return removed;
        }

        public int Count() => _last + 1;
    }
}
