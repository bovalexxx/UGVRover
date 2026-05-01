using UnityEngine;

namespace UGVRover.Data
{
    [CreateAssetMenu(menuName = "UGVRover/Rover settings")]
    public class SettingsSO : ScriptableObject, ISettingsProvider
    {
        public VehicleSettings _settings;

        public Settings GetSettings() => _settings;
    }
}