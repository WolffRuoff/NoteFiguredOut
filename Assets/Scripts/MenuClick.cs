using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClick : MonoBehaviour
{
    public int level;
    TextMesh tm;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        tm.color =Color.red;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Level"+level);
    }

    private void OnMouseExit()
    {
        tm.color = Color.white;
    }
}
