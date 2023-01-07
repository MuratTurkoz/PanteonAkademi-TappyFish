using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float distance = -5f;
    Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindWithTag("SpawnEnemies").GetComponentInParent<Transform>().parent;
    }

    // Update is called once per frame
    void Update()
    {   
        LeftMovement();
    }
    void LeftMovement()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (transform.position.x < distance)
        {
            Destroy(gameObject);

        }
    }
}
