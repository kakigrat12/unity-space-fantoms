using System;
using UnityEngine.InputSystem;

namespace Character_Controller.Character_Camera_Inputs.HideMouse
{
    public interface IInputHideMouse
    {
        public CameraControllerInputScheme Input { get; }
        public void Subscribe(Action<InputAction.CallbackContext> action);
        public void Unsubscribe(Action<InputAction.CallbackContext> action);
    }
}