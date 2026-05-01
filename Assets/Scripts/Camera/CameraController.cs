using UnityEngine;
using System.Collections.Generic;

namespace UGVRover.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> cameraModes;

        private CameraMode _currentMode;

        public void SetMode(CameraMode mode)
        {
            if (cameraModes == null) return;
            if ((int)mode >= cameraModes.Count) return;
            cameraModes[(int)_currentMode].SetActive(false);
            cameraModes[(int)mode].SetActive(true);
            _currentMode = mode;
        }
        public enum CameraMode
        {
            LookAtFollow,
            FollowWithRotation
        }
    }
}
