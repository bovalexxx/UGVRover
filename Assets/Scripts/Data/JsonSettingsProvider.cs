using UnityEngine;

namespace UGVRover.Data
{
    public class JsonSettingsProvider : ISettingsProvider
    {
        public VehicleSettings _settings;

        public VehicleSettings GetSettings() => _settings;

        public JsonSettingsProvider(string json)
        {
            _settings = JsonUtility.FromJson<VehicleSettings>(json);
        }
    }
}