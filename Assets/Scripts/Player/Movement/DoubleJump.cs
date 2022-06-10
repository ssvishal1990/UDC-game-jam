using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDC_gameJam_player
{
    public class DoubleJump : Jump
    {

        protected bool doubleJumpPowerPicked;
        protected bool doubleJumpPerformed;

        
        protected override void initialize()
        {
            base.initialize();
            doubleJumpPowerPicked = false;
            doubleJumpPerformed = false;
            jumpCount = 0;
        }

        protected override void Update()
        {
            base.Update();
            if (jumpCount >= 2)
            {
                doubleJumpPerformed = true;
            }
            if (jumpCount < 2)
            {
                doubleJumpPerformed = false;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "DoubleJumpPowerUp")
            {
                doubleJumpPowerPicked =true;
                Destroy(collision.gameObject);
            }
        }

        protected override void PerformJump()
        {
            if (!doubleJumpPowerPicked)
            {
                base.PerformJump();
            }else
            {
                if (checkIfPlayerOnGround(detectGroundCircleRadius) || currentTimeLeftToJump > 0 || !doubleJumpPerformed)
                {
                    body.AddForce(Vector2.up * jumpForceMagitude, ForceMode2D.Impulse);
                    jumpCount++;
                }
            }

            
        }


    }
}