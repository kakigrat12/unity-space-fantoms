using System;
using Cinemachine;
using UnityEngine;

namespace Character_Controller
{
    public class CharacterCamera : MonoBehaviour
    {
        private CinemachinePOV _cinemachinePov;
        [SerializeField] private CinemachineVirtualCamera cvcCamera;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Vector3 offset;

        private void OnEnable()
        {
            _cinemachinePov = cvcCamera.GetCinemachineComponent<CinemachinePOV>();
            if (_cinemachinePov == null)
                throw new Exception("Please set Cinemachine->AIM->POV");
        }

        private void Update()
        {
            PlayerRotationToViewCamera();
            CameraToPositionPlayer();
        }

        /// <summary>
        /// Move camera to position of player
        /// </summary>
        private void CameraToPositionPlayer()
        {
            cvcCamera.transform.position = playerTransform.position + offset;
        }

        /// <summary>
        /// Player rotation to view camera
        /// </summary>
        private void PlayerRotationToViewCamera()
        {
            var targetRotation = Quaternion.Euler(0f, _cinemachinePov.m_HorizontalAxis.Value, 0f);
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}