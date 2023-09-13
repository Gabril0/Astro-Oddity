using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool playerCanEvolute = false;
    private int[] randomIndex = new int[5];
    Hashtable evolutionTable = new Hashtable();

    private BigBang bigbang;
    void Start()
    {
        bigbang = GameObject.Find("BigBang").GetComponent<BigBang>();
        evolutionTable.Add(1,bigbang);//FIX THE REST AND CREATE THE PREFABS
        


        evolutionTable.Add(2,new CosmicFlow());
        evolutionTable.Add(3, new CosmicHeal());
        evolutionTable.Add(4, new CosmicStrength());
        evolutionTable.Add(5, new GalacticCannon());
        evolutionTable.Add(6, new Overweight());
        evolutionTable.Add(7, new StoredEnergy());
        evolutionTable.Add(8, new SuddenDeath());
        //randomizeEvolutions();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCanEvolute)
        {
            Time.timeScale = 0f;
        }
        else {
            Time.timeScale = 1f;
        }
    }

    private void randomizeEvolutions()
    {
        int maxIndex = evolutionTable.Count;
        HashSet<int> uniqueIndices = new HashSet<int>();

        //this is a code that, despite using a while loop inside an for loop, optimizes by keeping the different numbers from rolling again
        for (int i = 1; i <= 3; i++)
        {
            int randomValue;
            do
            {
                randomValue = Random.Range(1, maxIndex + 1);
            } while (uniqueIndices.Contains(randomValue));

            randomIndex[i] = randomValue;
            uniqueIndices.Add(randomValue);
        }
    }
}
