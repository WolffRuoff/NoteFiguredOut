using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private Text t;
    private static float score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
        t.text = "Score: " + (score);
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Score: " + score;
    }

    public static void ReceiveUpdate ()
    {
        score++;
    }

}
