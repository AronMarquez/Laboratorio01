using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   public float moveSpeed;
   
   public Transform upPoint, downPoint;

   private bool isMoving;

   private Rigidbody2D theRB;

   public SpriteRenderer theSR;

   private Animator anim;

   void Start() 
   {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        upPoint.parent = null;
        downPoint.parent = null;
   }

    void Update()
    {
        if(isMoving)
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

            theSR.flipX = true;
            
            if(transform.position.x > upPoint.position.x)
            {
                isMoving = false;
            }
        }else
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

            theSR.flipX = false;

            if(transform.position.x > downPoint.position.x)
            {
                isMoving = true;
            }
        }

        anim.SetBool("isMoving", isMoving);
    }
}
