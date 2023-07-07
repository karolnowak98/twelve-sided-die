using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Input.Logic
{
    public class InputManager : IInitializable, IDisposable
    {
        private Controls _controls;
        
        public static Vector3 MousePosition => Mouse.current.position.ReadValue();

        public event Action OnLmbPressed;
        public event Action OnLmbCanceled;

        public void Initialize()
        {
            _controls = new Controls();
            
            _controls.Gameplay.Lmb.started += _ => OnLmbPressed?.Invoke();
            _controls.Gameplay.Lmb.canceled += _ => OnLmbCanceled?.Invoke();
            
            _controls.Enable();
        }

        public void Dispose()
        {
            _controls.Disable();
        }
        
        public static Vector3 GetMouseWorldPosition(LayerMask layerMask)
        {
            if (Camera.main == null)
            {
                return Vector3.zero;
            }
            
            var ray = Camera.main.ScreenPointToRay(MousePosition);
        
            return Physics.Raycast(ray, out var hit, Mathf.Infinity, layerMask) ? hit.point : Vector3.zero;
        }
    }
}