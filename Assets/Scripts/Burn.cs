using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Burn : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] float amount;

    float count = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        count += Time.deltaTime;
        if (MathF.Truncate(count) < amount)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
        else if (MathF.Truncate(count) >= amount)
        {
            gameObject.GetComponent<Image>().enabled = false;
      
            count = 0;
        }
    }
}
