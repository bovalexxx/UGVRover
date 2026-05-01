using UnityEngine;

public class DifferentialDriveInputInterpreter : InputInterpreter
{
    public override Vector2 CalculateInput(Vector2 input)
    {
        float minTurn = _influence;
        float turnFactor = Mathf.Lerp(1f, minTurn, Mathf.Abs(input.y));
        float turn = input.x;// * turnFactor;

        Vector2 output = new Vector2(turn, input.y);
        return output;
    }
}
