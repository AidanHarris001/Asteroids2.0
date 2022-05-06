using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int livesLost;
    public int highScore;
    public int bulletsShot;
    public int asteroidsDestroyed;

    public PlayerData (GameManager gameManager)
    {
        livesLost = gameManager.livesLost;
        highScore = gameManager.highScore;
        bulletsShot = gameManager.bulletsShot;
        asteroidsDestroyed = gameManager.asteroidsDestroyed;
    }
}
