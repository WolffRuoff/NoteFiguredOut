using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public float offset;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Transform prev = transform.parent.GetChild(9);
            Vector3 pos = prev.position;
            pos.x += offset;
            Instantiate(platform, pos, Quaternion.identity);


            /*prev = platform.transform.GetChild(9);
            for (int i = 0; i < 10; i++)
            {
                Vector3 newPosition = prev.position;
                newPosition.x += offset;
                if (prev.gameObject.CompareTag("bridge"))
                {
                    newPosition.x += offset;
                }

                prev = Instantiate(platform.GetChild(i).gameObject, newPosition, Quaternion.identity).transform;
            }*/
        }
    }










    /*public Transform player;
    public GameObject middleKey;
    public GameObject bridgeKey;
    public int spaceBetweenPlatforms = 10;
    public int startingXValue = -8;
    public float offset = 1.5f;

    private GameObject prevPlatform;
    private int prevX;

    void Start()
    {
        prevPlatform = bridgeKey;
        prevX = startingXValue;
    }

    void Update()
    {
        if ((int)player.position.x % spaceBetweenPlatforms == 0 && (int)player.position.x > prevX)
        {
            prevX = (int)player.position.x;

            // create new platform
            for (int i = 0; i < 5; i++)
            {
                Vector3 newPosition = prevPlatform.transform.position;
                newPosition.x += offset;
                if (prevPlatform.CompareTag("bridge"))
                {
                    newPosition.x += offset;
                }

                if (i == 0 || i == 2 || i == 3)
                {
                    prevPlatform = Instantiate(middleKey, newPosition, Quaternion.identity);
                }
                else if (i == 1 || i == 4 )
                {
                    prevPlatform = Instantiate(bridgeKey, newPosition, Quaternion.identity);
                }
            }
        }
    }*/


}
