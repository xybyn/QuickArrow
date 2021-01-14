using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMotor Motor;
    public IInputReader InputReader;
    private void Update()
    {
        if(InputReader.IsTurnArrowButtonClicked())
        {
            Motor.Turn();
        }
    }
}
