using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Text t;
    public float timerVal = 2f;
    public float firstJump = 2.85f;
    public float bridgeToMiddle = 3.329f;
    public float middleToMiddle = 2.755f;

    public EventSystem es;

    private static int note = -1;
    private static int selection = -1;
    private static bool active = false;
    private int score = 0;
    private int move = 0;
    private float timer;
    private Rigidbody2D rgb;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerVal;
        t.text = "Score: " + score;
        rgb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

                    // reset selected button color
                    es.SetSelectedGameObject(null);

                    // update score
                    t.text = "Score: " + ++score;

                    // move player - not exact values yet, need to playtest more
                    // +1.66u for first jump = 2.85
                    // +1.50u for middle to middle = 2.755
                    // +2.25u for bridge to middle / middle to bridge = 3.329
                    if (move == 0)
                    {
                        rgb.AddForce(new Vector2(firstJump, firstJump), ForceMode2D.Impulse);
                        move = 1;
                    }
                    else if (move == 1)
                    {
                        rgb.AddForce(new Vector2(bridgeToMiddle, bridgeToMiddle), ForceMode2D.Impulse);
                        move = 2;
                    }
                    else if (move == 2)
                    {
                        rgb.AddForce(new Vector2(bridgeToMiddle, bridgeToMiddle), ForceMode2D.Impulse);
                        move = 3;
                    }
                    else if (move == 3)
                    {
                        rgb.AddForce(new Vector2(middleToMiddle, middleToMiddle), ForceMode2D.Impulse);
                        move = 4;
                    }
                    else if (move == 4)
                    {
                        rgb.AddForce(new Vector2(bridgeToMiddle, bridgeToMiddle), ForceMode2D.Impulse);
                        move = 5;
                    }
                    else if (move == 5)
                    {
                        rgb.AddForce(new Vector2(bridgeToMiddle, bridgeToMiddle), ForceMode2D.Impulse);
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
