using UnityEngine;
using System;

namespace UGVRover.Data
{
    public abstract class Settings { }

    [Serializable]
    public class VehicleSettings : Settings
    {
        [SerializeField] private float targetVelocity;
        [SerializeField] private float maxMotorForce;
        [SerializeField] private bool invertBackMovement;

        public float TargetVelocity
        {
            get { return targetVelocity; }
            set { targetVelocity = value; }
        }
        public float MaxMotorForce
        {
            get { return maxMotorForce; }
            set { maxMotorForce = value; }
        }
        public bool InvertBackMovement
        {
            get { return invertBackMovement; }
            set { invertBackMovement = value; }
        }
    }
    [Serializable]
    public class GameSettings : Settings
    {
        [SerializeField] private string congfigName;

        public string ConfigName => congfigName;
    }
}
