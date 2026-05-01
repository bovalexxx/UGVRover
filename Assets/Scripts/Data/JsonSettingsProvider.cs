using System.IO;
using UnityEngine;

namespace UGVRover.Data
{
    public class JsonSettingsProvider : ISettingsProvider
    {
        public VehicleSettings _settings;

        private const string configPath = "config.json";
        private string absolutePath = Path.Combine(Application.streamingAssetsPath, configPath);

        public VehicleSettings GetSettings() => _settings;

        public JsonSettingsProvider(VehicleSettings defaultSettings)
        {
            if (File.Exists(absolutePath))
            {
                string json = File.ReadAllText(absolutePath);
                VehicleSettings configData = JsonUtility.FromJson<VehicleSettings>(json);
                _settings = configData;
            }
            else
            {
                string json = JsonUtility.ToJson(defaultSettings);
                File.WriteAllText(absolutePath, json);
                _settings = defaultSettings;
            }
        }
    }
}