using System;
using static UnityEngine.InputSystem.InputAction;

namespace Character_Controller.Character_Camera_Inputs.ShowMouse
{
    public interface IInputShowMouse
    {
        public CameraControllerInputScheme Input { get; }
        public void Subscribe(Action<CallbackContext> action);
        public void Unsubscribe(Action<CallbackContext> action);
    }
}