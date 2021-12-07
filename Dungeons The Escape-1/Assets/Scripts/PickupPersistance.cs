using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupPersistance : MonoBehaviour
{
    private int startingScenceIndex;
    void Awake()
    {
        int numOfPickupPersisance = FindObjectsOfType<PickupPersistance>().Length;

        if(numOfPickupPersisance > 1)
        {
            Destroy(gameObject);
        }else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    public void DestroyOnNextLevel()
    {
        Destroy(gameObject);
    }

}

