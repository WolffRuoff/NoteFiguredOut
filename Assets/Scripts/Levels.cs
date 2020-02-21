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
        level0.Enqueue(new KeyValuePair<char, int>('a', 1));
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
