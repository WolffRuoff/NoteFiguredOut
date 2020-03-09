using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameObject player;
    public float timerVal = 2f;
    public float firstJump = 2.85f;
    public float bridgeToMiddle = 3.329f;
    public float middleToMiddle = 2.755f;
    public static int move = -1;
    public Text t;
    public EventSystem es;

    private static int note = -1;
    private static int selection = -1;
    private static bool active = false;
    private int score = 0;
    private float timer;
    private Rigidbody2D rgb;
    private static float prevX;
    private static Transform currentPlatform;

    // Start is called before the first frame update
    void Start()
    {
        // reset statics when scene is reloaded
        player = GameObject.FindGameObjectsWithTag("player")[0];
        note = -1;
        selection = -1;
        active = false;
        move = -1;
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
                // check if answer is incorrect or timer ran out before a selection was made
                if (selection != note || selection == -1 || note == -1)
                {
                    // maybe add a fade to black?
                    // not sure if we wanna restart current level or return to main menu
                    Levels.setFirst();
                    currentPlatform.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                    active = false;
                } else
                {
                    // set up for next platform
                    active = false;
                    note = -1;
                    selection = -1;

                    // reset timer
                    timer = timerVal;

                    // reset button color
                    es.SetSelectedGameObject(null);

                    // update score
                    t.text = "Score: " + ++score;

                    // launch player -- not exact but doesn't have to be
                    // because we recenter when it lands
                    prevX = player.transform.position.x;
                    if (move == 0)
                    {
                        rgb.AddForce(new Vector2(firstJump, firstJump), ForceMode2D.Impulse);
                    }
                    else if (move == 1)
                    {
                        rgb.AddForce(new Vector2(bridgeToMiddle, bridgeToMiddle), ForceMode2D.Impulse);
                    }
                    else if (move == 2)
                    {
                        rgb.AddForce(new Vector2(bridgeToMiddle, bridgeToMiddle), ForceMode2D.Impulse);
                    }
                    else if (move == 3)
                    {
                        rgb.AddForce(new Vector2(middleToMiddle, middleToMiddle), ForceMode2D.Impulse);
                    }
                    else if (move == 4)
                    {
                        rgb.AddForce(new Vector2(bridgeToMiddle, bridgeToMiddle), ForceMode2D.Impulse);
                    }
                    else if (move == 5)
                    {
                        rgb.AddForce(new Vector2(bridgeToMiddle, bridgeToMiddle), ForceMode2D.Impulse);
                    }
                }
            }
        }
    }

    public static void RecieveInput(int n)
    {
        // update the user input selection
        selection = n;
    }

    public static void RecieveNote(int n)
    {
        // update the current note that is being played and start the timer
        note = n;
        active = true;
    }

    public static void RecievePlatform(Transform t)
    {
        currentPlatform = t;
    }

    public static void center ()
    {
        // recenters the player so that the launch doesn't have to be exact
        // +1.66u for first jump
        // +1.50u for middle to middle
        // +2.25u for bridge to middle / middle to bridge
        float x = 0.0f;
        if (move == -1)
        {
            x = player.transform.position.x;
            move = 0;
        }
        else  if (move == 0)
        {
            x = prevX + 1.66f;
            move = 1;
        }
        else if (move == 1)
        {
            x = prevX + 2.25f;
            move = 2;
        }
        else if (move == 2)
        {
            x = prevX + 2.25f;
            move = 3;
        }
        else if (move == 3)
        {
            x = prevX + 1.5f;
            move = 4;
        }
        else if (move == 4)
        {
            x = prevX + 2.25f;
            move = 5;
        }
        else if (move == 5)
        {
            x = prevX + 2.25f;
            move = 1;
        }
        player.transform.position = new Vector3(x, player.transform.position.y);
    }
}
