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
            Container.Bind<ISettingsProvider>().FromInstance(roverSettings).AsSingle();
        }
    }
}