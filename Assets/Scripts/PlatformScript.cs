using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float move_speed = 2f;
    public float bound_y = 6f;

    private Animator anim;

    public bool is_Breakable, is_Spike, is_Platform, moving_Platform_Right, moving_Platform_Left;


    private void Awake()
    {
        if (is_Breakable)
        {
            anim = GetComponent<Animator>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

   
    ///  MOVEMENT OF THE PLATFORM
    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y > bound_y)
        {
            gameObject.SetActive(false);
        }

   }


    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);
    }

    void DeactivateGameObject() 
    {
        // SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            if (is_Spike)
            {
                target.transform.position = new Vector2(1000f,1000f);
                // SoundManager.instance.GameOverSound();
                // GameManager.instance.RestartGame();
            }

            //if (is_Breakable)
            //{
            //    Invoke("DeactivateGameObject", 0.3f);
            //    // SoundManager.instance.LandSound();
            //      anim.Play("Break");
            //    print("break");
            //}

        }
    }


    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (is_Breakable)
            {
                Invoke("DeactivateGameObject", 0.5f);
                // SoundManager.instance.LandSound();
                anim.Play("Break");
                print("break");
            }

            if (is_Platform)
            {
                // SoundManager.instance.LandSound();
            }
        }
    }


    private void OnCollisionStay2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            if (moving_Platform_Left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }

            if (moving_Platform_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }
}
