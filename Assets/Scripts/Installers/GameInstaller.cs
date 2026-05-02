using UnityEngine;
using Zenject;
using UGVRover.Input;
using UGVRover.Data;
using System.IO;

namespace UGVRover.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private SettingsSO roverSettingsSO;
        [SerializeField] private GameSettingsSO gameSettingsSO;

        public override void InstallBindings()
        {
            Container.Bind<IInputProvider>().To<UnityInputProvider>().AsSingle();
#if UNITY_EDITOR
            Container.Bind<ISettingsProvider>().FromInstance(roverSettingsSO).AsSingle();
#else
            GameSettings gameSettings = (GameSettings)gameSettingsSO.GetSettings();
            string configAbsolutePath = Path.Combine(Application.streamingAssetsPath, gameSettings.ConfigName);
            Container.Bind<ISettingsProvider>().To<JsonSettingsProvider>().AsSingle().WithArguments(roverSettingsSO.GetSettings(), configAbsolutePath);
#endif
            Container.Bind<InputInterpreter>().To<DifferentialDriveInputInterpreter>().AsSingle();
        }
    }
}