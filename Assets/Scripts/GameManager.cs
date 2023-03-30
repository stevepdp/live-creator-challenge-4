using System;
using UnityEngine;

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
}