using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class gameManager : MonoBehaviour {

    public GameObject[] players;
    public int[] buttonValue;
    public string[] alphabet;
    public int[,] brailleCharacters;
    int randomNumber = 0;

    double myScore = 0;
    int comboCounter = 0;
    int showCombo = 1;
    double currentHealth = 3, maxHealth = 3;


    private Text activeBrailleText;
    private Text scoreText;
    private Text comboText;
    private Text healthText;


    bool same = false; // Used to check if the arrays are the same.
    




    // Use this for initialization
    void Start () {

        activeBrailleText = GameObject.Find("activeBrailleCharacter").GetComponent<Text>();
        activeBrailleText.text = "A";

        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        scoreText.text = "Score: " + myScore;

        comboText = GameObject.Find("comboText").GetComponent<Text>();
        comboText.text = "Multiplier: " + showCombo + "x";

        healthText = GameObject.Find("healthText").GetComponent<Text>();
        healthText.text = "Health: " + currentHealth;



        //Player Array
        buttonValue = new int[6] { 0, 0, 0, 0, 0, 0 };

        //Array
        alphabet = new string[6] { "A", "B", "C", "D", "E", "F" };

        //Database Array
        brailleCharacters = new int[6,6] {
            { 1, 0, 0, 0, 0, 0 }, // Bokstaven A
            { 1, 0, 1, 0, 0, 0 }, // Bokstaven B
            { 1, 1, 0, 0, 0, 0 }, // Bokstaven C
            { 1, 1, 0, 1, 0, 0 }, // Bokstaven D
            { 1, 0, 0, 1, 0, 0 }, // Bokstaven E
            { 1, 1, 1, 0, 0, 0 } // Bokstaven F
        };
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log("Number: " + randomNumber);

    }

    void Awake()
    {
    }

    public void CompareArray()
    {

        int rightRow = randomNumber;
        for (int i = 0; i < 6; i++)
        {
            if (brailleCharacters[rightRow,i] != buttonValue[i])
            {
                same = false;
                break;
            }
            same = true;
        }

        if (same)
        {

            Debug.Log("DEM ÄR LIKA FÖR HELVETE!!");
            resetBoxValue();
            randomNumber = Random.Range(0, 6);
            activeBrailleText.text = alphabet[randomNumber];

            addScore();
            scoreText.text = "Score: " + myScore;

            comboCounter++;

            currentHealth += 0.5;
            if (currentHealth > maxHealth)
            {
                currentHealth = 3;
            }


        }
        else
        {
            Debug.Log("DEM ÄR INTE LIKA!!");
            resetBoxValue();
            comboCounter = 0;
            showCombo = 1;
            currentHealth--;
            
        }

        if (currentHealth <= 0)
        {
            Debug.Log("YOU ARE DIED!");
        }

        comboText.text = "Multiplier: " + showCombo + "x";
        healthText.text = "Health: " + currentHealth;


    }

    public void removeAnswer()
    {
        resetBoxValue();
    }

    void resetBoxValue()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("activeBoxTag");
        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
        buttonValue[0] = 0;
        buttonValue[1] = 0;
        buttonValue[2] = 0;
        buttonValue[3] = 0;
        buttonValue[4] = 0;
        buttonValue[5] = 0;
    }

    void addScore()
    {
        if (comboCounter <= 3)
        {
            myScore += 1.0;
            showCombo = 1;
        }
        else if (comboCounter > 3 && comboCounter <= 6)
        {
            myScore += 2.0;
            showCombo = 2;
        }

        else if (comboCounter > 6)
        {
            myScore += 3.0;
            showCombo = 3;
        }
    }


}
