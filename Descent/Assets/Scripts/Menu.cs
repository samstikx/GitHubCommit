using UnityEngine;

public class Menu : MonoBehaviour
{

    public void onCharacterSelect()
    {
        Application.LoadLevel("CharacterSelect");
    }

    public void onEncounter1Select()
    {
        Application.LoadLevel("Encounter_1");
    }

}
