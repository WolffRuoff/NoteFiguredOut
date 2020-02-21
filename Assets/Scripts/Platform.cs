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

    void OnCollisionEnter2D(Collision2D collision)
    {
        KeyValuePair<char, int> pair;
        if (random)
        {
            int octave = Random.Range(1, 7);
            int randNote = Random.Range(1, 7);

            if (randNote == 1)
            {
                note = 'c';
            } else if (randNote == 2)
            {
                note = 'd';
            } else if (randNote == 3)
            {
                note = 'e';
            } else if (randNote == 4)
            {
                note = 'f';
            } else if (randNote == 5)
            {
                note = 'g';
            } else if (randNote == 6)
            {
                note = 'a';
            } else if (randNote == 7)
            {
                note = 'b';
            }

            pair = new KeyValuePair<char, int>(note, octave);
        }
        else
        {
            Levels curr = Levels.getInstance();
            pair = curr.getNextNote(level);
            note = pair.Key;
        }

        Notes.Note(pair);
        active = true;
    }
}