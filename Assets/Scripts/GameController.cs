using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public float yValueIncrease;
    public float xValueIncrease;
    public Button[] buttons;
    public float timerVal = 2f;

    private static int note = -1;
    private static int selection = -1;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerVal;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = player.GetComponent<Rigidbody2D>().velocity;
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = timerVal;
            if (selection == note && note != -1)
            {
                // correct answer
                // reset buttons to unselected
                foreach (Button b in buttons)
                {
                    b.image.color = Color.white;
                }

                // move player to next platform (causes onCollisionEnter2D in Platform.cs)
                vel.x = xValueIncrease;
                vel.y = yValueIncrease;
            }
            else
            {
                // wrong answer -- player loses
                // maybe add a fade to black?
                // not sure if we wanna restart current level or return to main menu
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    }
}
