using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MinHeap<T> where T : IComparable<T>
{ 
    private List<T> heap;

    public MinHeap()
    {
        heap = new List<T>();
    }

    public int Count => heap.Count;

    public void Insert(T item)
    {
        heap.Add(item);
        HeapifyUp(heap.Count - 1);
    }

    public T ExtractMin()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("The heap is empty.");

        T minItem = heap[0];
        int lastIndex = heap.Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);
        HeapifyDown(0);
        return minItem;
    }

    public T GetMin()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("The heap is empty.");

        return heap[0];
    }

    public bool IsEmpty()
    {
        return heap.Count == 0;
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (heap[index].CompareTo(heap[parentIndex]) >= 0)
                break;

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        int leftChildIndex = 2 * index + 1;
        int rightChildIndex = 2 * index + 2;
        int smallestIndex = index;

        if (leftChildIndex < heap.Count && heap[leftChildIndex].CompareTo(heap[smallestIndex]) < 0)
            smallestIndex = leftChildIndex;

        if (rightChildIndex < heap.Count && heap[rightChildIndex].CompareTo(heap[smallestIndex]) < 0)
            smallestIndex = rightChildIndex;

        if (smallestIndex != index)
        {
            Swap(index, smallestIndex);
            HeapifyDown(smallestIndex);
        }
    }

    private void Swap(int i, int j)
    {
        T temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
   
}
