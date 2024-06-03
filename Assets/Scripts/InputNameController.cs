using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class InputNameController : MonoBehaviour
{

    public TMP_Text[] letterTexts;
    public char[] letters = { 'A', 'C', 'E' }; // Default letters
    public int[] currentIndexes = {0,2,3}; // Default indexes
    public int currentLetterIndex = 0;
    private PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
        controls.NameEntry.ChooseLetter.performed += ctx => ChooseLetter(ctx.ReadValue<Vector2>());
        controls.NameEntry.Submit.performed += ctx => Submit();
    }

    void OnEnable()
    {
        controls.NameEntry.Enable();
    }

    void OnDisable()
    {
        controls.NameEntry.Disable();
    }

    void ChooseLetter(Vector2 direction)
    {
        if (direction.y > 0)
        {
            NextLetter();
        }
        else if (direction.y < 0)
        {   
            PreviousLetter();
        }
    }

    void UpdateLetterTexts()
    {
        for (int i = 0; i < letterTexts.Length; i++)
        {
            letterTexts[i].text = letters[currentIndexes[i]].ToString();
        }
    }

    void NextLetter()
    {
        currentLetterIndex = (currentLetterIndex + 1) % letterTexts.Length;
    }

    void PreviousLetter()
    {
        currentLetterIndex = (currentLetterIndex - 1 + letterTexts.Length) % letterTexts.Length;
    }

    void IncrementLetter()
    {
        currentIndexes[currentLetterIndex] = (currentIndexes[currentLetterIndex] + 1) % letters.Length;
        letters[currentLetterIndex] = (char)('A' + currentIndexes[currentLetterIndex]);
        UpdateLetterTexts();
    }

    void DecrementLetter()
    {
        currentIndexes[currentLetterIndex] = (currentIndexes[currentLetterIndex] - 1 + letters.Length) % letters.Length;
        letters[currentLetterIndex] = (char)('A' + currentIndexes[currentLetterIndex]);
        UpdateLetterTexts();
    }

    void Submit()
    {   
        string PlayerName = new string(letters);
        PlayerPrefs.SetString("PlayerName", PlayerName); // ADD THIS TO THE SCORE OBJECT!
        Debug.Log("Player Name: " + PlayerName);
    }
}
