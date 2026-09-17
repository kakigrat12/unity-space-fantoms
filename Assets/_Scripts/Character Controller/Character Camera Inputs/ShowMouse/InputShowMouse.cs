using System;
using Character_Controller.Static;
using static UnityEngine.InputSystem.InputAction;

namespace Character_Controller.Character_Camera_Inputs.ShowMouse
{
    public class InputShowMouse : IInputShowMouse
    {
        public CameraControllerInputScheme Input { get; } = InputsStaticData.CameraControllerInputScheme.Input;
        public void PressButton(CallbackContext obj) => Input.Game.ShowMouse.WasPerformedThisFrame();
        public void Subscribe(Action<CallbackContext> action) => Input.Game.ShowMouse.performed += action;
        public void Unsubscribe(Action<CallbackContext> action) => Input.Game.ShowMouse.performed -= action;
    }
}