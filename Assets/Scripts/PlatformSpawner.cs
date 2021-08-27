using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatforms;

    public float platform_Spawn_Timer = 1.8f;
    private float current_Platform_Spawn_Timer;
    private int platform_Spawn_Count;

    public float minX = -2f, maxX = 2f; 



    // Start is called before the first frame update
    void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }


    // Update is called once per frame
    void Update()
    {
        SpawnPlatform();
    }


    void SpawnPlatform()
    {
        current_Platform_Spawn_Timer += Time.deltaTime;

        // HERE PLATFORM WILL GOING TO BE SPAWN AFTER EVERY 2 SECONDS
        if (current_Platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            platform_Spawn_Count++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);

            GameObject newPlatform = null;

            if (platform_Spawn_Count < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if (platform_Spawn_Count == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], temp, Quaternion.identity);
                }

            }
            else if (platform_Spawn_Count == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }

            }
            else if (platform_Spawn_Count == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatforms, temp, Quaternion.identity);
                }

                // WE HAVE TO ADD THIS TO IERATE ALL ABOVE COMMANDS AGAIN
                platform_Spawn_Count = 0;
            }

            newPlatform.transform.parent = transform;
            current_Platform_Spawn_Timer = 0f;
        }
    }
}
