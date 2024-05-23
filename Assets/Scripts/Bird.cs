using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]  float _launchForce = 500;
    [SerializeField] private float _MaxDragonDistance = 5;
     Vector2 _startPosition;
     Rigidbody2D _rigidbody2D;
     private SpriteRenderer _spriteRenderer;
     private void Awake()
     {
         _rigidbody2D = GetComponent<Rigidbody2D>();
         _spriteRenderer = GetComponent<SpriteRenderer>();
     }

     void Start()
    {  _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
    }

    private void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
    }

     void OnMouseUp()
    {
        Vector2 currentPosition = _rigidbody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce((direction * _launchForce));
        _spriteRenderer.color = Color.white;
        

    }

    private void OnMouseDrag()
    {
        Vector3 maousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = maousePosition;

        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if (distance > _MaxDragonDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + (direction * _MaxDragonDistance);
        }
        
        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;


        _rigidbody2D.position = desiredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
       
    }
}
