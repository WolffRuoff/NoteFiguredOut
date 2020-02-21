using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{

    private static Levels first = null;

    private Levels() { }

    private Dictionary<int, Queue<KeyValuePair<char, int>>> songs = new Dictionary<int, Queue<KeyValuePair<char, int>>>();

    void Start()
    {
        Queue<KeyValuePair<char, int>> level0 = new Queue<KeyValuePair<char, int>>();
        //Twinkle Twinkle Little Star
        level0.Enqueue(new KeyValuePair<char, int>('c', 4));
        level0.Enqueue(new KeyValuePair<char, int>('c', 4));
        level0.Enqueue(new KeyValuePair<char, int>('g', 4));
        level0.Enqueue(new KeyValuePair<char, int>('g', 4));
        level0.Enqueue(new KeyValuePair<char, int>('a', 4));
        level0.Enqueue(new KeyValuePair<char, int>('a', 4));
        level0.Enqueue(new KeyValuePair<char, int>('g', 4));
        level0.Enqueue(new KeyValuePair<char, int>('f', 4));
        level0.Enqueue(new KeyValuePair<char, int>('f', 4));
        level0.Enqueue(new KeyValuePair<char, int>('e', 4));
        level0.Enqueue(new KeyValuePair<char, int>('e', 4));
        level0.Enqueue(new KeyValuePair<char, int>('d', 4));
        level0.Enqueue(new KeyValuePair<char, int>('d', 4));
        level0.Enqueue(new KeyValuePair<char, int>('c', 4));
        level0.Enqueue(new KeyValuePair<char, int>('g', 4));
        level0.Enqueue(new KeyValuePair<char, int>('g', 4));
        level0.Enqueue(new KeyValuePair<char, int>('f', 4));
        level0.Enqueue(new KeyValuePair<char, int>('f', 4));
        level0.Enqueue(new KeyValuePair<char, int>('e', 4));
        level0.Enqueue(new KeyValuePair<char, int>('e', 4));
        level0.Enqueue(new KeyValuePair<char, int>('d', 4));
        level0.Enqueue(new KeyValuePair<char, int>('g', 4));
        level0.Enqueue(new KeyValuePair<char, int>('g', 4));
        level0.Enqueue(new KeyValuePair<char, int>('f', 4));
        level0.Enqueue(new KeyValuePair<char, int>('f', 4));
        level0.Enqueue(new KeyValuePair<char, int>('e', 4));
        level0.Enqueue(new KeyValuePair<char, int>('e', 4));
        level0.Enqueue(new KeyValuePair<char, int>('d', 4));
        level0.Enqueue(new KeyValuePair<char, int>('c', 4));
        level0.Enqueue(new KeyValuePair<char, int>('c', 4));
        level0.Enqueue(new KeyValuePair<char, int>('g', 4));
        level0.Enqueue(new KeyValuePair<char, int>('g', 4));
        level0.Enqueue(new KeyValuePair<char, int>('a', 4));
        level0.Enqueue(new KeyValuePair<char, int>('a', 4));
        level0.Enqueue(new KeyValuePair<char, int>('g', 4));
        level0.Enqueue(new KeyValuePair<char, int>('f', 4));
        level0.Enqueue(new KeyValuePair<char, int>('f', 4));
        level0.Enqueue(new KeyValuePair<char, int>('e', 4));
        level0.Enqueue(new KeyValuePair<char, int>('e', 4));
        level0.Enqueue(new KeyValuePair<char, int>('d', 4));
        level0.Enqueue(new KeyValuePair<char, int>('d', 4));
        level0.Enqueue(new KeyValuePair<char, int>('c', 4));
        songs.Add(0, level0);
    }
    

    public static Levels getInstance()
    {
        if (first == null)
        {
            first = new Levels();
        }

        return first;
    }

    public KeyValuePair<char, int> getNextNote(int levelNum)
    {

        return songs[levelNum].Dequeue();
    }
}
