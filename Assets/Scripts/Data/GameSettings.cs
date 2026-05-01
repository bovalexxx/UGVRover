using UnityEngine;

namespace UGVRover.Data
{
    [CreateAssetMenu(menuName = "UGVRover/Game settings")]
    public class GameSettingsSO : ScriptableObject, ISettingsProvider
    {
        public GameSettings _settings;

        public Settings GetSettings() => _settings;
    }
}