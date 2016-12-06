using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] arr = new[] {1, 4, 3, 676, 213, 12, 5, 9};
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }

            PriorityQueue a = new PriorityQueue(arr);

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ",a.getMax());
            }

            Console.ReadLine();
        }
    }

    class PriorityQueue
    {
        private int[] heap;
        private int N;

        public PriorityQueue(int maxN=1000)
        {
            heap = new int[maxN];
            N = 0;
        }

        public PriorityQueue(int[] a):this(a.Length+1)
        {
            for (int i = 0; i < a.Length; i++)
            {
                this.Insert(a[i]);
            }
        }

        public void Insert(int k)
        {
            if (N + 1 == heap.Length)
            {
                throw new Exception();
            }
            heap[++N] = k;
            heapUp(N);
        }

        public int getMax()
        {
            int rez = heap[1];
            heap[1] = heap[N];
            heapDown(1);
            N--;
            return rez;
        }

        void heapUp(int k)
        {
            while (k > 1 && heap[k] > heap[k / 2])
            {
                swap(k,k/2);
                k = k / 2;
            }
        }

        void heapDown(int k)
        {
            while (2 * k <= N)
            {
                if ((2*k + 1 <= N) && (heap[k] < heap[2*k + 1])&&(heap[2*k]<heap[2*k+1]))
                {
                    swap(k, 2 * k + 1);
                    k = 2 * k + 1;
                    continue;
                }
                if (heap[k] < heap[2 * k])
                {
                    swap(k, 2 * k);
                    k = 2 * k;
                    continue;
                }
                
                return;
            }
        }

        void swap(int n, int k)
        {
            heap[0] = heap[n];
            heap[n] = heap[k];
            heap[k] = heap[0];
        }

    }
}
