using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private ArticulationBody w_l1;
    [SerializeField]
    private ArticulationBody w_l2;
    [SerializeField]
    private ArticulationBody w_r1;
    [SerializeField]
    private ArticulationBody w_r2;

    [SerializeField]
    private InputAction cont;

    private void Start()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        Debug.Log(move);

        float left = speed * (move.y + move.x);
        float right = speed * (move.y - move.x);


        var drive = w_l1.xDrive;
        drive.targetVelocity = left;
        w_l1.xDrive = drive;
        drive = w_l2.xDrive;
        drive.targetVelocity = left;
        w_l2.xDrive = drive;

        var drive2 = w_r1.xDrive;
        drive2.targetVelocity = right;
        w_r1.xDrive = drive2;
        drive2 = w_r2.xDrive;
        drive2.targetVelocity = right;
        w_r2.xDrive = drive2;
    }
}
