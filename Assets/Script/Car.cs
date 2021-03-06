using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public float speed = 5.0f;
    public AudioSource audioSource;




 void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.right;
        Vector3 vel = dir * speed * Time.deltaTime;
        transform.Translate(vel);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Car")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            
           

            Destroy(gameObject);
            
            //Time.timeScale = 0f;
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
