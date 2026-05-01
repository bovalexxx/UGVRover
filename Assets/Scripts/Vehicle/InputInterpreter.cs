using UnityEngine;

public abstract class InputInterpreter
{
    protected float _influence;

    public abstract Vector2 CalculateInput(Vector2 input);

    public void SetInfluence(float influence)
    {
        _influence = influence;
    }
}
