using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{

    public AudioClip c1;
    public AudioClip c2;
    public AudioClip c3;
    public AudioClip c4;
    public AudioClip c5;
    public AudioClip c6;
    public AudioClip c7;

    private static Notes _instance;

    public static Notes Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject note = new GameObject("Notes");
                note.AddComponent<Notes>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void Note(char note, int octive)
    {
        if (octive == 1) { sound.clip = c1; }
        if (octive == 2) { sound.clip = c2; }
        if (octive == 3) { sound.clip = c3; }
        if (octive == 4) { sound.clip = c4; }
        if (octive == 5) { sound.clip = c5; }
        if (octive == 6) { sound.clip = c6; }
        if (octive == 7) { sound.clip = c7; }

        if(note == 'c')
        {
            sound.pitch = Mathf.Pow(1.05946f, 1f);
        }
        else if(note == 'd')
        {
            sound.pitch = Mathf.Pow(1.05946f, 2f);
        }

        else if(note == 'e')
        {
            sound.pitch = Mathf.Pow(1.05946f, 4f);
        }

        else if(note == 'f')
        {
            sound.pitch = Mathf.Pow(1.05946f, 5f);
        }

        else if(note == 'g')
        {
            sound.pitch = Mathf.Pow(1.05946f, 7f);
        }

        else if(note == 'a')
        {
            sound.pitch = Mathf.Pow(1.05946f, 9f);
        }

        else if(note == 'b')
        {
            sound.pitch = Mathf.Pow(1.05946f, 11f);
        }
        sound.Play();
    }

    public void setActive(bool tf)
    {
        sound.enabled = tf;
    }
}
