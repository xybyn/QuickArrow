using UnityEngine;

public class KeyboardInputReader : MonoBehaviour, IInputReader
{
    public KeyCode KeyToTurn;

    public bool IsTurnArrowButtonClicked()
    {
        return Input.GetKeyDown(KeyToTurn);
    }
}
