using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public ItemManager itemManager;

    private void Update()
    {
        scoreText.text = itemManager.coins.ToString();
    }
}
