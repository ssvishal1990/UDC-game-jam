using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UDC_gameJam_player
{
    public class Jump : Abilities
    {

        [SerializeField] float jumpForceMagitude = 10f;
        [SerializeField] public float detectGroundCircleRadius = 1f;
        protected bool jumpPressed;
        protected override void initialize()
        {
            base.initialize();
            jumpPressed = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void jumpKeyPressed(InputAction.CallbackContext context)
        {
            if (context.started || context.canceled) return;
            PerformJump();

        }

        protected void PerformJump()
        {
            if (checkIfPlayerOnGround(detectGroundCircleRadius))
            {
                body.AddForce(Vector2.up * jumpForceMagitude, ForceMode2D.Impulse);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectGroundCircleRadius);
        }




    }
}