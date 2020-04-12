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
    public float timerVal = 3f;
    public float firstJump = 2.85f;
    public float bridgeToMiddle = 3.329f;
    public float middleToMiddle = 2.755f;
    public Text scoreT;
    public Text points;
    public Text noteMissed;
    public EventSystem es;
    public Image timeBar;

    private static bool won = false;
    private static int move = -1;
    private static char note = '\0';
    private static char selection = '\0';
    private static bool active = false;
    private static float score = 0f;
    private static float timeLeft;
    private static float timer;
    private float maxTime;
    private bool blink = false;
    private Rigidbody2D rgb;
    private static float prevX;
    private static Transform currentPlatform;
    private int deathIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        // reset statics when scene is reloaded
        player = GameObject.FindGameObjectsWithTag("player")[0];
        note = '\0';
        selection = '\0';
        active = false;
        won = false;
        move = -1;
        score = 0;
        timer = maxTime = timerVal;
        scoreT.text = "Score: " + score;
        rgb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (active)
        {
            if (updateTimer()) 
            {
                if ((selection != note || selection == '\0') && !won)
                {
                    lose();
                }
                else
                {
                    next();
                }
            }
        }

        if (won)
        {
            if (updateTimer())
            {
                next();
            }
            
        }
    }

    private bool updateTimer ()
    {
        timer -= Time.deltaTime;
        if (!won)
        {
            timeBar.fillAmount = timer / maxTime;
        }

        if (timer > 0)
        {
            if (!won)
            {
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

            return false;
        }

        return true;
    }

    private void lose ()
    {
        active = false;
        Levels.setFirst();

        if (score == 1)
        {
            points.text = "You Scored " + Math.Round(score, 2) + " Point!";
        }
        else
        {
            points.text = "You Scored " + Math.Round(score, 2) + " Points!";
        }

        noteMissed.text = "" + note;
        PlayerAnimator.setDead(true);
        StartCoroutine(death());
    }

    private void next ()
    {
        active = false;
        // reset timer
        timer = timerVal;

        if (!won)
        {
            // set up for next platform
            InputController.setActive(false);
            note = '\0';
            selection = '\0';

            // reset button color
            es.SetSelectedGameObject(null);

            // update score
            score += timeLeft;
            scoreT.text = "Score: " + Math.Round(score, 2);
        }
        
        // launch player -- not exact but doesn't have to be
        // because we recenter when it lands
        prevX = player.transform.position.x;
        if (move == 0)
        {
            rgb.AddForce(new Vector2(firstJump, firstJump), ForceMode2D.Impulse);
        }
        else if (move == 3)
        {
            rgb.AddForce(new Vector2(middleToMiddle, middleToMiddle), ForceMode2D.Impulse);
        }
        else
        {
            rgb.AddForce(new Vector2(bridgeToMiddle, bridgeToMiddle), ForceMode2D.Impulse);
        }
    }

    public static void RecieveInput(char n)
    {
        // update the user input selection
        if (selection != n)
        {
            timeLeft = timer;
        }
        selection = n;
    }

    public static void RecieveNote(char n)
    {
        // update the current note that is being played and start the timer
        note = n;
        active = true;
        InputController.setActive(true);
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

    public static float getScore ()
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
