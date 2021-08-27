using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerbOunds : MonoBehaviour
{

    public float minX = -2.6f, maxX = 2.6f, minY = -5.6f;
    private bool out_Of_Bounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
        
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if(temp.x > maxX)
        {
            temp.x = maxX;

        }

        if (temp.x < minX)
        {
            temp.x = minX;
        }

        transform.position = temp;

        if(temp.y <= minY)
        {
            if (!out_Of_Bounds)
            {
                out_Of_Bounds = true;

                // SoundManager.Instance.DeathSound();
                // Gameobject.Instance.RestartGame();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "TopSpikes")
        {
            transform.position = new Vector2(1000f, 1000f);
            // SoundManager.instance.GameOverSound();
            // GameManager.instance.RestartGame();
        }
    }
}
