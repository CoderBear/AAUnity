using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    private const string TAG = "AAUNITY/GAME";

    #region Fields
    public GameObject shieldHitAnim;
    public AudioClip shieldHitClip;
    public Transform applePrefab;
    public Transform goldPrefab;
    public Transform comboPrefab1;
    public Transform comboPrefab2;
    public Transform rottenPrefab;
    public TimerCountdown script;
    public AppleCollider goldScript;
    public int[] a_locations;
    List<GameObject> rottenSpawns;
    List<int> spawns;
    MersenneTwister random;
    int comboCounter;
    int goldCounter;
    private bool result = true;
    #endregion

    void Awake()
    {
#if UNITY_ANDROID
        TouchSenseSingleDevice device = new TouchSenseSingleDevice(0);
        //AndyUtils.LogDebug(TAG, "Device is " + device.name);
        //AndyUtils.LogDebug(TAG, "Device type is " + device.type.ToString());
        Debug.Log(TAG + "Device is " + device.name);
        Debug.Log(TAG + "Device type is " + device.type.ToString());
        if (device == null)
        {
            result = false;
            TouchSense.instance.hapticsEnabled = false;
        }
#endif
    }

    // Use this for initialization
    void Start()
    {
        random = new MersenneTwister();
        spawns = new List<int>();
        rottenSpawns = new List<GameObject>();

        comboCounter = 0;
        goldCounter = 0;

        if (shieldHitClip != null && audio == null)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
        }

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

    void PlaySound(AudioClip source)
    {
        if (audio && source)
        {
            audio.PlayOneShot(source);
        }
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
                //Debug.Log("AAUNITY/GAME Frenzy Currently Active");
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
                //Debug.Log("AAUNITY/GAME Super Frenzy Currently Active");
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
                //Debug.Log("AAUNITY/GAME Repel Currently Active");
                Instantiate(applePrefab, spawnPos, Quaternion.identity);
                break;
            default:
                //Debug.Log("AAUNITY/GAME No Gold Effects active or Gold Effect == Double Points");
                if (random.Next(100) > 80)
                {
                    Instantiate(rottenPrefab, spawnPos, Quaternion.identity);
                    rottenSpawns.Add(GameObject.FindWithTag("RottenApple"));
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
        PlaySound(shieldHitClip);
#if UNITY_ANDROID
        if (result)
            TouchSense.instance.playBuiltinEffect(TouchSense.EXPLOSION2);
#endif
        foreach (GameObject spawn in go)
        //foreach (GameObject spawn in rottenSpawns)
        {
            Vector3 position = spawn.transform.position;
            Debug.Log("AAUNITY/GAME Animation " + shieldHitAnim.name + " play at " + position.ToString());
            Instantiate(shieldHitAnim, position, Quaternion.identity);
            DestroyImmediate(spawn);
        }
#if UNITY_ANDROID
        if (result)
            TouchSense.instance.stopPlayingBuiltinEffect();
#endif
        rottenSpawns.Clear();
    }

    public void removeFromList(GameObject go)
    {
        AndyUtils.LogDebug(TAG, "RottenSpawns count before is " + rottenSpawns.Count);
        for (int i = 0; i < rottenSpawns.Count; i++)
        {
            if (rottenSpawns[i].gameObject == null)
                rottenSpawns.RemoveAt(i);
        }
        //rottenSpawns.Remove(go);
        AndyUtils.LogDebug(TAG, "RottenSpawns count after is " + rottenSpawns.Count);
}
    #endregion
}