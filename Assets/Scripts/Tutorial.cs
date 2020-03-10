using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject player;
    public float yValueIncrease;
    public float xValueIncrease;
    public Button[] buttons;
    public float timerVal = 2f;
    public Text[] text;
    public int indexer;
    public bool random = false;
    public int level = 0;
    public GameObject IGUI;
    public GameObject YWUI;
    public CanvasGroup cg;
    public Text points;
    public CanvasGroup igcg;

    private KeyValuePair<char, int> pair;
    private static bool active = true;
    

    private static int note = -1;
    private static int selection = -1;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        indexer = 0;
        text[0].enabled = true;
        igcg = IGUI.GetComponent<CanvasGroup>();
        active = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (indexer == 0)
            {
                indexer++;
                text[0].enabled = false;
                text[indexer].enabled = true;
            }

            if (indexer == 1)
            {
                indexer++;
                text[1].enabled = false;
                text[indexer].enabled = true;
            }

            if (indexer == 2)
            {
                indexer++;
                text[2].enabled = false;
                text[indexer].enabled = true;
            }

            if (indexer == 3)
            {
                text[3].enabled = false;
                SceneManager.LoadScene("StartMenu");
                //End the tutorial here
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (indexer == 1)
            {
                indexer--;
                text[1].enabled = false;
                text[indexer].enabled = true;
            }

            if (indexer == 2)
            {
                indexer--;
                text[2].enabled = false;
                text[indexer].enabled = true;
            }

            if (indexer == 3)
            {
                indexer--;
                text[3].enabled = false;
                text[indexer].enabled = true;
            }
        }

        if (indexer == 2)
        {
            active = true;  
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            // stop player from sliding and recenter so that it never goes off the edge
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameController.center();

            if (active)
            {
                // send info to GameController
                GameController.RecievePlatform(transform);

                // assign platform a note

                Levels curr = Levels.getInstance();
                if (!curr.isEmpty(level))
                {
                    pair = curr.getNextNote(level);
                }
                else
                {
                    // player wins tutorial
                    indexer = 3;
                    text[2].enabled = false;
                    text[3].enabled = true;


                    Levels.setFirst();
                    GameController.setActive(false);
                    GameController.setWon(true);
                    Notes.Instance.setActive(false);
                    InputController.setActive(false);
                    CameraController.setActive(false);
                       
                    active = false;
                }


                // send selection to GameController
                if (pair.Key == 'c')
                {
                    GameController.RecieveNote(0);
                }
                else if (pair.Key == 'd')
                {
                    GameController.RecieveNote(1);
                }
                else if (pair.Key == 'e')
                {
                    GameController.RecieveNote(2);
                }
                else if (pair.Key == 'f')
                {
                    GameController.RecieveNote(3);
                }
                else if (pair.Key == 'g')
                {
                    GameController.RecieveNote(4);
                }
                else if (pair.Key == 'a')
                {
                    GameController.RecieveNote(5);
                }
                else if (pair.Key == 'b')
                {
                    GameController.RecieveNote(6);
                }

                // play the note
                Notes.Instance.Note(pair.Key, pair.Value);
                Debug.Log(pair.Key);
            }
        }
    }
}