using UnityEngine;

namespace Character_Controller.Character_Inputs.Walk
{
    public interface IInputWalk
    {
        public CharacterControllerInputScheme InputWalk { get;}
        public Vector2 GetDirectionMove();
    }
}