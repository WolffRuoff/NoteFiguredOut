using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{

    private static Levels _instance;
    private static bool first = true;

    private Levels() { }

    private Dictionary<int, Queue<KeyValuePair<char, int>>> songs = new Dictionary<int, Queue<KeyValuePair<char, int>>>();

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
            _instance.songs.Add(2, level2);

            first = false;

        }

        return _instance;
    }

    public KeyValuePair<char, int> getNextNote(int levelNum)
    {
        // returns the next note to assign to a platform
        return _instance.songs[levelNum].Dequeue();
    }

    public bool isEmpty(int levelNum)
    {
        // returns whether or not the song is over
        return _instance.songs[levelNum].Count == 0;
    }

    public static void setFirst ()
    {
        // since the singleton object is static, need to reset when scene restarts
        // called whenever the player loses
        first = true;
    }
}
