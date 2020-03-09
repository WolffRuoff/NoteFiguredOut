using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Camera follows the player along the X axis
    public Transform player;
    public float offsetX;

    private static bool active = true;

    void Update()
    {
        if (active)
        {
            Vector3 pos = transform.position;
            if (pos.x <= player.position.x + offsetX)
            {
                pos.x = player.position.x + offsetX;
                transform.position = pos;
            }
        }
    }

    public static void setActive(bool tf)
    {
        active = tf;
    }
}
