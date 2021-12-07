using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    [SerializeField] int pickUpValue = 10;
    [SerializeField] AudioClip pickupSFX;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position); //play pickup sfx on camera position once
        FindObjectOfType<GameManager>().UpdateScore(pickUpValue); //Calling UpdateScore from game manager to update score after pick up
    }
}
