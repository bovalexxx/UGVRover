using UnityEngine;

public class DifferentialDriveInputInterpreter : InputInterpreter
{
    public override Vector2 CalculateInput(Vector2 rawinput)
    {
        Vector2 input = CircleToSquare(rawinput);

        float xMultiplier = 1f - (Mathf.Abs(input.y) * Mathf.Clamp01(_influence));
        input.x *= xMultiplier;

        return input;
    }
    private Vector2 CircleToSquare(Vector2 rawInput)
    {
        if (rawInput == Vector2.zero) return Vector2.zero;

        float absX = Mathf.Abs(rawInput.x);
        float absY = Mathf.Abs(rawInput.y);
        float maxAxis = Mathf.Max(absX, absY);

        Vector2 square = rawInput * (rawInput.magnitude / maxAxis);
        return square;
    }
}
