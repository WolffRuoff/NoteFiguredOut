using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public bool random = false;
    public int level = 0;
    public float timer = 2f;
    public Button c;
    public Button d;
    public Button e;
    public Button f;
    public Button g;
    public Button a;
    public Button b;

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
                GameController.RecieveInput(0);
                c.Select();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                GameController.RecieveInput(1);
                d.Select();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                GameController.RecieveInput(2);
                e.Select();
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                GameController.RecieveInput(3);
                f.Select();
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                GameController.RecieveInput(4);
                g.Select();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                GameController.RecieveInput(5);
                a.Select();
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                GameController.RecieveInput(6);
                b.Select();
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

            if (pair.Key == 'c')
            {
                GameController.RecieveNote(0);
            }
            else if (pair.Key == 'd')
            {
                GameController.RecieveNote(1);
            }
            else if (pair.Key == 'e')
            {
                GameController.RecieveNote(2);
            }
            else if (pair.Key == 'f')
            {
                GameController.RecieveNote(3);
            }
            else if (pair.Key == 'g')
            {
                GameController.RecieveNote(4);
            }
            else if (pair.Key == 'a')
            {
                GameController.RecieveNote(5);
            }
            else if (pair.Key == 'b')
            {
                GameController.RecieveNote(6);
            }
        }
    }
}

