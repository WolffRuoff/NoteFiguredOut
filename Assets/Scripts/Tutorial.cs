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
    public TextMesh text;

    private static int note = -1;
    private static int selection = -1;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMesh>();
        text.text = "Welcome to blablablah..."; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
