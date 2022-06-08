using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDC_gameJam_player
{
    public class Character : MonoBehaviour
    {
        protected CircleCollider2D bodyCollider;
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
            bodyCollider = GetComponent<CircleCollider2D>();
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
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectGroundCircleRadius);
            foreach (Collider2D hit in hits)
            {
                if (hit.gameObject.layer == LayerMask.GetMask("Ground"))
                {
                    return true;
                }
            }
            return false;
        }


    }
}