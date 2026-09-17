using UnityEngine;

namespace Character_Controller
{
    [RequireComponent(typeof(CharacterMover))]
    public abstract class MovementState : MonoBehaviour
    {
        protected CharacterMover CharacterMover;
        
        public virtual void OnEnable()
        {
            CharacterMover = GetComponent<CharacterMover>();
        }
    }
}