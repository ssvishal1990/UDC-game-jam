using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDC_gameJam_player
{
    public class Character : MonoBehaviour
    {
        protected CapsuleCollider2D bodyCollider;
        protected Rigidbody2D body;
        protected Animator animator;
        protected UDCgamejam playerInputActions;
        protected bool isLookingLeft;
        // Start is called before the first frame update


        protected virtual void Start()
        {
            initialize();
        }

        protected virtual void initialize()
        {
            bodyCollider = GetComponent<CapsuleCollider2D>();
            body = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            playerInputActions = new UDCgamejam();
            isLookingLeft = false;
        }

        protected virtual void flip()
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            isLookingLeft = !isLookingLeft;
        }

        protected bool checkIfPlayerOnGround(float detectGroundCircleRadius)
        {
            //Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectGroundCircleRadius);

            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, detectGroundCircleRadius, LayerMask.GetMask("Ground"));
            
            if (hits.Length > 0)
            {
                Debug.DrawLine(transform.position, hits[0].point);
                return true;
            }
            return false;
        }


    }
}