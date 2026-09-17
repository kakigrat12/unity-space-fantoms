using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RoomSpawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SpawnedRoom _current;
        [SerializeField] private SpawnedRoom[] _prefabs;
        [Space]
        [SerializeField] private BoxCollider _test;

        //private List<SpawnedRoom> _spawnedRooms = new();
        private Dictionary<Vector3, Transform> _openPassages = new();

        [Button]
        private void TestSpawn()
        {
            var passage = _openPassages.Count > 0 ? _openPassages.First().Value : transform;
            SpawnTo(passage, _current);
        }

        [Button]
        private void SpawnNext()
        {
            while(_openPassages.Count > 0)
            {
                var passage = _openPassages.First();
                var passagePoint = _openPassages.Count > 0 ? passage.Value : transform;
                var fitableRoom = FindFitableRoom(passagePoint);
                if(fitableRoom == null)
                {
                    _openPassages.Remove(passage.Key);
                }
                else
                {
                    SpawnTo(passagePoint, fitableRoom);
                    break;
                }
            }
        }

        private SpawnedRoom FindFitableRoom(Transform passageOut)
        {
            var random = new System.Random();
            var randomizedPrefabs = _prefabs.OrderBy(item => random.Next()).ToList();

            Debug.Log("L");

            foreach(var room in randomizedPrefabs)
            {
                if (IsFits(passageOut, room))
                    return room;
            }

            return null;
        }

        [Button]
        private void SpawnTo(Transform passageOut, SpawnedRoom roomToSpawn)
        {
            /*
            Transform passageFrom = roomToSpawn.Passages[1];//Random.Range(0, roomToSpawn.Passages.Length)
            Quaternion spawnRotation = Quaternion.FromToRotation(-passageFrom.forward, passage.forward);
            Vector3 spawnPosition = passage.position - spawnRotation * passageFrom.localPosition;
            */

            var (spawnPosition, spawnRotation) = GetJoinTo(passageOut, roomToSpawn, 1);

            var spawned = Instantiate(roomToSpawn, spawnPosition, spawnRotation, transform);

            foreach(var passage in spawned.Passages)
            {
                if (_openPassages.ContainsKey(passage.position))
                {
                    _openPassages.Remove(passage.position);
                }
                else
                {
                    _openPassages.Add(passage.position, passage);
                }
            }

            //_spawnedRooms.Add(spawned);
        }

        private bool IsFits(Transform passageOut, SpawnedRoom spawnedRoom)
        {
            var (spawnPosition, spawnRotation) = GetJoinTo(passageOut, spawnedRoom, 1);
            Bounds bounds = spawnedRoom.GetBounds();
            spawnPosition += spawnRotation * bounds.center;

            _test.transform.position = spawnPosition;
            _test.size = bounds.size;
            _test.transform.rotation = spawnRotation;
            //Gizmos.DrawCube(spawnPosition, bounds.size / 2f);

            bool result = !Physics.CheckBox(spawnPosition, bounds.size / 2.01f, spawnRotation);
            Debug.Log(spawnedRoom + " : " + result);
            return result;
        }

        private (Vector3 position, Quaternion rotation) GetJoinTo(Transform passageOut, SpawnedRoom newRoom, int passageIndexIn)
        {
            passageIndexIn = UnityEngine.Random.Range(0, newRoom.Passages.Length);
            Transform passageFrom = newRoom.Passages[passageIndexIn];//Random.Range(0, roomToSpawn.Passages.Length)
            Quaternion spawnRotation = Quaternion.FromToRotation(-passageFrom.forward, passageOut.forward);
            Vector3 spawnPosition = passageOut.position - spawnRotation * passageFrom.localPosition;

            return (spawnPosition, spawnRotation);
        }
    }
}