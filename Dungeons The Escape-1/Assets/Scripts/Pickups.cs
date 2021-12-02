using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    [SerializeField] int pickUpValue = 10;
    [SerializeField] AudioClip pickupSFX;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);   
        Destroy(gameObject);
    }
}
