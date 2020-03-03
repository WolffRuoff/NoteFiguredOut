using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public float jumpHeight;

    public float timer = 2f;

    private char note;
    private int selection = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = player.GetComponent<Rigidbody2D>().velocity;
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            if (selection == 0 && note == 'c')
            {
                vel.y = jumpHeight;
            }
            else if (selection == 1 && note == 'd')
            {
                vel.y = jumpHeight;
            }
            else if (selection == 2 && note == 'e')
            {
                vel.y = jumpHeight;
            }
            else if (selection == 3 && note == 'f')
            {
                vel.y = jumpHeight;
            }
            else if (selection == 4 && note == 'g')
            {
                vel.y = jumpHeight;
            }
            else if (selection == 5 && note == 'a')
            {
                vel.y = jumpHeight;
            }
            else if (selection == 6 && note == 'b')
            {
                vel.y = jumpHeight;
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

    public void recieveInput(int n)
    {
        selection = n;
    }
}
