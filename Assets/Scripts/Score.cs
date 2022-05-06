using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void newScore(GameManager gameManager)
    {
        scoreText.text = "SCORE: " + gameManager.score.ToString();
    }
}
