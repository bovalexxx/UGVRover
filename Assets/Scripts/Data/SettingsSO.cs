using UnityEngine;

namespace UGVRover.Data
{
    [CreateAssetMenu(menuName = "UGVRover/Rover settings")]
    public class SettingsSO : ScriptableObject, ISettingsProvider
    {
        public VehicleSettings settings;

        public VehicleSettings GetSettings() => settings;
    }
}