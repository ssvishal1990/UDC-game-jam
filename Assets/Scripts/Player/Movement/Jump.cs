using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UDC_gameJam_player
{
    public class Jump : Abilities
    {

        [SerializeField] float jumpForceMagitude = 10f;
        [SerializeField] float detectGroundCircleRadius = 1f;
        [SerializeField] float timeToJumpAfterLeavingGround = .5f;
        
        
        
        protected bool jumpPressed;
        public float  currentTimeLeftToJump;

        protected override void initialize()
        {
            base.initialize();
            jumpPressed = false;
            currentTimeLeftToJump = timeToJumpAfterLeavingGround;
        }

        // Update is called once per frame
        void Update()
        {
            if (!checkIfPlayerOnGround(detectGroundCircleRadius))
            {
                updateCurrentTimeLeftToJump();
            }else
            {
                currentTimeLeftToJump = timeToJumpAfterLeavingGround;
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

        protected void PerformJump()
        {
            if (checkIfPlayerOnGround(detectGroundCircleRadius) || currentTimeLeftToJump > 0)
            {
                body.AddForce(Vector2.up * jumpForceMagitude, ForceMode2D.Impulse);
            }else
            {
                Debug.Log("Ground not detected");
            }
        }





    }
}