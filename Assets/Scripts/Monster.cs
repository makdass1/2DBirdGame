using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
   [SerializeField]  Sprite _deadSprite;
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (ShouldDieFromCollison(collision))
      {
         Die();
      }
   }

    bool ShouldDieFromCollison(Collision2D collision)
   {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
           return true;

        if (collision.contacts[0].normal.y < 0.5)
        {
           return true; 
        }
        return false;
   }
   void Die()
   {
       gameObject.SetActive(false);
   }
}
