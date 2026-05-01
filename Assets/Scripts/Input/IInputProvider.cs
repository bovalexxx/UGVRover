using UnityEngine;
using System;

namespace UGVRover.Input
{
    interface IInputProvider
    {
        event Action<Vector2> OnMove;
    }
}