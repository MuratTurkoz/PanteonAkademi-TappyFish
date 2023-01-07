using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 9f;
    [SerializeField] int minAngle = 6;
    [SerializeField] int maxAngle = 20;
    [Header("AudioClip")]
    [SerializeField] AudioClip jumpVFX;
    [SerializeField] AudioClip pointVFX;
    [SerializeField] AudioClip crushVFX;
    AudioSource audioSource;
    Rigidbody2D _rb;
    bool isCrush = false;
    int angle = 0;
   
    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(_rb.velocity.x, 9f);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (isCrush == false && GameManager.gameOver == false)
        {
            FishSwim();
        }

    }
    void FixedUpdate()
    {
        FishRotation();

    }

    private void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2)//Gecikme Yapmak için
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }

        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void FishSwim()
    {
        Debug.Log(Input.touchCount);
        if (Input.touchCount != 0)
        {
            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x, speed);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(jumpVFX);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            FishDeath();
        }
        else if (collision.gameObject.tag == "Ground")
        {
            if (GameManager.gameOver == false)
            {
                FishDeath();
            }          
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().AddScore();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(pointVFX);
        }
    }
    void FishDeath()
    {
        GameManager.gameOver = true;
        audioSource.PlayOneShot(crushVFX);
        transform.rotation = Quaternion.Euler(0, 0, -90);
        GameObject.Find("Ground").GetComponent<LeftMovement>().enabled = false;       
        enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
        isCrush = true;
        GameObject.Find("GameManager").GetComponent<GameManager>().CrushObstacle();
    }
}
