using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomSpawner
{
    public class SpawnedRoom : MonoBehaviour
    {
        [SerializeField] private Transform[] _passages;
        public Transform[] Passages => _passages;

        public Bounds GetBounds()
        {
            Bounds result = new();
            foreach (var x in GetAllColliders())
                result.Encapsulate(x.bounds);

            return result;
        }
        private Collider[] GetAllColliders() => GetComponentsInChildren<Collider>();
    }
}
