using UnityEngine;
using System;

namespace UGVRover.Data
{
    public abstract class Settings { }

    [Serializable]
    public class VehicleSettings : Settings
    {
        [SerializeField] private float speed;

        public float Speed => speed;
    }
    [Serializable]
    public class GameSettings : Settings
    {
        [SerializeField] private string congfigName;

        public string ConfigName => congfigName;
    }
}
