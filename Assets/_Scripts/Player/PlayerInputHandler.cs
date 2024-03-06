using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _Scripts.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MoveInput { get; private set; }
        public bool JumpInput { get; private set; }
        public bool InteractInput { get; set; }
        
        [HideInInspector] public UnityEvent InteractEvent;
        [HideInInspector] public UnityEvent JumpEvent;
        [HideInInspector] public UnityEvent ShootEvent;

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                MoveInput = context.ReadValue<Vector2>();
            }
            else if (context.canceled)
            {
                MoveInput = Vector2.zero;
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                JumpEvent?.Invoke();
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            InteractInput = context.ReadValueAsButton();
            if (context.started)
            {
                InteractInput = true;
                StartCoroutine(ResetInteractButton());
                InteractEvent?.Invoke();
            }
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ShootEvent?.Invoke();
            }
        }

        private IEnumerator ResetInteractButton()
        {
            yield return new WaitForSeconds(1f);
            InteractInput = false;
        }
    }
}