using UnityEngine;
using System.Collections;

public class LukeMenuTest : MonoBehaviour {

    public string destination;
    public void LoadScene ()
    {
        Application.LoadLevel(destination);
    }
}
