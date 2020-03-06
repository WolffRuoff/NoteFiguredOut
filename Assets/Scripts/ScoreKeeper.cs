using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private static Text t;
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
        
    }

    public static void ReceiveUpdate ()
    {
        score++;
        t.text = "Score: " + score;
    }

}
