using UnityEngine;

namespace Paridot
{    
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private InputReader input;

        [SerializeField]
        private Transform cameraTransform;

        [SerializeField]
        private float speed;

        [SerializeField]
        private float sprintSpeed;

        [SerializeField]
        private float crouchSpeed;


        private Vector2 moveDirection;

        private bool isSprinting;
        private bool isCrouching;

        private void Start()
        {
            //associates the movement system with the players moveDirection variable
            input.MoveEvent += HandleMove;
        }

        private void Update()
        {
            Move();
        }

        private void HandleMove(Vector2 dir)
        {
            moveDirection = dir;
        }

        private void Move()
        {
            //skips the command early if no input is detected
            if (moveDirection == Vector2.zero)
            {
                return;
            }

            /*
             * adjusts the movement direction depending on where the camera is pointing
             * so that W key will always move the player towards where the camera is facing
             * and A key will always move the player to the right of where the camera is facing and so on
             */
            Vector3 move = cameraTransform.forward * moveDirection.y + cameraTransform.right * moveDirection.x;

            //adjusts the actual position of the player while also modifying the value according to the speed stat
            transform.position += move * (speed * Time.deltaTime);
        }
    }
}
