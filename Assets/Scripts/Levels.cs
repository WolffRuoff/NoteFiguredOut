using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{

    private static Levels first;

    private Levels() { }

    private Dictionary<int, Queue<KeyValuePair<char, int>>> songs = new Dictionary<int, Queue<KeyValuePair<char, int>>>();

    void Start()
    {
        first = null;
    }

    public static ref Levels getInstance()
    {
        if (first == null)
        {
            first = new Levels();
            //Twinkle Twinkle Little Star
            Queue<KeyValuePair<char, int>> level1 = new Queue<KeyValuePair<char, int>>();
            level1.Enqueue(new KeyValuePair<char, int>('c', 4));
            level1.Enqueue(new KeyValuePair<char, int>('c', 4));
            level1.Enqueue(new KeyValuePair<char, int>('g', 4));
            level1.Enqueue(new KeyValuePair<char, int>('g', 4));
            level1.Enqueue(new KeyValuePair<char, int>('a', 4));
            level1.Enqueue(new KeyValuePair<char, int>('a', 4));
            level1.Enqueue(new KeyValuePair<char, int>('g', 4));
            level1.Enqueue(new KeyValuePair<char, int>('f', 4));
            level1.Enqueue(new KeyValuePair<char, int>('f', 4));
            level1.Enqueue(new KeyValuePair<char, int>('e', 4));
            level1.Enqueue(new KeyValuePair<char, int>('e', 4));
            level1.Enqueue(new KeyValuePair<char, int>('d', 4));
            level1.Enqueue(new KeyValuePair<char, int>('d', 4));
            level1.Enqueue(new KeyValuePair<char, int>('c', 4));
            level1.Enqueue(new KeyValuePair<char, int>('g', 4));
            level1.Enqueue(new KeyValuePair<char, int>('g', 4));
            level1.Enqueue(new KeyValuePair<char, int>('f', 4));
            level1.Enqueue(new KeyValuePair<char, int>('f', 4));
            level1.Enqueue(new KeyValuePair<char, int>('e', 4));
            level1.Enqueue(new KeyValuePair<char, int>('e', 4));
            level1.Enqueue(new KeyValuePair<char, int>('d', 4));
            level1.Enqueue(new KeyValuePair<char, int>('g', 4));
            level1.Enqueue(new KeyValuePair<char, int>('g', 4));
            level1.Enqueue(new KeyValuePair<char, int>('f', 4));
            level1.Enqueue(new KeyValuePair<char, int>('f', 4));
            level1.Enqueue(new KeyValuePair<char, int>('e', 4));
            level1.Enqueue(new KeyValuePair<char, int>('e', 4));
            level1.Enqueue(new KeyValuePair<char, int>('d', 4));
            level1.Enqueue(new KeyValuePair<char, int>('c', 4));
            level1.Enqueue(new KeyValuePair<char, int>('c', 4));
            level1.Enqueue(new KeyValuePair<char, int>('g', 4));
            level1.Enqueue(new KeyValuePair<char, int>('g', 4));
            level1.Enqueue(new KeyValuePair<char, int>('a', 4));
            level1.Enqueue(new KeyValuePair<char, int>('a', 4));
            level1.Enqueue(new KeyValuePair<char, int>('g', 4));
            level1.Enqueue(new KeyValuePair<char, int>('f', 4));
            level1.Enqueue(new KeyValuePair<char, int>('f', 4));
            level1.Enqueue(new KeyValuePair<char, int>('e', 4));
            level1.Enqueue(new KeyValuePair<char, int>('e', 4));
            level1.Enqueue(new KeyValuePair<char, int>('d', 4));
            level1.Enqueue(new KeyValuePair<char, int>('d', 4));
            level1.Enqueue(new KeyValuePair<char, int>('c', 4));
            first.songs.Add(1, level1);

            Queue<KeyValuePair<char, int>> level2 = new Queue<KeyValuePair<char, int>>();
            level2.Enqueue(new KeyValuePair<char, int>('e', 5));
            level2.Enqueue(new KeyValuePair<char, int>('a', 4));
            level2.Enqueue(new KeyValuePair<char, int>('b', 4));
            level2.Enqueue(new KeyValuePair<char, int>('c', 5));
            level2.Enqueue(new KeyValuePair<char, int>('d', 5));
            level2.Enqueue(new KeyValuePair<char, int>('e', 5));
            level2.Enqueue(new KeyValuePair<char, int>('c', 5));
            level2.Enqueue(new KeyValuePair<char, int>('e', 5));
            level2.Enqueue(new KeyValuePair<char, int>('a', 4));
            level2.Enqueue(new KeyValuePair<char, int>('c', 5));
            level2.Enqueue(new KeyValuePair<char, int>('a', 4));
            level2.Enqueue(new KeyValuePair<char, int>('f', 4));
            level2.Enqueue(new KeyValuePair<char, int>('c', 5));
            level2.Enqueue(new KeyValuePair<char, int>('a', 4));
            //2nd half
            level2.Enqueue(new KeyValuePair<char, int>('d', 5));
            level2.Enqueue(new KeyValuePair<char, int>('c', 5));
            level2.Enqueue(new KeyValuePair<char, int>('b', 4));
            level2.Enqueue(new KeyValuePair<char, int>('a', 5));
            level2.Enqueue(new KeyValuePair<char, int>('a', 4));
            level2.Enqueue(new KeyValuePair<char, int>('b', 4));
            level2.Enqueue(new KeyValuePair<char, int>('c', 5));
            level2.Enqueue(new KeyValuePair<char, int>('d', 5));
            level2.Enqueue(new KeyValuePair<char, int>('e', 5));
            level2.Enqueue(new KeyValuePair<char, int>('c', 5));
            level2.Enqueue(new KeyValuePair<char, int>('e', 5));
            level2.Enqueue(new KeyValuePair<char, int>('a', 4));
            level2.Enqueue(new KeyValuePair<char, int>('c', 5));
            level2.Enqueue(new KeyValuePair<char, int>('a', 4));
            level2.Enqueue(new KeyValuePair<char, int>('f', 4));
            level2.Enqueue(new KeyValuePair<char, int>('c', 5));
            level2.Enqueue(new KeyValuePair<char, int>('a', 4));

            first.songs.Add(2, level2);
        }

        return ref first;
    }

    public KeyValuePair<char, int> getNextNote(int levelNum)
    {

        return songs[levelNum].Dequeue();
    }

    public bool isEmpty(int levelNum)
    {
        return songs[levelNum].Count == 0;
    }
}
