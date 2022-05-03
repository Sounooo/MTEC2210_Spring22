using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    public GameManager gameManager;
    private AudioSource audioSource;

    public AudioClip hopClip;



    public float moveDuration = 0.5f;
    private float timeElapsed;
    private Vector3 targetPosition;
    private bool isMoving = false;
    public float moveMutipler = 0.5f;
    public enum MovementType
    {
        Continuous,
        Discrete,
    }

    public MovementType movementType;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementType == MovementType.Continuous)
        {
            ContinuousMovment();
        }
        else
        {
            if (!isMoving)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    SetTargetPosition("Up");
                    audioSource.PlayOneShot(hopClip);
                }
            else   if (Input.GetKeyDown(KeyCode.A))
                {
                    SetTargetPosition("Left");
                    audioSource.PlayOneShot(hopClip);
                }
            else   if (Input.GetKeyDown(KeyCode.S))
                {
                    SetTargetPosition("Down");
                    audioSource.PlayOneShot(hopClip);
                }
            else   if (Input.GetKeyDown(KeyCode.D))
                {
                    SetTargetPosition("Right");
                    audioSource.PlayOneShot(hopClip);
                }
            }

            if (targetPosition != transform.position)
            {
                isMoving = true;
                
                DisceteMovement(transform.position, targetPosition);
            }
            else
            {
                isMoving = false;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void SetTargetPosition(string direction)
    {
        if (direction == "Up")
        {
         targetPosition = transform.position + (Vector3.up * moveMutipler);
        }
   else if (direction == "Down")
        {
            targetPosition = transform.position + (Vector3.down * moveMutipler);
        }
   else if (direction == "Left")
        {
            targetPosition = transform.position + (Vector3.left * moveMutipler);
        }
   else if (direction == "Right")
        {
            targetPosition = transform.position + (Vector3.right * moveMutipler);
        }

    }
    private void ContinuousMovment()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        float xMovement = xMove * speed * Time.deltaTime;
        float yMovement = yMove * speed * Time.deltaTime;

        transform.Translate(xMovement, yMovement, 0);
      //audioSource.clip = hopClip;
      if ( xMove!= 0 || yMove!=0)
        {
          if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
          
        }
        else
        {
        if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void DisceteMovement(Vector3 start, Vector3 end)
    {
            timeElapsed += Time.deltaTime;

            transform.position = Vector3.Lerp(start, end, timeElapsed / moveDuration);
        
        if (timeElapsed >= moveDuration)
        {
            transform.position = targetPosition;
        }
    }
   
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.tag == "Goal")
            Debug.Log("Area Cleared");
        gameManager.ReloadScene();
    }

}
