using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject platformL;
    public GameObject platformM;
    public GameObject platformR; 
    public int spaceBetweenPlatforms = 10;
    public int startingXValue = -8;
    public float offset = 1.5f;

    private GameObject prevPlatform;
    private int prevX;

    void Start()
    {
        prevPlatform = platformR;
        prevX = startingXValue;
    }

    void Update()
    {
        if ((int)player.position.x % spaceBetweenPlatforms == 0 && (int)player.position.x > prevX)
        {
            prevX = (int)player.position.x;

            // create new platform
            for (int i = 0; i < 7; i++)
            {
                Vector3 newPosition = prevPlatform.transform.position;
                newPosition.x += offset;
                if (i == 0 || i == 3) { prevPlatform = Instantiate(platformL, newPosition, Quaternion.identity); }
                if (i == 1 || i == 4 || i == 5) { prevPlatform = Instantiate(platformM, newPosition, Quaternion.identity); }
                if (i == 2 || i == 6) { prevPlatform = Instantiate(platformR, newPosition, Quaternion.identity); }
            }
        }
    }


}
