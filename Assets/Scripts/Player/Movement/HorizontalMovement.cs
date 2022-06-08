using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UDC_gameJam_player
{
    public class HorizontalMovement : Abilities
    {
        [SerializeField] float horizontalSpeed;

        protected Vector2 direction;

        protected override void initialize()
        {
            base.initialize();
        }

        public void getMovementDirection(InputAction.CallbackContext context)
        {
            direction = context.ReadValue<Vector2>();
        }

        protected virtual void Update()
        {
            checkIfNeedToFlip();
        }

        protected virtual void  FixedUpdate()
        {
            Move();   
        }

        private void Move()
        {
            body.velocity = new Vector2(direction.x * horizontalSpeed, body.velocity.y);
        }

        protected virtual void checkIfNeedToFlip()
        {
            if (direction.x == -1 && !isLookingLeft)
            {
                flip();
            }
            else if (direction.x == 1 && isLookingLeft)
            {
                flip();
            }
        }
    }
}