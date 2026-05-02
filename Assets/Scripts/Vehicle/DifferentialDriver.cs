using UGVRover.Data;
using UnityEngine;
using Zenject;

namespace UGVRover.Core
{
    public class DifferentialDriver : Driver
    {
        [Inject]
        private InputInterpreter inputInterpreter;

        [SerializeField]
        private ArticulationBody[] leftWheels;
        [SerializeField]
        private ArticulationBody[] rightWheels;

        private VehicleSettings _settings;

        public override void Move(Vector2 input)
        {
            Vector2 move = inputInterpreter.CalculateInput(input);
            float turn = move.x;
            float drive = move.y;

            if (_settings.InvertBackMovement && drive < 0) turn *= -1;

            float left = _settings.TargetVelocity * (drive + turn);
            float right = _settings.TargetVelocity * (drive - turn);

            Debug.Log("Input: " + move);
            Debug.Log("Wheels [left, right]: " + "[" + left + ", " + right + "]");

            foreach(ArticulationBody x in leftWheels)
            {
                var d = x.xDrive;
                d.targetVelocity = left;
                x.xDrive = d;
            }
            foreach (ArticulationBody x in rightWheels)
            {
                var d = x.xDrive;
                d.targetVelocity = right;
                x.xDrive = d;
            }
        }
        private void UpdateSettings()
        {
            foreach (ArticulationBody x in leftWheels)
            {
                var d = x.xDrive;
                d.forceLimit = _settings.MaxMotorForce;
                x.xDrive = d;
            }
            foreach (ArticulationBody x in rightWheels)
            {
                var d = x.xDrive;
                d.forceLimit = _settings.MaxMotorForce;
                x.xDrive = d;
            }
        }

        public override void PassSettings(Settings settings)
        {
            _settings = (VehicleSettings)settings;

            inputInterpreter.SetInfluence(_settings.TurnEvenness);

            UpdateSettings();
        }
    }
}