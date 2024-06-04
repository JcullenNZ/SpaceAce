using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;

public class InputNameController : MonoBehaviour
{

    EventSystem eventSystem;
    public TMP_Text[] playerNameTMP; //3 by default
    char[] letters = new char[26]; //Array of letters (ALPHABET)
    public int currentLetterIndex = 0; // Which alphabet letter is currently selected
    public int[] currentInputIndexes = { 0, 0, 0 }; // Default indexes
    public int currentInputIndex = 0; // Which input is currently selected

    private PlayerControls controls;

    public Button goButton;
    //private Vector2 direction;

    void Awake()
    {
        eventSystem = EventSystem.current;
        controls = new PlayerControls();
        controls.NameEntry.Up.performed += ctx => DecrementLetter();
        controls.NameEntry.Down.performed += ctx => IncrementLetter();
        //controls.NameEntry.Move.performed += ctx => ChooseLetter(ctx.ReadValue<Vector2>());
        controls.NameEntry.Submit.performed += ctx => Submit();
        Debug.Log("Current Input Index from awake: " + currentInputIndex);


    }

    void Start()
    {
        string alphabet = "";
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i] = (char)('A' + i);
            alphabet += letters[i].ToString();
        }
        Debug.Log(alphabet);
        UpdateLetterTexts();
    }

    void OnEnable()
    {
        controls.NameEntry.Enable();
    }

    void OnDisable()
    {
        controls.NameEntry.Disable();
    }

    void UpdateLetterTexts()
    {
        for (int i = 0; i < playerNameTMP.Length; i++)
        {
            playerNameTMP[i].text = letters[currentInputIndexes[i]].ToString(); //Set the text of the input to the current letter
        }
        Debug.Log("Current Input Index from UpdateLetterTexts: " + currentInputIndex);
    }

    void NextInput()
    {
        currentInputIndex = (currentInputIndex + 1) % playerNameTMP.Length;
        if (currentInputIndex != 0)
        {
            eventSystem.SetSelectedGameObject(playerNameTMP[currentInputIndex].gameObject);
        }
        else
        {
            eventSystem.SetSelectedGameObject(goButton.gameObject);
        }
        Debug.Log("Current Input Index: " + currentInputIndex);

    }

    /*void PreviousInput()
    {
        currentInputIndex = (currentInputIndex - 1 + playerNameTMP.Length) % playerNameTMP.Length;

        Debug.Log("Current Input Index: " + currentInputIndex);
    }*/

    void IncrementLetter()
    {
        currentInputIndexes[currentInputIndex] = (currentInputIndexes[currentInputIndex] + 1) % letters.Length;
        UpdateLetterTexts();
    }

    void DecrementLetter()
    {
        currentInputIndexes[currentInputIndex] = (currentInputIndexes[currentInputIndex] - 1 + letters.Length) % letters.Length;
        UpdateLetterTexts();
    }


    void Submit()
    {
        string PlayerName = "";
        for (int i = 0; i < playerNameTMP.Length; i++)
        {
            PlayerName += playerNameTMP[i].text;
        }
        NextInput();
        Debug.Log("Submit Player Name: " + PlayerName);
        PlayerPrefs.SetString("PlayerName", PlayerName); // ADD THIS TO THE SCORE OBJECT!
    }
}
