using UnityEngine;

namespace Character_Controller.Character_Camera_Inputs.MouseMove
{
    public interface IInputMouseMove
    {
        public CameraControllerInputScheme InputMouseMove { get;}
        public Vector2 GetDirectionMouseMove();
    }
}