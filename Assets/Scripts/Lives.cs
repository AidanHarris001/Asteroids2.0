using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lives : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void newLive(GameManager gameManager)
    {
        scoreText.text = "LIVES: " + gameManager.lives.ToString();
    }
}
