using UnityEngine;
using Zenject;
using UGVRover.Input;
using UGVRover.Data;

namespace UGVRover.Installers
{
    public class VehicleInstaller : MonoInstaller
    {
        [SerializeField] private SettingsSO roverSettings;

        public override void InstallBindings()
        {
            Container.Bind<IInputProvider>().To<UnityInputProvider>().AsSingle();
#if !UNITY_EDITOR
            Container.Bind<ISettingsProvider>().FromInstance(roverSettings).AsSingle();
#else
            Container.Bind<ISettingsProvider>().To<JsonSettingsProvider>().AsSingle().WithArguments(roverSettings.GetSettings());
#endif
        }
    }
}