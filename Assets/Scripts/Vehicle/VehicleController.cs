using UnityEngine;
using UnityEngine.InputSystem;
using UGVRover.Input;
using UGVRover.Data;
using Zenject;

namespace UGVRover.Core
{
    public class VehicleController : MonoBehaviour
    {
        [Inject]
        private IInputProvider _inputProvider;

        [Inject]
        private ISettingsProvider _settingsProvider;

        [SerializeField]
        private Driver driver;

        private void Start()
        {
            _inputProvider.OnMove += Move;
            driver.PassSettings(_settingsProvider.GetSettings());
        }
        private void OnDestroy()
        {
            _inputProvider.OnMove -= Move;
        }

        public void Move(Vector2 direction)
        {
            driver.Move(direction);
        }
    }
}
