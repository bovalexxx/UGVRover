using UnityEngine;
using UnityEngine.UI;
using UGVRover.Data;
using UGVRover.Camera;
using Zenject;

namespace UGVRover.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private Slider targetVelocitySlider;
        [SerializeField]
        private Toggle invertBackMovementToggle;
        [SerializeField]
        private Slider turnSharpnessSlider;
        [SerializeField]
        private Toggle cameraModeToggle;

        [Inject]
        ISettingsProvider _settingsProvider;

        private VehicleSettings vehicleSettings;

        [SerializeField]
        private CameraController cameraController;

        private void Start()
        {
            vehicleSettings = (VehicleSettings)_settingsProvider.GetSettings();
            targetVelocitySlider.onValueChanged.AddListener(UpdateTargetVelocity);
            targetVelocitySlider.value = vehicleSettings.TargetVelocity;

            cameraModeToggle.onValueChanged.AddListener(UpdateCameraMode);
            invertBackMovementToggle.onValueChanged.AddListener(InvertBackMovement);
            invertBackMovementToggle.isOn = vehicleSettings.InvertBackMovement;

            turnSharpnessSlider.onValueChanged.AddListener(UpdateTurnSharpness);
            turnSharpnessSlider.value = vehicleSettings.TurnEvenness;
        }
        private void UpdateTargetVelocity(float val)
        {
            vehicleSettings.TargetVelocity = val;
        }
        private void UpdateCameraMode(bool isOn)
        {
            cameraController.SetMode(isOn ? CameraController.CameraMode.FollowWithRotation : CameraController.CameraMode.LookAtFollow);
        }
        private void InvertBackMovement(bool invert)
        {
            vehicleSettings.InvertBackMovement = invert;
        }
        private void UpdateTurnSharpness(float val)
        {
            vehicleSettings.TurnEvenness = val;
        }
        private void OnDestroy()
        {
            targetVelocitySlider.onValueChanged.RemoveListener(UpdateTargetVelocity);
            cameraModeToggle.onValueChanged.RemoveListener(UpdateCameraMode);
            invertBackMovementToggle.onValueChanged.RemoveListener(InvertBackMovement);
            turnSharpnessSlider.onValueChanged.RemoveListener(UpdateTurnSharpness);
        }
    }
}