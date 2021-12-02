using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int playerLives = 10;

    //TO MAKE THE GAME MANAGER A SINGLETON CLASS AND PERSIST THROUGH SCENCES
    void Awake()
    {
        int numOfGameManagers = FindObjectsOfType<GameManager>().Length; //To get the number of game managers present


        if(numOfGameManagers > 1) //if there are more than one Game Managers destroy this one. Other wise dont destroy on load
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void PlayerDeath() 
    {
        if(playerLives > 1)
        {

            TakeLife();

        }else

        {
            RestartGame();
        }
    }


    private void TakeLife()
    {
        playerLives --;

        var currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentActiveScene);
        Debug.Log(playerLives);
    }

    private void RestartGame()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}


