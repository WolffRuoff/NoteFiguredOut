using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    public bool random = false;
    public int level = 0;
    public GameObject IGUI;
    public GameObject YWUI;
    public CanvasGroup cg;

    private KeyValuePair<char, int> pair;
    private static bool active = true;
    private CanvasGroup igcg;

    void Start()
    {
        igcg = IGUI.GetComponent<CanvasGroup>(); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            // stop player from sliding and recenter so that it never goes off the edge
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameController.center();

            if (active)
            {
                // send info to GameController
                GameController.RecievePlatform(transform);

                // assign platform a note
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
                    }
                    else
                    {
                        // player wins
                        Levels.setFirst();
                        GameController.setActive(false);
                        GameController.setWon(true);
                        Notes.Instance.setActive(false);
                        InputController.setActive(false);
                        CameraController.setActive(false);
                        active = false;
                        StartCoroutine(win());
                    }

                }

                // send selection to GameController
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

                // play the note
                Notes.Instance.Note(pair.Key, pair.Value);
                Debug.Log(pair.Key);
            }
        }    
    }

    IEnumerator win()
    {
        while (cg.alpha < 1)
        {
            cg.alpha += Time.deltaTime / 7;
            igcg.alpha -= Time.deltaTime / 7;
            yield return null;
        }
        IGUI.SetActive(false);
        YWUI.SetActive(true);
        yield return null;
    }
}

