using TMPro;
using UnityEngine;

public class HUDLevel : MonoBehaviour
{
    TMP_Text levelText;

    void Awake()
    {
        levelText = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        GameManager.OnLevelChange += UpdateLevel;
    }

    void OnDisable()
    {
        GameManager.OnLevelChange += UpdateLevel;
    }

    void UpdateLevel(int levelNo)
    {
        if (levelText != null)
            levelText.text = "Level: " + levelNo.ToString();
    }
}
