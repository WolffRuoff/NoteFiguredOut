using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{

    private static Levels _instance;
    private static bool first = true;

    private Levels() { }

    private Dictionary<int, Queue<KeyValuePair<char, int>>> songs = new Dictionary<int, Queue<KeyValuePair<char, int>>>();

    void Start()
    {

    }

    public static Levels getInstance()
    {
        if (first)
        {
            _instance = new Levels();
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
            _instance.songs.Add(1, level1);

            //Queue<KeyValuePair<char, int>> level2 = new Queue<KeyValuePair<char, int>>();
            //level2.Enqueue(new KeyValuePair<char, int>('b', 5));

            first = false;
        }

        return _instance;
    }

    public KeyValuePair<char, int> getNextNote(int levelNum)
    {

        return _instance.songs[levelNum].Dequeue();
    }

    public bool isEmpty(int levelNum)
    {
        return _instance.songs[levelNum].Count == 0;
    }

    public static void setFirst ()
    {
        first = true;
    }
}
