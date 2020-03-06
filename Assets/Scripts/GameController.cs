using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public float x;
    public float y;
    public Button[] buttons;
    public Text t;
    public float timerVal = 2f;
    public EventSystem es;

    private static int note = -1;
    private static int selection = -1;
    private int score = 0;
    private static bool active = false;
    private int move = 0;
    private float timer;
    private Rigidbody2D rgb;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerVal;
        rgb = player.GetComponent<Rigidbody2D>();
        t.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(0, 0);

        if (active)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                // check if answer is incorrect
                if (selection != note || selection == -1 || note == -1)
                {
                    // maybe add a fade to black?
                    // not sure if we wanna restart current level or return to main menu
                    Levels.setFirst();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                } else
                {
                    // set up for next platform
                    active = false;
                    note = -1;
                    selection = -1;

                    // reset timer
                    timer = timerVal;

                    // reset button colors
                    es.SetSelectedGameObject(null);
                    //foreach (Button b in buttons)
                    //{
                    //b.Select();
                    //}

                    // update score
                    t.text = "Score: " + ++score;

                    // move player
                    // +1.66u for first jump
                    // +1.50u for middle to middle
                    // +2.25u for bridge to middle / middle to bridge
                    if (move == 0)
                    {
                        Vector3 pos = player.transform.position;
                        pos.x += 1.66f;
                        player.transform.position = pos;
                        move = 1;
                    }
                    else if (move == 1)
                    {
                        Vector3 pos = player.transform.position;
                        pos.x += 2.25f;
                        player.transform.position = pos;
                        move = 2;
                    }
                    else if (move == 2)
                    {
                        Vector3 pos = player.transform.position;
                        pos.x += 2.25f;
                        player.transform.position = pos;
                        move = 3;
                    }
                    else if (move == 3)
                    {
                        Vector3 pos = player.transform.position;
                        pos.x += 1.5f;
                        player.transform.position = pos;
                        move = 4;
                    }
                    else if (move == 4)
                    {
                        Vector3 pos = player.transform.position;
                        pos.x += 2.25f;
                        player.transform.position = pos;
                        move = 5;
                    }
                    else if (move == 5)
                    {
                        Vector3 pos = player.transform.position;
                        pos.x += 2.25f;
                        player.transform.position = pos;
                        move = 1;
                    }
                }
            }
        }
    }

    public static void RecieveInput(int n)
    {
        selection = n;
    }

    public static void RecieveNote(int n)
    {
        note = n;
        active = true;
    }
}
