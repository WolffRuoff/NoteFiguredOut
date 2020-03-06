using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{

    private float timer = 0f;
    private Levels level;

    // Start is called before the first frame update
    void Start()
    {
        level = Levels.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (!level.isEmpty(0))
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 1f;
                var n = level.getNextNote(0);
                Debug.Log(n.Key);
                Debug.Log(n.Value);
                Notes.Instance.Note(n.Key, n.Value);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
