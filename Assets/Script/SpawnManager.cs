using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstacle;
    public float startDelay = 2f;
    public float repeatRate = 2.5f;

    public Vector3 spawnPosition = new Vector3(25, -0.46f, 0);
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

       
            InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
    if (!playerController.isGameOver)
    {
        Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
    }
   }
}
