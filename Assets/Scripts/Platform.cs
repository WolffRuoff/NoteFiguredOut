using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Platform : MonoBehaviour
{
    public bool random = false;
    public int level = 0;
    public GameObject inGameUI;
    public GameObject youWinUI;
    public CanvasGroup fade;
    public Text score;

    private KeyValuePair<char, int> pair;
    private static bool active = true;

    void Start()
    {
        active = true;
    }

    public static void setActive(bool tf)
    {
        active = tf;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // put player in the correct place
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GameController.center();
        GameController.RecievePlatform(transform);
        if (!active)
        {
            GameController.setActive(true);
        }
        

        if (collision.gameObject.CompareTag("player"))
        {
            // assign a note to this platform
            if (random)
            {
                randomNote();
            } else
            {
                if (levelNote())
                {
                    won(collision.gameObject);
                }
            }

            // only want these actions if the game is not won
            if (active)
            {
                // send note to gamecontroller
                GameController.RecieveNote(pair.Key);

                // play the note
                Notes.Instance.Note(pair.Key, pair.Value);
                Debug.Log(pair.Key);
            }
        }
    }
    
    private void randomNote()
    {
        // assign a random note for infinite mode
        char note;
        int randNote = UnityEngine.Random.Range(1, 7);

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

    private bool levelNote()
    {
        // receive the note from Levels
        Levels curr = Levels.getInstance();
        if (!curr.isEmpty(level))
        {
            pair = curr.getNextNote(level);
            return false;
        }

        return true;
    }

    private void won(GameObject player)
    {
        // set states across other scripts b/c the level is over
        active = false;
        player.tag = "winner";
        Levels.setFirst();
        GameController.setWon(true);
        InputController.setActive(false);
        CameraController.setActive(false);
        Notes.Instance.setActive(false);
        inGameUI.transform.Find("PauseMenu").GetComponent<PauseMenu>().enabled = false;
        float score_ = (float) Math.Round(GameController.getScore(), 2);
        if (score_ == 1)
        {
            score.text = "You Scored " + score_ + " Point!";
        }
        else
        {
            score.text = "You Scored " + score_ + " Points!";
        }

        StartCoroutine(win());
    }

    IEnumerator win()
    {
        // fade to gray
        while (fade.alpha < 1)
        {
            fade.alpha += Time.deltaTime / 7;
            inGameUI.GetComponent<CanvasGroup>().alpha -= Time.deltaTime / 7;
            yield return null;
        }

        // switch the UI
        inGameUI.SetActive(false);
        youWinUI.SetActive(true);
        yield return null;
    }
}

