using UnityEngine;

public abstract class InputInterpreter
{
    private float influence;

    public abstract Vector2 CalculateInput(Vector2 input);
}
