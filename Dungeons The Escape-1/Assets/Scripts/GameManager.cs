using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    private int playerLives = 10;
    private int playerScore = 0;
    private int endLevelIndex;

    //TO MAKE THE GAME MANAGER A SINGLETON CLASS AND PERSIST THROUGH SCENCES
    void Awake()
    {
        int numOfGameManagers = FindObjectsOfType<GameManager>().Length; //To get the number of game managers present


        if(numOfGameManagers > 1 ) //if there are more than one Game Managers destroy this one. Other wise dont destroy on load
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
        livesText.text = playerLives.ToString(); //set the lives to current player lives
        scoreText.text = playerScore.ToString(); //set score to current player score
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

    //set score to new player score
    public void UpdateScore(int newScore)
    {
        playerScore += newScore;
        scoreText.text = playerScore.ToString(); 
    }

    private void TakeLife()
    {
        playerLives --;

        var currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentActiveScene);
        livesText.text = playerLives.ToString(); //set the lives to new player lives
    }

    public void RestartGame()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}


