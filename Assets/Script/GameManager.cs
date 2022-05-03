using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] carSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCar", 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //SpawnCar();

        //}
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    void SpawnCar()
    {
        int index = Random.Range(0, carSpawnPoints.Length);
        Vector3 spawPos = carSpawnPoints[index].position;
        GameObject car = Instantiate(carPrefab, spawPos, Quaternion.identity);

        int dirModifier = 0;
        if (index > 2)
        {
            dirModifier = -1;
            car.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            dirModifier = 1;

        }


        car.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        //int dirModifier = (index > 2) ? -1 : 1;



        car.GetComponent<Car>().speed = Random.Range(3.0f, 6.0f) * dirModifier;




    }
}


    


