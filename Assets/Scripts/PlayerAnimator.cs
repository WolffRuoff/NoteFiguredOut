using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimator : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[3];
    public float length = .7f;
    public GameObject IGUI;
    public GameObject YLUI;
    public CanvasGroup cg;

    private Rigidbody2D rgb;
    private SpriteRenderer sr;
    private float timer;
    private static bool dead = false;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        timer = length / sprites.Length;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if player is moving, animate the sprite
        // loops through the animation every length seconds
        if ((Math.Round(Math.Abs(rgb.velocity.x)) > 0 && Math.Round(Math.Abs(rgb.velocity.y)) > 0) && !dead) 
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
        } else if ((Math.Round(Math.Abs(rgb.velocity.x)) == 0 && Math.Round(Math.Abs(rgb.velocity.y)) == 0) && !dead)
        {
            sr.sprite = sprites[2];
            i = 0;
        }

        if (transform.position.y < -3 && dead)
        {

            Notes.Instance.setActive(false);
            IGUI.SetActive(false);
            StartCoroutine(fade());
        }
    }

    IEnumerator fade()
    {
        while (cg.alpha < 1)
        {
            cg.alpha += Time.deltaTime / 3;
            yield return null;
        }

        YLUI.SetActive(true);
        yield return null;
    }

    public static void setDead (bool tf)
    {
        dead = tf;
    }
}
