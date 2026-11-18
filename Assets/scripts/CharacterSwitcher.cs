using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public MonoBehaviour character1Controller;
    public MonoBehaviour character2Controller;
    private bool controllingFirst = true;

    void Start()
    {
        SetActiveCharacter(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            controllingFirst = !controllingFirst;
            SetActiveCharacter(controllingFirst);
        }
    }

    void SetActiveCharacter(bool useFirst)
    {
        character1Controller.enabled = useFirst;
        character2Controller.enabled = !useFirst;
    }
}