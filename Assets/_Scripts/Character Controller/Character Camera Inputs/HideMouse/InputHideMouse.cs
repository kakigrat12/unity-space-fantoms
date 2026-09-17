using System;
using Character_Controller.Static;
using static UnityEngine.InputSystem.InputAction;

namespace Character_Controller.Character_Camera_Inputs.HideMouse
{
    public class InputHideMouse : IInputHideMouse
    {
        public CameraControllerInputScheme Input { get; } = InputsStaticData.CameraControllerInputScheme.Input;
        public void PressButton(CallbackContext obj) => Input.Game.HideMouse.WasPerformedThisFrame();
        public void Subscribe(Action<CallbackContext> action) => Input.Game.HideMouse.performed += action;
        public void Unsubscribe(Action<CallbackContext> action) => Input.Game.HideMouse.performed -= action;
    }
}