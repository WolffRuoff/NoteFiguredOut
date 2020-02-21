using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public Transform player;
    public float offsetX;
    public float offsetY;
    float score;
    TextMesh text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMesh>();
        score = 0;
        text.text = "Score: " + (score);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = player.position.x + offsetX;
        pos.y = player.position.y + offsetY;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piano Key"))
        {
            score++;
            text.text = "Score: " + (score);
        }
    }
}
