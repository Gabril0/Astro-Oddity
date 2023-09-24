using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] bool playerCanEvolute = false;
    private int[] randomIndex = new int[5];
    Hashtable evolutionTable = new Hashtable();
    private bool isChoosing = false;
    GameObject[] choices = new GameObject[3];
    private PlayerMovement player;

    //Buttons and Canvas
    private GameObject buttonSelector;
    private Image choiceLeft, choiceRight, choiceMiddle;
    private int buttonChoosed = -1; //this is used to know what option was clicked, -1 means that none until now, 0 is left, 1 middle, 2 right

    //DeathCanvas
    private GameObject deathCanvas;

    //Pause Menu
    private GameObject pauseMenu;

    //Evolutions
    [SerializeField] GameObject bigbang, cosmicFlow, cosmicHeal, cosmicStrength, galacticCannon, overWeight, storedEnergy, suddenDeath; //manually assign these

    public bool PlayerCanEvolute { get => playerCanEvolute; set => playerCanEvolute = value; }

    void Start()
    {
        Time.timeScale = 1.0f;

        choiceLeft = GameObject.Find("ButtonLeft").GetComponent<Image>();
        choiceMiddle = GameObject.Find("ButtonMiddle").GetComponent<Image>();
        choiceRight = GameObject.Find("ButtonRight").GetComponent<Image>();

        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        deathCanvas = GameObject.Find("DeathCanvas");
        deathCanvas.SetActive(false);

        buttonSelector = GameObject.Find("ButtonSelector");
        buttonSelector.SetActive(false);

        pauseMenu = GameObject.Find("Pause");
        pauseMenu.SetActive(false);

        evolutionTable.Add(1,cosmicFlow);
        evolutionTable.Add(2,bigbang);
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
        //Debug.Log("Choosed button:" + buttonChoosed);
        if (PlayerCanEvolute)
        {
            Time.timeScale = 0f;
            if (!isChoosing)
            {
                isChoosing=true;
                displayChoices();
            }
            
        }
        if (!player.IsAlive) {
            deathCanvas.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene("SampleScene");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);

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

        buttonSelector.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            choices[i] = (GameObject)evolutionTable[randomIndex[i]];
            choices[i] = Instantiate((GameObject)evolutionTable[randomIndex[i]],new Vector3(10000,0,0),transform.rotation);
        }
        choiceLeft.sprite = choices[0].GetComponentInChildren<SpriteRenderer>().sprite;
        choiceMiddle.sprite = choices[1].GetComponentInChildren<SpriteRenderer>().sprite;
        choiceRight.sprite = choices[2].GetComponentInChildren<SpriteRenderer>().sprite;

        choiceLeft.color = GetColorForChoice(0);
        choiceMiddle.color = GetColorForChoice(1);
        choiceRight.color = GetColorForChoice(2);
    }

    public void confirmChoice()
    {
        if (buttonChoosed > -1)
        {
            buttonSelector.SetActive(false);
            isChoosing = false;
            PlayerCanEvolute = false;


            GameObject chosenEvolution = choices[buttonChoosed];

            chosenEvolution.GetComponent<Evolution>().makeChanges();


            for (int i = 0; i < 3; i++)
            {
                Destroy(choices[i]);
            }
            randomizeEvolutions();
            buttonChoosed = -1;
            Time.timeScale = 1f;
        }
    }

    public void activateLeft() {buttonChoosed = 0;confirmChoice(); }
    public void activateMiddle() {buttonChoosed = 1; confirmChoice(); }
    public void activateRight() { buttonChoosed = 2; confirmChoice(); }

    public void buttonGoMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void buttonContinuePause() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
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
