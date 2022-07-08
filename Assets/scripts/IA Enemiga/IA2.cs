using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA2 : MonoBehaviour {
   public Transform player;
   public float moveSpeed = 5f;
   private Vector2 movement;
   private Rigidbody2D rb;

   void Start() {
     rb= this.GetComponent<Rigidbody2D>();
   }

   void Update() {
      Vector3 direction = player.position - transform.position;
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      direction.Normalize();
      movement = direction;
   }

   private void FixedUpdate() 
   {
      moveCharacter(movement);
   }

   void moveCharacter(Vector2 direction)
   {
      rb.MovePosition((Vector2) transform.position + (direction * moveSpeed * Time.deltaTime));
   }
}