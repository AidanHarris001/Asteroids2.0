using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50.0f;
    public float maxLifeTime = 10.0f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //picks random asteriod to spawn from array
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        //controls the spawned orientation of the asteriod
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        //controls the size of the spawned asteriod
        this.transform.localScale = Vector3.one * this.size;

        _rigidbody.mass = this.size * 2.0f;
    }

    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifeTime);
    }
}