﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    private static AudioSource c1;
    private static AudioSource c2;
    private static AudioSource c3;
    private static AudioSource c4;
    private static AudioSource c5;
    private static AudioSource c6;
    private static AudioSource c7;

    static AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static AudioSource Note(char i, int octave)
    {
        if (octave == 1) sound = c1;
        if (octave == 2) sound = c2;
        if (octave == 3) sound = c3;
        if (octave == 4) sound = c4;
        if (octave == 5) sound = c5;
        if (octave == 6) sound = c6;
        if (octave == 7) sound = c7;

        if(i == 'c')
        {
            return sound;
        }

        else if(i == 'd')
        {
            sound.pitch = Mathf.Pow(1.05946f, 2f);
            return sound;
        }

        else if(i == 'e')
        {
            sound.pitch = Mathf.Pow(1.05946f, 4f);
            return sound;
        }

        else if(i == 'f')
        {
            sound.pitch = Mathf.Pow(1.05946f, 5f);
            return sound;
        }

        else if(i == 'g')
        {
            sound.pitch = Mathf.Pow(1.05946f, 7f);
            return sound;
        }

        else if(i == 'a')
        {
            sound.pitch = Mathf.Pow(1.05946f, 9f);
            return sound;
        }

        else if(i == 'b')
        {
            sound.pitch = Mathf.Pow(1.05946f, 11f);
            return sound;
        }
        else
            return sound;
    }
    public static AudioSource C(int octave)
    {
        if (octave == 1) sound = c1;
        if (octave == 2) sound = c2;
        if (octave == 3) sound = c3;
        if (octave == 4) sound = c4;
        if (octave == 5) sound = c5;
        if (octave == 6) sound = c6;
        if (octave == 7) sound = c7;

        return sound;
    }
    public static AudioSource D(int octave)
    {
        if (octave == 1) sound = c1;
        if (octave == 2) sound = c2;
        if (octave == 3) sound = c3;
        if (octave == 4) sound = c4;
        if (octave == 5) sound = c5;
        if (octave == 6) sound = c6;
        if (octave == 7) sound = c7;

        sound.pitch = Mathf.Pow(1.05946f, 2f);
        return sound;
    }
    public static AudioSource E(int octave)
    {
        if (octave == 1) sound = c1;
        if (octave == 2) sound = c2;
        if (octave == 3) sound = c3;
        if (octave == 4) sound = c4;
        if (octave == 5) sound = c5;
        if (octave == 6) sound = c6;
        if (octave == 7) sound = c7;

        sound.pitch = Mathf.Pow(1.05946f, 4f);
        return sound;
    }
    public static AudioSource F(int octave)
    {
        if (octave == 1) sound = c1;
        if (octave == 2) sound = c2;
        if (octave == 3) sound = c3;
        if (octave == 4) sound = c4;
        if (octave == 5) sound = c5;
        if (octave == 6) sound = c6;
        if (octave == 7) sound = c7;

        sound.pitch = Mathf.Pow(1.05946f, 5f);
        return sound;
    }
    public static AudioSource G(int octave)
    {
        if (octave == 1) sound = c1;
        if (octave == 2) sound = c2;
        if (octave == 3) sound = c3;
        if (octave == 4) sound = c4;
        if (octave == 5) sound = c5;
        if (octave == 6) sound = c6;
        if (octave == 7) sound = c7;

        sound.pitch = Mathf.Pow(1.05946f, 7f);
        return sound;
    }
    public static AudioSource A(int octave)
    {
        if (octave == 1) sound = c1;
        if (octave == 2) sound = c2;
        if (octave == 3) sound = c3;
        if (octave == 4) sound = c4;
        if (octave == 5) sound = c5;
        if (octave == 6) sound = c6;
        if (octave == 7) sound = c7;

        sound.pitch = Mathf.Pow(1.05946f, 9f);
        return sound;
    }
    public static AudioSource B(int octave)
    {
        if (octave == 1) sound = c1;
        if (octave == 2) sound = c2;
        if (octave == 3) sound = c3;
        if (octave == 4) sound = c4;
        if (octave == 5) sound = c5;
        if (octave == 6) sound = c6;
        if (octave == 7) sound = c7;

        sound.pitch = Mathf.Pow(1.05946f, 11f);
        return sound;
    }
}
