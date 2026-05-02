using UnityEngine;
using System;

namespace UGVRover.Data
{
    public abstract class Settings { }

    [Serializable]
    public class VehicleSettings : Settings
    {
        [Range(100, 1500)]
        [SerializeField] private float targetVelocity;
        [Range(100, 20000)]
        [SerializeField] private float maxMotorForce;
        [Range(0, 0.9f)]
        [SerializeField] private float turnEvenness;
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
        public float TurnEvenness
        {
            get { return turnEvenness; }
            set { turnEvenness = value; }
        }
    }
    [Serializable]
    public class GameSettings : Settings
    {
        [SerializeField] private string congfigName;

        public string ConfigName => congfigName;
    }
}
