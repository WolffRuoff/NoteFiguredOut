using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    public bool random = false;
    public int level = 0;
    public float timer = 2f;

    private bool active = false;
    private KeyValuePair<char, int> pair;
    private int selection = -1;

    void Update()
    {
        if (active)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                if (selection == 0 && pair.Key == 'c')
                {
                    // make player move to next platform
                }
                else if (selection == 1 && pair.Key == 'd')
                {
                    // make player move to next platform
                }
                else if (selection == 2 && pair.Key == 'e')
                {
                    // make player move to next platform
                }
                else if (selection == 3 && pair.Key == 'f')
                {
                    // make player move to next platform
                }
                else if (selection == 4 && pair.Key == 'g')
                {
                    // make player move to next platform
                }
                else if (selection == 5 && pair.Key == 'a')
                {
                    // make player move to next platform
                }
                else if (selection == 6 && pair.Key == 'b')
                {
                    // make player move to next platform
                }
                else
                {
                    // wrong answer -- player loses
                    // maybe add a fade to black?
                    // not sure if we wanna restart current level or return to main menu
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    selection = 0;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    selection = 1;
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    selection = 2;
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    selection = 3;
                }
                else if (Input.GetKeyDown(KeyCode.G))
                {
                    selection = 4;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    selection = 5;
                }
                else if (Input.GetKeyDown(KeyCode.B))
                {
                    selection = 6;
                }
            }
        }  
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            KeyValuePair<char, int> pair;
            if (random)
            {
                char note;
                int octave = Random.Range(1, 7);
                int randNote = Random.Range(1, 7);

                if (randNote == 1)
                {
                    note = 'c';
                }
                else if (randNote == 2)
                {
                    note = 'd';
                }
                else if (randNote == 3)
                {
                    note = 'e';
                }
                else if (randNote == 4)
                {
                    note = 'f';
                }
                else if (randNote == 5)
                {
                    note = 'g';
                }
                else if (randNote == 6)
                {
                    note = 'a';
                }
                else
                {
                    note = 'b';
                }

                pair = new KeyValuePair<char, int>(note, octave);
            }
            else
            {
                Levels curr = Levels.getInstance();
                pair = curr.getNextNote(level);
            }

            Notes.Instance.Note(pair);
            active = true;
        }
        else
        {
            Levels curr = Levels.getInstance();
            pair = curr.getNextNote(level);
            note = pair.Key;
        }

        Notes.Instance.Note(pair);
        active = true;
    }
}