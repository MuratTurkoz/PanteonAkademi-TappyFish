using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] float distance = -10f;
    [SerializeField] float position = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoopMove();
    }

    private void LoopMove()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime,transform.position.y);
        if (transform.position.x < distance)
        {
            if (transform.name=="Ground")
            {

            transform.position = new Vector2(-0.27f, -8);
            }
            else if (transform.name == "Background")
            {
                transform.position = new Vector2(position, 0);

            }

        }

       
        //transform.Translate(Vector3.left*speed*Time.deltaTime);
    }
}
