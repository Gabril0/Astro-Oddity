using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool playerCanEvolute = false;
    private int[] randomIndex = new int[5];
    Hashtable evolutionTable = new Hashtable();
    private bool isChoosing = false;

    [SerializeField] GameObject bigbang, cosmicFlow, cosmicHeal, cosmicStrength, galacticCannon, overWeight, storedEnergy, suddenDeath; //manually assign these
    void Start()
    {
        evolutionTable.Add(1,bigbang);
        evolutionTable.Add(2,cosmicFlow);
        evolutionTable.Add(3, cosmicHeal);
        evolutionTable.Add(4, cosmicStrength);
        evolutionTable.Add(5, galacticCannon);
        evolutionTable.Add(6, overWeight);
        evolutionTable.Add(7, storedEnergy);
        evolutionTable.Add(8, suddenDeath);
        randomizeEvolutions();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCanEvolute)
        {
            Time.timeScale = 0;
            if (!isChoosing)
            {
                isChoosing=true;
                displayChoices();
            }
        }
        else {
            Time.timeScale = 1f;
        }
    }

    private void randomizeEvolutions()
    {
        int maxIndex = evolutionTable.Count;
        HashSet<int> uniqueIndices = new HashSet<int>();
        //this is a code that, despite using a while loop inside an for loop, optimizes by keeping 
        for (int i = 0; i < 3; i++)
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

    private void displayChoices()
    {
        GameObject[] choices = new GameObject[3];
        Color[] colors = new Color[3];

        for (int i = 0; i < 3; i++)
        {
            choices[i] = Instantiate((GameObject)evolutionTable[randomIndex[i]], transform.position, transform.rotation);
            choices[i].transform.Translate(new Vector3(-6 + i * 6, 0, -10));

            SpriteRenderer colorRenderer = choices[i].GetComponentInChildren<SpriteRenderer>();
            colors[i] = GetColorForChoice(i); // Define this function to return the appropriate color
            colorRenderer.color = colors[i];
        }
    }

    private Color GetColorForChoice(int choiceIndex)
    {
        switch (choiceIndex)
        {
            case 0:
                return new Color(255f / 255f, 61f / 255f, 101f / 255f);
            case 1:
                return new Color(15f / 255f, 200f / 255f, 255f / 255f);
            case 2:
                return new Color(255f / 255f, 240f / 255f, 41f / 255f);
            default:
                return Color.white; // Default color or handle other cases as needed
        }
    }

}
