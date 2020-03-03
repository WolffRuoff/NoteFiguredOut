using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public float jumpHeight;

    public float timer = 2f;

    private static int note = -1;
    private static int selection = -1;

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
            if (selection == note && note != -1)
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

    public static void recieveInput(int n)
    {
        selection = n;
    }

    public static void recieveNote(int n)
    {
        note = n;
    }
}
