using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Mono.Data.SqliteClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

public class setup : MonoBehaviour
{
    //setup ask for no of players, then create the amount of hero's necessary 
    //array of hero's
    //have a set of states for settting up, inc menu states. class, character and sub class select screen
    //could have add players until finished. with note to allow for the OVERLORD

    bool option, champ;
    public Button[] heroBut = new Button[4];
    bool[] available = new bool[4];
    // public Hero Players;
    string filePath;
    int count = 0;
    public Text output;

    public void OnOption2Select()
    {
        option = false;
    }
    public void OnOption1Select()
    {
        option = true;
    }
    public void Champ1()
    {
        champ = true;
    }
    public void Champ2()
    {
        champ = false;
    }

    void DeleteTable()
    {
        using (IDbConnection connection = new SqliteConnection(filePath))
        {
            connection.Open();
            string commandText = "DROP TABLE IF EXISTS Heros ";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.ExecuteNonQuery();
            Debug.Log("Deleted Table named Heros in Minions");
        }
    }
    void CreateTable()
    {
        using (IDbConnection connection = new SqliteConnection(filePath))
        {
            connection.Open();
            string commandText = "CREATE TABLE Heros (ID INT UNIQUE PRIMARY KEY, Name TEXT, Class TEXT, SubClass Text)";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.ExecuteNonQuery();
            Debug.Log("Created a new table named Heros in Minions");
        }
    }

    void Start()
    {
        for (int i = 0; i <= 3; i++)
        {
            available[i] = false;
        }

        filePath = "URI=file:" + Application.dataPath + "Minions.s3db";
        DeleteTable();
        CreateTable();
    }


    IEnumerator FinishedSetup()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel("MainMenu");
    }

    public void ConfirmClick()
    {
        if (count == 4)
        {
            for (int i = 0; i <= 3; i++)
            {
                heroBut[i].interactable = false;
            }
            //change scene
            FinishedSetup();
            Debug.Log("Finsihed setup");
            output.text = " Finished Setup ";
            Application.LoadLevel("MainMenu");
        }
        else
        {
            for (int i = 0; i <= 3; i++)
            {
                if (available[i] == false)
                {
                    heroBut[i].interactable = true;
                }
            }
        }
    }

    public void SelectedHero()
    {
        for (int i = 0; i <= 3; i++)
        {
            if (available[i] == false)
            {
                heroBut[i].interactable = false;
            }
        }
    }

    void InsertIntoMinionTable(string info)
    {
        using (IDbConnection connection = new SqliteConnection(filePath))
        {
            connection.Open();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = info;
            command.ExecuteNonQuery();
            Debug.Log("Inserted a new Hero");
            count++;
        }
    }

    public void WarriorSelect()
    {
        string sub, info;
        Debug.Log("Warrior Selected");
        available[0] = true;
        //Debug.Log("removed warrior");
        if (option == true)
        {
            sub = " Beserker";
        }
        else
        {
            sub = "Knight";
        }

        if (champ == true)
        {
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + "', 'Grisban the thirsty', 'Warrior', '" + sub + "');";
            Debug.Log("griban inserted");
        }
        else
        {
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + "', 'Syndrael', 'Warrior', '" + sub + "');";
            Debug.Log("Syndrael added");
        }
        InsertIntoMinionTable(info);
    }
    public void HealerSelect()
    {
        string sub, info;
        Debug.Log("Healer Selected");
        available[1] = true;
        // Debug.Log("removed Healer");
        if (option == true)
        {
            sub = "SpiritSeaker";
        }
        else
        {
            sub = "Disciple";
        }
        if (champ == true)
        {
            //      Players.AvricSelect(option);        //output to database instead
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + "', 'Avric Albright', 'Healer ', '" + sub + "');";
            Debug.Log("Avric Added");
        }
        else
        {
            //Players.AsharianSelect(option);     //output to database instead
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + "', 'Asharian', 'Healer ', '" + sub + "');";
            Debug.Log("Asharian Added");
        }
        InsertIntoMinionTable(info);
    }
    public void MageSelect()
    {
        string sub, info;
        Debug.Log("Mage Selected");
        available[2] = true;
        // Debug.Log("removed Mage");
        if (option == true)
        {
            sub = "Runemaster";
        }
        else
        {
            sub = "Necromancer";
        }

        if (champ == true)
        {
            //Players.LeoricSelect(option);        //output to database instead
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + "','Leoric of the Book', 'Mage','" + sub + "');";
            Debug.Log("Leoric Added");
        }
        else
        {
            // Players.WidowSelect(option);         //output to database instead
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + "','Widow Tahra','Mage','" + sub + "');";
            Debug.Log("Widow Added");
        }
        InsertIntoMinionTable(info);
    }
    public void ScoutSelect()
    {
        string sub, info;
        Debug.Log("Scout Selected");
        // Debug.Log("removed Scout");
        available[3] = true;
        if (option == true)
        {
            sub = "Thief";
        }
        else
        {
            sub = "Wildlander";
        }
        if (champ == true)
        {
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + "','Tomble Burrowelll','Scout','" + sub + "');";
            Debug.Log("Tomble Added");
        }
        else
        {
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + "','Jain Fairwood','Scout','" + sub + "');";
            Debug.Log("Jain Added");
        }
        InsertIntoMinionTable(info);
    }
}
