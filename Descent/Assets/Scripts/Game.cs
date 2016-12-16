using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    GameState currentGameState;
    public Text nameText, healthText, fatigueText, movementText, actionText, attackText;
    public Hero[] players = new Hero[4];
    // public Shader icon;
    bool updated = true;
    int actionsLeft = 2, playerTurnNo = 0, moveTemp;
    public Dropdown drop;

    public int GetPlayerTurnNo()
    {
        return playerTurnNo;
    }

    public enum GameState
    {
        preGame,
        playerTurn,
        overlordTurn,
        endgame
    }

    void Start()
    {
        currentGameState = GameState.preGame;
        drop.interactable = false;
        drop.value = 0;
        //set list of icons
        // icon[0] = GetComponentInChildren<Shader>();

    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (currentGameState == GameState.playerTurn && updated == true)
        {
            PlayerTurn();
            updated = false;
        }
        if (currentGameState == GameState.overlordTurn)
        {
            UpdateOverLoadUI();
        }
        actionText.text = "Actions Left :" + actionsLeft;
    }
    public void EndTurn()
    {
        if (currentGameState == GameState.overlordTurn)
        {
            currentGameState = GameState.playerTurn;
        }
        else if (playerTurnNo >= 3)
        {
            currentGameState = GameState.overlordTurn;
            playerTurnNo = 0;
        }
        else
        {
            playerTurnNo++;
        }
        updated = true;
        drop.value = 0;
        actionsLeft = 2;
    }

    void PlayerTurn()
    {
        UpdateUIPlayer();
        drop.interactable = true;
        //refreshCards();
    }

    public void SetupComplete()
    {
        currentGameState = GameState.playerTurn;
    }

    void UpdateOverLoadUI()
    {
        nameText.text = "OverLord turn";
        healthText.text = "N/A";
        movementText.text = "N/A";
        fatigueText.text = "N/A";
    }

    void UpdateUIPlayer()
    {
        int health, maxHealth, movement, fatigue, maxFatigue;
        nameText.text = "Player " + (playerTurnNo + 1) + ": \n" + players[playerTurnNo].GetName();

        health = players[playerTurnNo].GetHealth();
        maxHealth = players[playerTurnNo].GetMaxHealth();
        movement = players[playerTurnNo].GetMovement();
        moveTemp = movement;
        fatigue = players[playerTurnNo].GetFatigue();
        maxFatigue = players[playerTurnNo].GetMaxFatigue();

        healthText.text = health + " / " + maxHealth;
        movementText.text = movement + " / " + movement;
        fatigueText.text = fatigue + " / " + maxFatigue;

        Debug.Log(health + " " + maxHealth);


        Debug.Log("UI updated");
    }

    void AllowActions()
    {
        attackText.text = "";
        int value = drop.value, temp, lastAction = 1;
        if (value == 0)
        {
            value = lastAction;
        }
        switch (value)
        {
            case 1:
                Debug.Log("Atttcking");
                //get the minion being attacked
                temp = players[playerTurnNo].Attack();
                if (temp == 0)
                {
                    attackText.text = "Attack missed";
                }
                else
                    attackText.text = "Resulting Damage dealt: " + temp;
                break;
            case 2:
                players[playerTurnNo].SetActions(moveTemp, playerTurnNo);
                Debug.Log("MOVE PLS YOU ARSE");
                break;
            case 3:
                players[playerTurnNo].Rest();
                break;
            case 4:
                Debug.Log("HAHA YOU DROPPED NOTHING :D");
                break;
            default:
                Debug.Log("oops");
                break;
        }
        if (actionsLeft <= 0)
        {
            drop.interactable = false;
            EndTurn();
        }
        lastAction = value;
    }

    public void Actions()
    {
        actionsLeft--;
        AllowActions();
    }
}
