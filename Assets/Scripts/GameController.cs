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
    public Sprite[] deathSpr = new Sprite[4];
    public float timerVal = 2f;
    public float firstJump = 2.85f;
    public float bridgeToMiddle = 3.329f;
    public float middleToMiddle = 2.755f;
    public static int move = -1;
    public Text t;
    public Text points;
    public Text noteMissed;
    public EventSystem es;
    public Image timeBar;
    public static bool won;

    private static int note = -1;
    private static int selection = -1;
    private static bool active = false;
    private static int score = 0;
    private float timer;
    private Rigidbody2D rgb;
    private static float prevX;
    private static Transform currentPlatform;
    private float maxTime;
    private int deathIndex = 0;
    private bool blink;
    private bool deathOnce = true;
    

    // Start is called before the first frame update
    void Start()
    {
        // reset statics when scene is reloaded
        player = GameObject.FindGameObjectsWithTag("player")[0];
        note = -1;
        selection = -1;
        active = false;
        won = false;
        move = -1;
        score = 0;
        timer = maxTime = timerVal;
        t.text = "Score: " + score;
        rgb = player.GetComponent<Rigidbody2D>();
        blink = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (timer > 0f && active)
            {
                timer -= Time.deltaTime;
                timeBar.fillAmount = timer / maxTime;

                if (timer < maxTime / 3)
                {
                    if (blink == false)
                    {
                        timeBar.color = Color.red;
                        blink = true;
                    }
                    else
                    {
                        timeBar.color = Color.white;
                        blink = false;
                    }
                }
                else
                {
                    timeBar.color = Color.white;
                    blink = false;
                }
            }
            else
            {
                // check if answer is incorrect or timer ran out before a selection was made
                if ((selection != note || selection == -1) && note != -1)
                {
                    Levels.setFirst();
                    if (score == 1)
                    {
                        points.text = "You Scored " + score + " Point!";
                    }
                    else
                    {
                        points.text = "You Scored " + score + " Points!";
                    }

                    if (note == 0)
                    {
                        noteMissed.text = "C";
                    }
                    else if (note == 1)
                    {
                        noteMissed.text = "D";
                    }
                    else if (note == 2)
                    {
                        noteMissed.text = "E";
                    }
                    else if (note == 3)
                    {
                        noteMissed.text = "F";
                    }
                    else if (note == 4)
                    {
                        noteMissed.text = "G";
                    }
                    else if (note == 5)
                    {
                        noteMissed.text = "A";
                    }
                    else if (note == 6)
                    {
                        noteMissed.text = "B";
                    }

                    active = false;

                    if (deathOnce)
                    {
                        PlayerAnimator.setDead(true);
                        StartCoroutine(death());
                        deathOnce = false;
                    }

                }
                else
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
        else if (won)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = timerVal;
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

    public static void setActive(bool tf)
    {
        active = tf;
    }

    public static void setWon(bool tf)
    {
        won = tf;
    }

    public static int getScore ()
    {
        return score;
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


    IEnumerator death()
    {
        while (deathIndex < deathSpr.Length)
        {
            player.GetComponent<SpriteRenderer>().sprite = deathSpr[deathIndex++];
            yield return new WaitForSeconds(.075f);
        }

        currentPlatform.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        active = false;
        yield return null;
    }
}
