using UnityEngine;

namespace UGVRover.Data
{
    public interface ISettingsProvider
    {
        VehicleSettings GetSettings();
    }
}