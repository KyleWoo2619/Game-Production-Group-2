using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Paridot
{
    [CreateAssetMenu(menuName = "InputReader")]
    public class InputReader : ScriptableObject, GameInput.IPlayerActions, GameInput.IUIActions
    {
        private GameInput gameInput;

        private void OnEnable()
        {
            // if there isn't a gameInput already, creates a new one
            if(gameInput == null)
            {
                gameInput= new GameInput();

                gameInput.Player.SetCallbacks(this);
                gameInput.UI.SetCallbacks(this);

                //sets the default to character controls
                SetPlayer();

                //disables the cursor at the start of the game
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        //swaps controls to character
        public void SetPlayer()
        {
            gameInput.Player.Enable();
            gameInput.UI.Disable();
        }

        //swaps controls to UI
        public void SetUI()
        {
            gameInput.Player.Disable();
            gameInput.UI.Enable();
        }

        
        public event Action<Vector2> MoveEvent;
        public event Action<Vector2> LookEvent;

        public event Action PauseEvent;
        public event Action ResumeEvent;

        /*
         * functions for all the event systems with the input manager
         * any function with a throw command is not yet implemented and should be ignored
         */

        public void OnAttack(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        // if a movement button is pressed, triggers  MoveEvent with the associated Vector2 holding the input from the player
        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }
        public void OnSprint(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            LookEvent?.Invoke(context.ReadValue<Vector2>());
        }

        //if a pause key is pressed, triggers the PauseEvent
        public void OnPause(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                PauseEvent.Invoke();
                SetUI();

                //disables the cursor
                Cursor.lockState = CursorLockMode.None;
            }
        }

        //if a resume key is pressed, triggers the ResumeEvent
        public void OnResume(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                ResumeEvent.Invoke();
                SetPlayer();

                //enables the cursor
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
