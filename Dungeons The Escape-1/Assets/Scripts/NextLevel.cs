using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] float nextLvlDelay = 1f;
    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        StartCoroutine("LoadNextLevel");
        Destroy(other.gameObject);
    }

    IEnumerator LoadNextLevel()
    
    {   
        yield return new WaitForSecondsRealtime(nextLvlDelay);
        var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1 );
    }
}
