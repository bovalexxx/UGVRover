using UnityEngine;
using UnityEngine.InputSystem;
using UGVRover.Input;
using UGVRover.Data;
using Zenject;

namespace UGVRover
{
    public class VehicleController : MonoBehaviour
    {
        [Inject]
        private IInputProvider _inputProvider;

        [Inject]
        private ISettingsProvider _settingsProvider;

        private VehicleSettings _settings;

        [SerializeField]
        private ArticulationBody w_l1;
        [SerializeField]
        private ArticulationBody w_l2;
        [SerializeField]
        private ArticulationBody w_r1;
        [SerializeField]
        private ArticulationBody w_r2;

        private void Start()
        {
            _inputProvider.OnMove += Move;
            _settings = (VehicleSettings)_settingsProvider.GetSettings();
        }

        public void Move(Vector2 direction)
        {
            Vector2 move = direction;
            Debug.Log(move);

            float left = _settings.Speed * (move.y + move.x);
            float right = _settings.Speed * (move.y - move.x);


            var drive = w_l1.xDrive;
            drive.targetVelocity = left;
            w_l1.xDrive = drive;
            drive = w_l2.xDrive;
            drive.targetVelocity = left;
            w_l2.xDrive = drive;

            var drive2 = w_r1.xDrive;
            drive2.targetVelocity = right;
            w_r1.xDrive = drive2;
            drive2 = w_r2.xDrive;
            drive2.targetVelocity = right;
            w_r2.xDrive = drive2;
        }
    }
}
