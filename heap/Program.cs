using System.Reflection.Metadata;

class Heap
{
    public Heap(List<int> heap)
    {
        this.heap = heap;
        heap_size = heap.Count;
    }

    private List<int> heap;
    private int heap_size;

    #region heap

    //sift_down
    void max_heapify(int i)
    {
        var l = 2 * i + 1;
        var r = 2 * i + 2;
        var largest = i;
        if (l < heap_size && heap[l] > heap[i])
            largest = l;
        if (r < heap_size && heap[r] > heap[largest])
            largest = r;
        if (largest != i)
        {
            (heap[i], heap[largest]) = (heap[largest], heap[i]);
            max_heapify(largest);
        }
    }

    void min_heapify(int i)
    {
        var l = 2 * i + 1;
        var r = 2 * i + 2;
        var largest = i;
        if (l < heap_size && heap[l] < heap[i])
            largest = l;
        if (r < heap_size && heap[r] < heap[largest])
            largest = r;
        if (largest != i)
        {
            (heap[i], heap[largest]) = (heap[largest], heap[i]);
            min_heapify(largest);
        }
    }

    public void build_max_heap()
    {
        for (int i = heap_size / 2; i >= 0; --i)
            max_heapify(i);
    }

    //build heap with inserts
    public int[] build_max_heap_with_insert(List<int> a)
    {
        for (var i = a.Count - 1; i >= 0; --i)
        {
            insert(a[i]);
        }

        return a.ToArray();
    }

    public void build_min_heap()
    {
        for (int i = heap_size; i >= 0 ; --i)
            min_heapify(i);
    }

    public void sort()
    {
        for (int i = heap.Count - 1; i > 0; --i)
        {
            (heap[i], heap[0]) = (heap[0], heap[i]);
            heap_size--;
            max_heapify(0);
        }
    }
    #endregion
    
    #region priority_queue
    public int max => heap[0];
    public int remove_max()
    {
        if (heap_size < 1)
        {
            Console.WriteLine("Queue is empty.");
            return -1;
        }
        var maximum = max;
        heap[0] = heap[heap_size - 1];
        heap_size--;
        max_heapify(0);
        return maximum;
    }

    public void increase_key(int i, int k)
    {
        if (heap[i] >= k)
        {
            Console.WriteLine("Previous key is bigger than new");
            return;
        }
        heap[i] = k;
        while (i >= 0 && heap[(i-1)/2] < heap[i])
        {
            (heap[i], heap[(i-1) / 2]) = (heap[(i-1) / 2], heap[i]);
            max_heapify(0);
            i = i / 2;
        }
    }

    public void insert(int k)
    {
        heap_size++;
        heap.Add(int.MinValue);
        increase_key(heap_size - 1, k);
    }
    #endregion
    
    public void print() => Console.WriteLine(string.Join(" ", heap));
}
class Program
{
    static void Main(string[] args)
    {
        var a = new List<int>() {16,14, 10, 8, 7, 9, 3, 2, 4, 1};
        var heap = new Heap(a);
        //heap.build_max_heap();
        //heap.print();
        Console.WriteLine(new string('-', 15));
        
        //Console.WriteLine(String.Join(" ", heap.build_max_heap_with_insert(a)));
        //Console.WriteLine($"{heap.remove_max()} is deleted");
        //heap.increase_key(8,15);
        //heap.insert(10);
        //heap.print();
    }
}