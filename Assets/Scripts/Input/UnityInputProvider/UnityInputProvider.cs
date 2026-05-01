using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace UGVRover.Input
{
    public class UnityInputProvider : IInputProvider, IDisposable
    {
        private InputSystemActions _inputActions;

        public event Action<Vector2> OnMove;

        public UnityInputProvider()
        {
            _inputActions = new InputSystemActions();
            _inputActions.Player.Move.performed += OnMoveCallback;
            _inputActions.Player.Move.canceled += OnMoveCallback;

            _inputActions.Enable();
        }
        private void OnMoveCallback(InputAction.CallbackContext context)
        {
            OnMove(context.ReadValue<Vector2>());
        }
        public void Dispose()
        {
            _inputActions.Disable();
            _inputActions.Player.Move.performed -= OnMoveCallback;
            _inputActions.Player.Move.canceled -= OnMoveCallback;
        }
    }
}