using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
     Vector2 _startPosition;
    void Start()
    {  _startPosition = GetComponent<Rigidbody2D>().position;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

     void OnMouseUp()
    {
        Vector2 currentPosition = GetComponent<Rigidbody2D>().position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();
        GetComponent<Rigidbody2D>().isKinematic = false;

        GetComponent<Rigidbody2D>().AddForce((direction * 500));
        GetComponent<SpriteRenderer>().color = Color.white;
        

    }

    private void OnMouseDrag()
    {
        Vector3 maousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(maousePosition.x, maousePosition.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
