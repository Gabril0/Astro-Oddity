using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] bool playerCanEvolute = false;
    private int[] randomIndex = new int[5];
    Hashtable evolutionTable = new Hashtable();
    private bool isChoosing = false;

    //Buttons and Canvas
    private GameObject buttonSelector;
    private Image choiceLeft, choiceRight, choiceMiddle;
    private int buttonChoosed = -1; //this is used to know what option was clicked, -1 means that none until now, 0 is left, 1 middle, 2 right


    //Evolutions
    [SerializeField] GameObject bigbang, cosmicFlow, cosmicHeal, cosmicStrength, galacticCannon, overWeight, storedEnergy, suddenDeath; //manually assign these
    void Start()
    {
        choiceLeft = GameObject.Find("ButtonLeft").GetComponent<Image>();
        choiceMiddle = GameObject.Find("ButtonMiddle").GetComponent<Image>();
        choiceRight = GameObject.Find("ButtonRight").GetComponent<Image>();

        buttonSelector = GameObject.Find("ButtonSelector");
        buttonSelector.SetActive(false);

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
        Debug.Log("Choosed button:" + buttonChoosed);
        if (playerCanEvolute)
        {
            Time.timeScale = 0.1f;
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
        buttonSelector.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            // Assuming you already have GameObjects in the evolutionTable, and you don't need to instantiate new ones.
            choices[i] = (GameObject)evolutionTable[randomIndex[i]];
        }
        choiceLeft.sprite = choices[0].GetComponentInChildren<SpriteRenderer>().sprite;
        choiceMiddle.sprite = choices[1].GetComponentInChildren<SpriteRenderer>().sprite;
        choiceRight.sprite = choices[2].GetComponentInChildren<SpriteRenderer>().sprite;

        choiceLeft.color = GetColorForChoice(0);
        choiceMiddle.color = GetColorForChoice(1);
        choiceRight.color = GetColorForChoice(2);

        if (buttonChoosed > -1) {
            buttonSelector.SetActive(false);
            isChoosing = false;
            playerCanEvolute = false;
            buttonChoosed = -1;
        }
        //create the canvas, then get the buttons in this script, and assign the the images to the options, and then get the result of the option
    }

    public void activateLeft() { Debug.Log("enteredLeft"); buttonChoosed = 0;Debug.Log(buttonChoosed); }
    public void activateMiddle() { Debug.Log("enteredMiddle"); buttonChoosed = 1; Debug.Log(buttonChoosed); }
    public void activateRight() { Debug.Log("enteredRight"); buttonChoosed = 2; Debug.Log(buttonChoosed); }

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
