using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject platform;
    public int spaceBetweenPlatforms = 25;
    public int startingXValue = 0;
    public int offset = 10;

    private GameObject prevPlatform;
    private int prevX;

    void Start()
    {
        prevPlatform = platform;
        prevX = startingXValue;
    }

    void Update()
    {
        if ((int)player.position.x % spaceBetweenPlatforms == 0 && (int)player.position.x > prevX)
        {
            prevX = (int)player.position.x;

            // create new platform
            Vector3 newPosition = prevPlatform.transform.position;
            newPosition.x += offset;
            prevPlatform = Instantiate(platform, newPosition, Quaternion.identity);
        }
    }


}
