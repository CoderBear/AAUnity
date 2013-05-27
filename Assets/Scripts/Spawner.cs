using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    #region Fields
    public GameObject shieldHitAnim;
    public Transform applePrefab;
    public Transform goldPrefab;
    public Transform comboPrefab1;
    public Transform comboPrefab2;
    public Transform rottenPrefab;
    public TimerCountdown script;
    public AppleCollider goldScript;
    public int[] a_locations;
    List<int> spawns;
    MersenneTwister random;
    int comboCounter;
    int goldCounter;
    #endregion

    // Use this for initialization
    void Start()
    {
        random = new MersenneTwister();
        spawns = new List<int>();

        comboCounter = 0;
        goldCounter = 0;

        refillSpawns();

        InvokeRepeating("SpawnNormalApple", 0.01f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PauseGame()
    {
        CancelInvoke("SpawnNormalApple");
    }

    public void ResumeGame()
    {
        spawns.Clear();
        refillSpawns();
        InvokeRepeating("SpawnNormalApple", 0.01f, 0.2f);
    }

    #region Spawn Functions
    void SpawnNormalApple()
    {
        //add to gold and combo counters
        comboCounter++;
        goldCounter++;

        Vector3 spawnPos = transform.position + new Vector3((float)spawns[0], 0, 0);
        spawns.RemoveAt(0);

        switch (goldScript.CURRENT_EFFECT)
        {
            case AppleCollider.GOLD_EFFECTS.FRENZY:
                //			Debug.Log ("AAUNITY/GAME Frenzy Currently Active");
                if (random.Next(100) < 50)
                {
                    Instantiate(comboPrefab1, spawnPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(comboPrefab2, spawnPos, Quaternion.identity);
                }
                break;
            case AppleCollider.GOLD_EFFECTS.SUPERFRENZY:
                //			Debug.Log ("AAUNITY/GAME Super Frenzy Currently Active");
                if (random.Next(100) < 50)
                {
                    Instantiate(comboPrefab1, spawnPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(comboPrefab2, spawnPos, Quaternion.identity);
                }
                break;
            case AppleCollider.GOLD_EFFECTS.REPEL:
                //			Debug.Log ("AAUNITY/GAME Repel Currently Active");
                Instantiate(applePrefab, spawnPos, Quaternion.identity);
                break;
            default:
                //			Debug.Log ("AAUNITY/GAME No Gold Effects active or Gold Effect == Double Points");
                if (random.Next(100) > 80)
                {
                    Instantiate(rottenPrefab, spawnPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(applePrefab, spawnPos, Quaternion.identity);
                }
                break;
        }

        if (spawns.Count == 0)
            refillSpawns();

        if ((comboCounter == 5) && (goldCounter != 50))
        {
            comboCounter = 0;
            SpawnComboApple();
        }
        else if (goldCounter == 50)
        {
            comboCounter = 0;
            SpawnComboApple();
            goldCounter = 0;
            SpawnGoldApple();
        }
    }

    void SpawnGoldApple()
    {
        //		Debug.Log("Gold Apple Spawned at x = " + spawns[0]);
        Vector3 spawnPos = transform.position + new Vector3((float)spawns[0], 0, 0);
        Instantiate(goldPrefab, spawnPos, Quaternion.identity);

        if (spawns.Count == 0)
            refillSpawns();
    }

    void SpawnComboApple()
    {
        if (spawns.Count == 1)
        {
            spawns.Clear();
            refillSpawns();
        }

        switch (goldScript.CURRENT_EFFECT)
        {
            case AppleCollider.GOLD_EFFECTS.SUPERFRENZY:
            case AppleCollider.GOLD_EFFECTS.FRENZY:
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Vector3 spawnPos = transform.position + new Vector3((float)spawns[0], 0, 0);

                        if (random.Next(100) < 50)
                        {
                            Instantiate(comboPrefab1, spawnPos, Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(comboPrefab2, spawnPos, Quaternion.identity);
                        }
                    }
                    spawns.RemoveAt(0);
                    break;
                }
            default:
                for (int i = 0; i < 2; i++)
                {
                    Vector3 spawnPos = transform.position + new Vector3((float)spawns[0], 0, 0);

                    if (random.Next(100) < 50)
                    {
                        Instantiate(comboPrefab1, spawnPos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(comboPrefab2, spawnPos, Quaternion.identity);
                    }
                    spawns.RemoveAt(0);
                }
                break;
        }

        //		Debug.Log("Combo Apple Spawned at x = " + spawns[0]);

        if (spawns.Count == 0)
            refillSpawns();
    }

    // shuffle spawns before assignment;
    private void shuffle()
    {
        for (int i = spawns.Count; i > 1; i--)
        {
            int index = random.Next(1, spawns.Count);
            int temp = spawns[index];
            spawns[index] = spawns[i - 1];
            spawns[i - 1] = temp;
        }
    }

    // refill the spawn list and randomize it
    private void refillSpawns()
    {
        //		Debug.Log("Refilling & shuffling Spawns");
        for (int i = 0; i < a_locations.Length; i++)
        {
            spawns.Add(a_locations[i]);
        }

        shuffle();
        shuffle();
        shuffle();
    }

    public void removeRotten()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("RottenApple");
        foreach (GameObject spawn in go)
        {
            Vector3 position = spawn.transform.position;
            Instantiate(shieldHitAnim, position, Quaternion.identity);
            Destroy(spawn);
        }
    }
    #endregion

    #region Gold FirstCatch Function
    public void firstCatchGold(int index)
    {
    }
    #endregion
}