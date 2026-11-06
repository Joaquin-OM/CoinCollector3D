using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.SceneManagement.SceneManager;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int score = 0;

    public int Score => score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log($"Coin collected! Score: {score}");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(GetActiveScene().buildIndex);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
