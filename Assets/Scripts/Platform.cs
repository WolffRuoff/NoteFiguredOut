using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool active = false;
    public bool random = false;
    public int level = 0;
    public float timer = 2f;

    private char note;
    private AudioSource audiosource;
    private AudioClip sound;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();

        if (random)
        {

        }
        else
        {
            Levels curr = Levels.getInstance();
            KeyValuePair<char, int> ret = curr.getNextNote(level);
            note = ret.Key;
            //note = Notes.Note(ret);
        }

        audiosource.clip = sound;

    }

    void Update()
    {
        if (active)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                // player loses
            }

            // check for user input and if it matches
            // still need to do something for button on screen
            if (note == 'c')
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    // make player move to next platform
                }
            }
            else if (note == 'd')
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    // make player move to next platform
                }
            }
            else if (note == 'e')
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // make player move to next platform
                }
            }
            else if (note == 'f')
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // make player move to next platform
                }
            }
            else if (note == 'g')
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    // make player move to next platform
                }
            }
            else if (note == 'a')
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    // make player move to next platform
                }
            }
            else if (note == 'b')
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    // make player move to next platform
                }
            }
        }  
    }
}