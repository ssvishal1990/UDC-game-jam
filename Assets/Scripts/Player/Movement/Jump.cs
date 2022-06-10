using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UDC_gameJam_player
{
    public class Jump : Abilities
    {

        [SerializeField] protected float jumpForceMagitude = 10f;
        [SerializeField] protected float detectGroundCircleRadius = 1f;
        [SerializeField] protected float timeToJumpAfterLeavingGround = .5f;
        
        
        
        protected bool jumpPressed;
        protected int jumpCount;
        public float  currentTimeLeftToJump;
        

        protected override void initialize()
        {
            base.initialize();
            jumpPressed = false;
            currentTimeLeftToJump = timeToJumpAfterLeavingGround;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (!checkIfPlayerOnGround(detectGroundCircleRadius))
            {
                updateCurrentTimeLeftToJump();
            }else
            {
                currentTimeLeftToJump = timeToJumpAfterLeavingGround;
                jumpCount = 0;
            }
        }

        private void updateCurrentTimeLeftToJump()
        {
            currentTimeLeftToJump -= Time.deltaTime;
        }

        public void jumpKeyPressed(InputAction.CallbackContext context)
        {
            if (context.started || context.canceled ) return;
            PerformJump();

        }

        protected virtual void PerformJump()
        {
            if (checkIfPlayerOnGround(detectGroundCircleRadius) || currentTimeLeftToJump > 0)
            {
                body.AddForce(Vector2.up * jumpForceMagitude, ForceMode2D.Impulse);
            }
        }



    }
}