using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInfo : MonoBehaviour
{
    [SerializeField, TextArea] private string gameWold;

    public string GetPrompt()
    {
        return $"Game World: {gameWold}\n";
    }
}
