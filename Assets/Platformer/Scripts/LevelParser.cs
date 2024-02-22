using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }
        
        float row = 0.5f;

        // Go through the rows from bottom to top
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            char[] letters = currentLine.ToCharArray();
            for (int column = 0; column < letters.Length; column++)
            {
                var letter = letters[column];
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                if(letter == 'x'){
                    Vector3 newPos = new Vector3(column, row, -2f);
                    Instantiate(rockPrefab, newPos, Quaternion.Euler(0f,0f,180f), environmentRoot); 
                }

                if(letter == 'b'){
                    Vector3 newPos = new Vector3(column, row, -2f);
                    Instantiate(brickPrefab, newPos, Quaternion.Euler(0f,0f,180f), environmentRoot); 
                }

                if(letter == 's'){
                    Vector3 newPos = new Vector3(column, row, -2f);
                    Instantiate(stonePrefab, newPos, Quaternion.Euler(0f,0f,180f), environmentRoot); 
                }

                if (letter == '?')
                {
                    Vector3 newPos = new Vector3(column, row, -2f);
                    GameObject newBlock = Instantiate(questionBoxPrefab, newPos, Quaternion.Euler(0f, 0f, 180f), environmentRoot);
                    newBlock.tag = "Question";
                }

                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
            }
            
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
