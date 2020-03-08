using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public float offset;

    // only put on one key so that it spawns a new set of platforms
    // when it reaches that key
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            // get the position of the last key
            Transform prev = transform.parent.GetChild(9);
            Vector3 pos = prev.position;
            pos.x += offset;
            Instantiate(platform, pos, Quaternion.identity);
        }
    }
}
