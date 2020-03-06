using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoringPlayer : MonoBehaviour
{

    public float speed;
    public float jump;
    private Rigidbody2D rgb;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -1 * speed;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = 1 * speed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            vel.y = 1 * jump;
        }

        rgb.velocity = vel;
    }
}
