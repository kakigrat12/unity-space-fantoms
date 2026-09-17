using Character_Controller.Character_Camera_Inputs.HideMouse;
using Character_Controller.Character_Camera_Inputs.ShowMouse;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Character_Controller
{
    public sealed class ShowHideMouse : MonoBehaviour
    {
        private InputShowMouse _inputShowMouse;
        private InputHideMouse _inputHideMouse;

        private void Awake()
        {
            _inputShowMouse = new InputShowMouse();
            _inputHideMouse = new InputHideMouse();
            
            _inputShowMouse.Subscribe(ShowMouse);
            _inputHideMouse.Subscribe(HideMouse);
        }

        private void OnDisable()
        {
            _inputShowMouse.Unsubscribe(ShowMouse);
            _inputHideMouse.Unsubscribe(HideMouse);
        }

        private void ShowMouse(CallbackContext obj)
        {
            Debug.Log("ShowMouse");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        private void HideMouse(CallbackContext obj)
        {
            Debug.Log("HideMouse");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}