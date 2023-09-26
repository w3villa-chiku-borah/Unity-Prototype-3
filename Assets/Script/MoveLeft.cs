using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveLeftSpeed = 30;
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isGameOver)
        {
            transform.Translate(Vector3.left * moveLeftSpeed * Time.deltaTime);
        }

        if(transform.position.x < -15)
        {

            Destroy(gameObject);
        }
    }
}
