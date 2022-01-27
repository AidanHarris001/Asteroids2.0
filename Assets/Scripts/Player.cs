using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrustSpeed = 1.0f;
    private Rigidbody2D _rigidbody;
    private bool _thursting;
    private float _turnDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _thursting = Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.LeftArrow)) {
            _turnDirection = 1.0f;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            _turnDirection = -1.0f;
        } else {
            _turnDirection = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        if (_thursting) {
            _rigidbody.AddForce(this.transform.up * this.thrustSpeed);
        }
    }
}
