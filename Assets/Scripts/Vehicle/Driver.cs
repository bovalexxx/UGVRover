using UnityEngine;
using UGVRover.Data;

public abstract class Driver : MonoBehaviour
{
    public abstract void Move(Vector2 input);

    public abstract void PassSettings(Settings settings);
}