using UnityEngine;

public class MouseOverAttack : MonoBehaviour
{
    int playerTurn;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Collider>();
    }

    void OnMouseEnter()
    {
        playerTurn = GameObject.Find("Board").GetComponent<Game>().GetPlayerTurnNo();
        //players[playerTurn].Attack();
    }

    // Update is called once per frame
  /*  void Update()
    {
        if (GameObject.FindGameObjectWithTag("goblin"))                         /experimental code. ran out of time
        {
            OnMouseEnter();
        }
    }   */
}
