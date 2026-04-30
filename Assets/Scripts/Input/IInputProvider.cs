using UnityEngine;
using System;

namespace UGVRover.Input
{
    interface IInputProvider
    {
        Vector2 MoveDirection { get; }

        event Action<Vector2> OnMove;
    }
}