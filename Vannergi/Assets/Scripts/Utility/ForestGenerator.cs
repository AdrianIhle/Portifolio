using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{

    public GameObject[] pos;
    public GameObject[] veggis;

    // Use this for initialization
    void Start()
    {
        pos = new GameObject[36];
        for (int i = 0; i < 36; i++)
        {
            pos[i] = transform.GetChild(i).gameObject;
        }

        GenerateForest(Random.Range(1, 36));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateForest(int nrofVeggies)
    {
        int runs = 0;
        int[] posTaken = new int[36];
        bool placeTaken = false;
        int index = 0;
        while (runs < nrofVeggies)
        {
            index = Random.Range(0, 35);
            for (int i = 0; i < posTaken.Length; i++)
            {
                if (posTaken[i] == index)
                    placeTaken = true;
                else
                    placeTaken = false;
            }

            if (!placeTaken)
                PlaceVeggie(pos[index].transform);
            runs++;
        }
    }

    GameObject PlaceVeggie(Transform t)
    {
        int index = Random.Range(0, 5);
        GameObject n = Instantiate(veggis[index], t);
        return n;
    }
}
