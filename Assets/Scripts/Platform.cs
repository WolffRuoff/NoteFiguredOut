using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    public bool random = false;
    public int level = 0;
    public float timer = 2f;

    public GameObject player;
    public float jumpHeight;

    private bool active = false;
    private KeyValuePair<char, int> pair;

    void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                GameController.recieveInput(0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                GameController.recieveInput(1);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                GameController.recieveInput(2);
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                GameController.recieveInput(3);
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                GameController.recieveInput(4);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                GameController.recieveInput(5);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                GameController.recieveInput(6);
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

            Notes.Instance.Note(pair.Key, pair.Value);
            active = true;
        }
        else
        {
            Levels curr = Levels.getInstance();
            pair = curr.getNextNote(level);
        }

        if (pair.Key == 'c')
        {
            GameController.recieveNote(0);
        }
        else if (pair.Key == 'd')
        {
            GameController.recieveNote(1);
        }
        else if (pair.Key == 'e')
        {
            GameController.recieveNote(2);
        }
        else if (pair.Key == 'f')
        {
            GameController.recieveNote(3);
        }
        else if (pair.Key == 'g')
        {
            GameController.recieveNote(4);
        }
        else if (pair.Key == 'a')
        {
            GameController.recieveNote(5);
        }
        else if (pair.Key == 'b')
        {
            GameController.recieveNote(6);
        }

        Notes.Instance.Note(pair.Key, pair.Value);
        active = true;
    }

}

