using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject endCanvas;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //When player collides with EndSensor at last level of the game, show Game End screen
    void OnTriggerEnter2D(Collider2D other)
    {
        endCanvas.SetActive(true);
    }
    //Restart Game when, Restart Button is pressed at last level
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().RestartGame();
    }
}
