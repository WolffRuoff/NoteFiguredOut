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

    private static int note = -1;
    private static int selection = -1;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        indexer = 0;
        text[0].enabled = true;

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
                indexer++;
                text[3].enabled = false;
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

    }
}