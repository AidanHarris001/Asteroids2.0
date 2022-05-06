using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;
    public float respawnTime = 3.0f;
    public int lives = 3;
    public float invincibleTime = 3.0f;
    public int score = 0;

    void Start()
    {
        FindObjectOfType<Lives>().newLive(this);
        FindObjectOfType<Score>().newScore(this);
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

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

        if (this.lives <= 0) {
            GameOver();
        } else {
            Invoke(nameof(Respawn), this.respawnTime);
            FindObjectOfType<Lives>().newLive(this);
        }
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        this.player.gameObject.SetActive(true);
        
        Invoke(nameof(TurnOnCollisions), this.invincibleTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        this.lives = 3;
        this.score = 0;
        FindObjectOfType<Lives>().newLive(this);
        FindObjectOfType<Score>().newScore(this);

        Invoke(nameof(Respawn), this.respawnTime);
    }
}
