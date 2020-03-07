using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[3];
    public float length = .7f;

    private Rigidbody2D rgb;
    private SpriteRenderer sr;
    private float timer;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        timer = length / sprites.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(rgb.velocity.x) > 0 && Math.Abs(rgb.velocity.y) > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                if (i == sprites.Length)
                {
                    i = 0;
                }

                sr.sprite = sprites[i];
                timer = length / sprites.Length;
                i++;
            }
        }
    }
}
