using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;
    public float respawnTime = 3.0f;
    public int lives = 3;
    public float invincibleTime = 3.0f;
    public int score = 0;
    public int bulletsShot = 0;
    public int asteroidsDestroyed = 0;
    public int livesLost = 0;
    public int highScore = 0;

    void Start()
    {
        FindObjectOfType<Lives>().newLive(this);
        FindObjectOfType<Score>().newScore(this);

        PlayerData data = SaveSystem.LoadPlayer();

        bulletsShot = data.bulletsShot;
        asteroidsDestroyed = data.asteroidsDestroyed;
        livesLost = data.livesLost;
        highScore = data.highScore;
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();
        this.asteroidsDestroyed += 1;

        if (asteroid.size < 0.75f) {
            this.score += 100;
            FindObjectOfType<Score>().newScore(this);
        } else if (asteroid.size < 1.25f) {
            this.score += 50;
            FindObjectOfType<Score>().newScore(this);
        } else {
            this.score += 25;
            FindObjectOfType<Score>().newScore(this);
        }
    }
    
    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        this.lives--;
        this.livesLost++;

        if (this.lives <= 0) {
            GameOver();
        } else {
            Invoke(nameof(Respawn), this.respawnTime);
            FindObjectOfType<Lives>().newLive(this);
        }
    }

    public void PlayerShot()
    {
        this.bulletsShot += 1;
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        this.player.gameObject.SetActive(true);
        this.player.GetComponent<SpriteRenderer>().color = Color.yellow;
        
        Invoke(nameof(TurnOnCollisions), this.invincibleTime);

    }

    private void TurnOnCollisions()
    {
        this.player.GetComponent<SpriteRenderer>().color = Color.white;
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (score > data.highScore) {
            highScore = score;
        }

        SaveSystem.SavePlayer(this);
        this.lives = 3;
        this.score = 0;
        FindObjectOfType<Lives>().newLive(this);
        FindObjectOfType<Score>().newScore(this);

        Invoke(nameof(Respawn), this.respawnTime);
    }
}
