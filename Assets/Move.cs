using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start()
    {
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(horizontal, 0, vertical) * _speed * Time.deltaTime;
        FlipSprite(horizontal);
    }

    private void FlipSprite(float horizontal)
    {
        if (horizontal != 0)
        {
            _spriteRenderer.flipX = horizontal > 0;
        }
    }
}
