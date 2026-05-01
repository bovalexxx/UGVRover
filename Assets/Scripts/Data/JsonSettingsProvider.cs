using System.IO;
using UnityEngine;

namespace UGVRover.Data
{
    public class JsonSettingsProvider : ISettingsProvider
    {
        public VehicleSettings _settings;

        public Settings GetSettings() => _settings;

        public JsonSettingsProvider(VehicleSettings defaultSettings, string configPath)
        {
            if (File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                VehicleSettings configData = JsonUtility.FromJson<VehicleSettings>(json);
                _settings = configData;
            }
            else
            {
                string json = JsonUtility.ToJson(defaultSettings);
                File.WriteAllText(configPath, json);
                _settings = defaultSettings;
            }
        }
    }
}