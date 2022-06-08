using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDC_gameJam_player
{
    public class AnimationController : Abilities
    {
        [SerializeField] float rayCastlength;
        [SerializeField] LayerMask groundLayerMask;

        // Update is called once per frame
        protected override void initialize()
        {
            base.initialize();
        }

        void Update()
        {
            animator.SetBool("IsGrounded", isPlayerGrounded());
            animator.SetFloat("Speed", body.velocity.x);
            animator.SetFloat("vSpeed", body.velocity.y);
            animator.SetBool("IsIdle", isPlayerIdle());
        }

        private bool isPlayerGrounded()
        {
            RaycastHit2D hit =  Physics2D.Raycast(transform.position, Vector2.down, rayCastlength, groundLayerMask);
            if (hit) return true;
            else return false;
        }

        private bool isPlayerIdle()
        {
            if (Mathf.Approximately(body.velocity.x, 0f) && Mathf.Approximately(body.velocity.y, 0f)) return true;
            else return false;
        }
    }
}