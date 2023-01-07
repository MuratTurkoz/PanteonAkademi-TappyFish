using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Obstacle")]
    [SerializeField] int minY = -4;
    [SerializeField] int maxY = 4;
    [SerializeField] float maxTime;
    [SerializeField] GameObject obstacle;
    float timer;
    Transform parent;
    void Start()
    {
        parent = GameObject.FindWithTag("SpawnEnemies").GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver == false)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                InstanteNewObstacle();
                timer = 0;
            }
        }
   
    }

    private void InstanteNewObstacle()
    {
        System.Random mid = new System.Random();

        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.parent = parent;
        newObstacle.transform.position = new Vector2(transform.position.x,transform.position.y+mid.Next(minY,maxY));
    }

    public void ObstacleStop()
    {
        CancelInvoke("NewObstacle");
    }

}
