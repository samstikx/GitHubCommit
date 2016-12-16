using System;
using UnityEngine;


public class Hero : Actions
{
    //general stats variable if we can do inheritance + taken damage or fatigue functions

    int health, maxHealth, movement, fatigue = 0, maxFatigue, might, knowledge, willpower, awareness; //standard hero attritbutes
    int playerNumber;
    bool check = false;
    public Game game;
    public LoadHero load;
    public string heroName, heroClass, heroSub;


    public int GetHealth()
    {
        return health;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public int GetMovement()
    {
        return movement;
    }
    public int GetFatigue()
    {
        return fatigue;
    }
    public int GetMaxFatigue()
    {
        return maxFatigue;
    }
    public string GetName()
    {
        return heroName;  //heroName;
    }

    enum CharacterState
    {
        RefreshState,
        Actions,
        notTurn
    }
    void Start()
    {
        switch (this.gameObject.name)
        {
            case "Player1":
                //read ID 1 from the database - check player.
                playerNumber = 0;
                Debug.Log("Hero 1 found");
                break;
            case "Player2":
                playerNumber = 1;
                Debug.Log("Hero 2 found");
                break;
            case "Player3":
                playerNumber = 2;
                Debug.Log("Hero 3 found");
                break;
            case "Player4":
                playerNumber = 3;
                Debug.Log("Hero 4 found");
                break;
            default:
                Debug.Log("Cannot read the player, no Hero Selected Arsehat");
                break;
        }
        SetupHeros();
        health = maxHealth;
        Debug.Log(heroName);
        Move = GetComponent<PlayerMovement>();
    }

    void LateUpdate()
    {
        if (game != null && check == false)
        {
            //change state
            Debug.Log("Setup is complete");
            game.SetupComplete();
            check = true;
        }
    }

    void SetupHeros()
    {
        heroName = load.GetHeroName(playerNumber);
        heroClass = load.GetHeroClass(playerNumber);
        heroSub = load.GetHeroSubClass(playerNumber);
        maxHealth = load.GetMaxHealth(playerNumber);
        movement = load.GetMovement(playerNumber);
        maxFatigue = load.GetMaxFatigue(playerNumber);
        might = load.GetMight(playerNumber);
        knowledge = load.GetKnowledge(playerNumber);
        willpower = load.GetWillpower(playerNumber);
        awareness = load.GetAwareness(playerNumber);
    }

    public override void Special()
    {
        // insert special abilities here.
    }

    public void Rest()
    {
        fatigue = 0;
        Debug.Log("Rested player");
    }
    public void Fatigued()                                     //taken fatigue point
    {
        fatigue++;
    }
    public override void Damaged(int damage)                                     //taken damage point
    {
        health -= damage;
    }

    public override int Attack()
    {
        bool didHit, surge, extra;                          // , ranged;
        int range, damage = 0, die = 0, defence = 0, temp = 0;
        Minion bro;

        bro = GameObject.FindGameObjectWithTag("Goblin").GetComponentInChildren<Minion>();

        // send 0 for no additional dice, 1 yellow, 2 red
        die = this.additional();
        didHit = theDie.GetHit(die);
        temp = bro.GetDefence();

        if (didHit == true)
        {
            //do the rest
            range = theDie.GetRange();
            surge = theDie.GetSurge();
            extra = theDie.ExtraSurge();
            damage = theDie.GetDamage();
            //get defence die
            Debug.Log("Available Range: " + range + " Damage: " + damage + " Surge: " + surge + " & " + extra);
            //implement some base surge features
            if (surge || extra)
            {
                damage++;
            }
            if (surge && extra)
            {
                damage += damage;
            }

            defence = theDie.RollDefenceDie(temp);
            damage -= defence;
            if (damage < 0)
            {
                damage = 0;
            }
            bro.Damaged(damage);
            if (damage <= 0)
            {
                Debug.Log("DAMAGE blocked! " + damage);
            }
        }
        return damage;
    }

    int additional()
    {
        //yellow = 1, red = 2, nothing = 0
        return 1;           //all subclasses seem to have yellow
    }
}
