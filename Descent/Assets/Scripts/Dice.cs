using UnityEngine;
using System.Collections;

public class Dice
{
    int range, damage;
    bool miss = false, surge = false, extra = false;

    public bool GetHit(int extraDie)
    {
        RollBlueDice();
        if (extraDie == 1)
        {
            RollYellowDie();
        }
        else if (extraDie == 2)
        {
            RollRedDie();
        }
        return !miss;
    }
    public bool GetSurge()
    {
        return surge;
    }
    public bool ExtraSurge()
    {
        return extra;
    }
    public int GetRange()
    {
        return range;
    }
    public int GetDamage()
    {
        return damage;
    }

    void RollRedDie()
    {
        int diceRoll = RollDice();

        switch (diceRoll)
        {
            case 1:
                damage++; damage++;
                break;
            case 2:
                damage++;
                break;
            case 3:
                damage++; damage++; damage++;
                break;
            case 4:
                damage++; damage++; damage++;
                if (surge == false)
                { surge = true; }
                else { extra = true; }
                break;
            default:
                damage++; damage++;
                break;
        }
    }
    void RollYellowDie()
    {
        int diceRoll = RollDice();

        switch (diceRoll)
        {
            case 1:
                range++;
                if (surge == false)
                { surge = true; }
                else { extra = true; }
                break;
            case 2:
                range++; damage++;
                break;
            case 3:
                range++; range++; damage++;
                break;
            case 4:
                damage++;
                if (surge == false)
                { surge = true; }
                else { extra = true; }
                break;
            case 5:
                damage++; damage++;
                break;
            case 6:
                damage++; damage++;
                if (surge == false)
                { surge = true; }
                else { extra = true; }
                break;
            default:
                range++; damage++;
                break;
        }
    }
    void RollBlueDice()
    {
        int diceRoll = RollDice();

        switch (diceRoll)
        {
            case 1:
                miss = true;
                break;
            case 2:
                range = 2; damage = 2; surge = true; miss = false;
                break;
            case 3:
                range = 3; damage = 2; surge = false; miss = false;
                break;
            case 4:
                range = 4; damage = 2; surge = false; miss = false;
                break;
            case 5:
                range = 5; damage = 1; surge = false; miss = false;
                break;
            case 6:
                range = 6; damage = 1; surge = true; miss = false;
                break;
            default:
                range = 3; damage = 2; surge = false; miss = false;
                break;
        }
    }

    public int RollDefenceDie(int dieCase)
    {
        int defenceVal, lowLimit, highLimit, common;

        if (dieCase == 0)
        {
            lowLimit = 1;
            highLimit = 4;
            common = 2;
        }
        else if (dieCase == 1)
        {
            lowLimit = 0;
            highLimit = 3;
            common = 0;
        }
        else                    //so default
        {
            lowLimit = 0;
            highLimit = 2;
            common = 1;
        }

        defenceVal = RollDice();

        switch (defenceVal)
        {
            case 1:
                defenceVal = lowLimit;
                break;
            case 2:
                defenceVal = lowLimit + 1;
                break;
            case 3:
                defenceVal = highLimit - 1;
                break;
            case 4:
                defenceVal = highLimit;
                break;
            default:
                defenceVal = common;
                break;
        }
        return defenceVal;
    }

    int RollDice()
    {
        return Random.Range(1, 6);
    }
}
