using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            if (_instance == null)
            {
                _instance = Instantiate(new GameObject("GameManager")).AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    public static event Action<int> OnLevelChange;
    public static event Action<int> OnScoreChange;

    int level = 1;
    int score = 0;
    int levelCompleteReward = 1000;

    void OnEnable()
    {
        PlayerHealth.OnPlayerDead += GameOver;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerDead -= GameOver;
    }

    void Awake()
    {
        EnforceSingleInstance();
    }

    void EnforceSingleInstance()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void GameOver()
    {
        score = 0;
        level = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        score += levelCompleteReward;
        OnScoreChange?.Invoke(score);

        level++;
        OnLevelChange?.Invoke(level);
    }

    void UpdateScore()
    {
        OnScoreChange?.Invoke(score);
    }
}