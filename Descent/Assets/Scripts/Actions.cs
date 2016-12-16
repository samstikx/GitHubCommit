using UnityEngine;

public abstract class Actions : MonoBehaviour
{
    //make the class an abstract class so that you cannot create an instance of this without it being on a child
    protected Dice theDie = new Dice();
    int addionalDie, playerTurnNo, actionse = 0, move;
    bool actions = false;
    protected PlayerMovement Move;


    public abstract void Damaged(int damage);

    public abstract int Attack();  // send the minion being attacked


    public void SetActions(int moveTemp, int playerNo)
    {
        playerTurnNo = playerNo;
        actions = true;
        move = moveTemp;
    }
    void Update()
    {
        if (actions)
        {
            Move.MovementSelected(move, playerTurnNo);
            actions = false;
        }
    }

    protected void Skill()
    {

    }
    protected void Search()
    {
        // gain a random item from the database search items
    }
    protected void StandUp()
    {
        //player can move

    }
    protected void Revive()
    {
        //revive target hero
    }

    public abstract void Special(); // this means anything using this script will have to have it's own class version of it.
}
