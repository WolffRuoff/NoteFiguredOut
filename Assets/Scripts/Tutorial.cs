using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject[] texts = new GameObject[7];
    public GameObject leftArrow;
    public GameObject Peter;
    public GameObject buttons;
    public Button c;
    public Button d;
    public Button e;
    public Button f;
    public Button g;
    public Button a;
    public Button b;
    public EventSystem es;
    public GameObject timeBar;
    public GameObject time;
    public GameObject scoreT;
    public GameObject pause;

    private int pos = 0;
    private float timer = 4f;
    private float maxTime = 4f;
    private bool blink = false;
    private float score = 0.0f;
    private char selection = '\0';

    void Start()
    {
        pos = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && pos == 1)
        {
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
            Notes.Instance.Note(note, 4);
        } else if (pos == 3 || pos == 4 || pos == 5)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                c.Select();
                if (selection != 'c')
                {
                    score = timer;
                }
                selection = 'c';
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                d.Select();
                if (selection != 'd')
                {
                    score = timer;
                }
                selection = 'd';
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                e.Select();
                if (selection != 'e')
                {
                    score = timer;
                }
                selection = 'e';
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                f.Select();
                if (selection != 'f')
                {
                    score = timer;
                }
                selection = 'f';
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                g.Select();
                if (selection != 'g')
                {
                    score = timer;
                }
                selection = 'g';
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                a.Select();
                if (selection != 'a')
                {
                    score = timer;
                }
                selection = 'a';
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                b.Select();
                if (selection != 'b')
                {
                    score = timer;
                }
                selection = 'b';
            }
        }

        if (pos == 4 || pos == 5)
        {
            if (updateTimer())
            {
                scoreT.GetComponent<Text>().text = "Score: " + Math.Round(score, 2);
                timer = maxTime;
                timeBar.GetComponent<Image>().color = Color.white;
                es.SetSelectedGameObject(null);
                selection = '\0';
            }
        }
    }

    public void updateText (int leftRight)
    {
        es.SetSelectedGameObject(null);

        if (leftRight == 1)
        {
            // right arrow key hit
            if (pos == 0)
            {
                texts[pos++].SetActive(false);
                texts[pos].SetActive(true);
                Peter.SetActive(false);
                leftArrow.SetActive(true);
                Notes.Instance.setActive(true);
            }
            else if (pos == 1)
            {
                texts[pos++].SetActive(false);
                texts[pos].SetActive(true);
                buttons.SetActive(true);
                Notes.Instance.setActive(false);
            }
            else if (pos == 2)
            {
                texts[pos++].SetActive(false);
                texts[pos].SetActive(true);
            }
            else if (pos == 3)
            {
                texts[pos++].SetActive(false);
                texts[pos].SetActive(true);
                time.SetActive(true);
                timeBar.SetActive(true);
                scoreT.SetActive(true);

}
            else if (pos == 4)
            {
                texts[pos++].SetActive(false);
                texts[pos].SetActive(true);
                pause.SetActive(true);
            }
            else if (pos == 5)
            {
                texts[pos++].SetActive(false);
                texts[pos].SetActive(true);
                buttons.SetActive(false);
                timeBar.SetActive(false);
                time.SetActive(false);
                scoreT.SetActive(false);
                pause.SetActive(false);
            }
            else if (pos == 6)
            {
                SceneManager.LoadScene("TutorialLevel");
            }
            
        } else
        {
            if (pos == 1)
            {
                texts[pos--].SetActive(false);
                texts[pos].SetActive(true);
                Peter.SetActive(true);
                leftArrow.SetActive(false);
                Notes.Instance.setActive(false);
            }
            else if (pos == 2)
            {
                texts[pos--].SetActive(false);
                texts[pos].SetActive(true);
                buttons.SetActive(false);
                Notes.Instance.setActive(true);
            }
            else if (pos == 3)
            {
                texts[pos--].SetActive(false);
                texts[pos].SetActive(true);
            }
            else if (pos == 4)
            {
                texts[pos--].SetActive(false);
                texts[pos].SetActive(true);
                time.SetActive(false);
                timeBar.SetActive(false);
                scoreT.SetActive(false);
            }
            else if (pos == 5)
            {
                texts[pos--].SetActive(false);
                texts[pos].SetActive(true);
                pause.SetActive(false);
            }
            else if (pos == 6)
            {
                texts[pos--].SetActive(false);
                texts[pos].SetActive(true);
                buttons.SetActive(true);
                time.SetActive(true);
                timeBar.SetActive(true);
                scoreT.SetActive(true);
                pause.SetActive(true);
            }
        }
    }

    public void hitButton (string selec)
    {
        if (selec[0] != selection)
        {
            score = timer;
            selection = selec[0];
        }
        
    }

    private bool updateTimer()
    {
        timer -= Time.deltaTime;
        timeBar.GetComponent<Image>().fillAmount = timer / maxTime;

        if (timer > 0)
        {
            if (timer < maxTime / 3)
            {
                if (blink == false)
                {
                    timeBar.GetComponent<Image>().color = Color.red;
                    blink = true;
                }
                else
                {
                    timeBar.GetComponent<Image>().color = Color.white;
                    blink = false;
                }
            }
            return false;
        }
        return true;
    }
}