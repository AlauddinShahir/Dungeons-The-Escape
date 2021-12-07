using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    [SerializeField] float risingSpeed = 0.2f; //Unity units per second

    // Update is called once per frame
    void Update()
    {
        RiseWater();
    }
    
    private void RiseWater()
    {
        float Ymovement = risingSpeed * Time.deltaTime;

        transform.Translate(new Vector2(0f, Ymovement));
    }
}

