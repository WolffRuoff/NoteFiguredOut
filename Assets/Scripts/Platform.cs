using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    public bool random = false;
    public int level = 0;

    private KeyValuePair<char, int> pair;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (random)
            {
                char note;
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

                pair = new KeyValuePair<char, int>(note, 4);
            }
            else
            {
                Levels curr = Levels.getInstance();
                if (!curr.isEmpty(level))
                {
                    pair = curr.getNextNote(level);
                } else
                {
                    // player wins
                    Levels.setFirst();
                    SceneManager.LoadScene("StartMenu");
                }
                
            }

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

            Notes.Instance.Note(pair.Key, pair.Value);
            Debug.Log(pair.Key);
        }
    }
}

