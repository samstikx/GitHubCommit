using UnityEngine;

public class Goblin : Minion
{
    public GameObject miniOne;
    bool spawn = false;

    void Awake()
    {
        master = true;
    }

    // Update is called once per frame

    void SpawnChildren()
    {
        Vector3[] position = new Vector3[5];

        position[1] = new Vector3(-218, -145, -3);
        position[2] = new Vector3(-276, -200, -3);
        position[3] = new Vector3(-276, -258, -3);
        position[4] = new Vector3(-218, -200, -3);
        position[0] = new Vector3(-218, -145, -3);

        for (int i = 1; i <= _noOfMinions - 1; i++)
        {
            Instantiate(miniOne, position[i], this.transform.rotation);                                             //need a way of setting children so0
            Debug.Log("COPIED GOBBOS to : " + position[i]);
        }
        spawn = true;
    }

    void Update()
    {
        if (spawn == false)
        {
            SpawnChildren();
        }
    }
}
