using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xVal = 50.5f;
    float yVal = 50.5f;
    //delegate int Actiononi(int val);
    //Actiononi setActionse = new Actiononi(Actionse);
    //bool complete = false;
    int move = 0, playerTurnNumber = 0, thisPlayerNo = 0;
    public GameObject players;

    void Start()
    {
        players = this.gameObject;
        SetPlayerNo();
    }

    void Update()
    {
        if (playerTurnNumber == thisPlayerNo)
        {
            CharacterMovement();
        }
    }

    void SetPlayerNo()
    {
        switch (this.gameObject.name)
        {
            case "Player1":
                thisPlayerNo = 0;
                break;
            case "Player2":
                thisPlayerNo = 1;
                break;
            case "Player3":
                thisPlayerNo = 2;
                break;
            case "Player4":
                thisPlayerNo = 3;
                break;
            default:
                Debug.Log("well shit");
                break;
        }
    }

    public void MovementSelected(int moveTemp, int playerNo)
    {
        playerTurnNumber = playerNo;
        move = moveTemp;
    }

    void CharacterMovement()
    {
        if (Input.GetKeyDown(KeyCode.W) && move > 0)
        {
            players.gameObject.transform.Translate(0, 0, -yVal);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.Q) && move > 0)
        {
            players.gameObject.transform.Translate(-xVal, 0, -yVal);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.A) && move > 0)
        {
            players.gameObject.transform.Translate(-xVal, 0, 0);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.Z) && move > 0)
        {
            players.gameObject.transform.Translate(-xVal, 0, yVal);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.X) && move > 0)
        {
            players.gameObject.transform.Translate(0, 0, yVal);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.C) && move > 0)
        {
            players.gameObject.transform.Translate(xVal, 0, yVal);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.D) && move > 0)
        {
            players.gameObject.transform.Translate(xVal, 0, 0);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.E) && move > 0)
        {
            players.gameObject.transform.Translate(xVal, 0, -yVal);
            move--;
        }
    }
}



