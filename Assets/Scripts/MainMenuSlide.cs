using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSlide : MonoBehaviour
{
    public RectTransform left;
    public RectTransform right;
    public int speed = 10;

    private int val = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(slide());
    }

    IEnumerator slide ()
    {
        while (val < 850)
        {
            left.position = new Vector2(left.position.x + speed, left.position.y);
            right.position = new Vector2(right.position.x - speed, right.position.y);
            val += speed;
            yield return null;
        }
    }
}
