using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compactrandomizer : MonoBehaviour
{

    public GameObject[] parts;
    public GameObject[] locations;

    public List<int> usedValues = new List<int>();


    // Use this for initialization
    void Start()
    {

        if (locations.Length < parts.Length)
        {
            print("error");
        }

        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].transform.position = locations[UniqueRandomInt(0, locations.Length)].transform.position;
        }



    }


    public int UniqueRandomInt(int min, int max)
    {
        int val = Random.Range(min, max);
        while (usedValues.Contains(val))
        {

            val = Random.Range(min, max);
            if (usedValues.Contains(val) == false) { break; }
        }
        usedValues.Add(val);

        return val;
    }
}

