using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anime;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticles;
    public float gravityModifire;   
    public float forceForup = 15;
    public bool isOnGround = true;
    public bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
     rb= GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifire;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !isGameOver) 
        {
            rb.AddForce(Vector3.up * forceForup, ForceMode.Impulse);
            anime.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticles.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround= true;
            dirtParticles.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            anime.SetBool("Death_b", true);
            anime.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            // Debug.Log("GAME OVER");
            dirtParticles.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }


    void DartParticle()
    {
        if(isGameOver && !isOnGround)
        {
            dirtParticles.Play();
        }
        else
        {
            dirtParticles.Stop();
        }
    }
}
