using UnityEngine;
using System.Collections.Generic;

public class PlayerScore : MonoBehaviour
{
    // To Do's:
    // Private Variabele voor score type int
    // Private List voor "Coins" type int

    private int score;
    List<int> coinList = new List<int>();

    void Start()
    {
        // Loop: toon 3x een startbericht met Debug.Log in een loop
        for (int i = 0; i <= 3; i++)
        {
            Debug.Log("Game start");
        }
    }

    void Update()
    {
        // If-statement: check of score >= 50
        // Zo ja geef een bericht met Debug.Log dat je hebt gewonnen

        if (score >= 50)
        {
            Debug.Log("you winnnnn");
        }


        // Test: druk op spatie om een munt toe te voegen
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCoin(Random.Range(0,6));
        }
    }

    // Functie om een munt toe te voegen
    void AddCoin(int coinValue)
    {
        coinList.Add(coinValue);
        score += coinValue;
        Debug.Log($"You got a cain. New score is: {score}");



        // Voeg munt toe aan lijst
        // Verhoog score met de coin value
        // Geef bericht dat je een coin hebt gepakt en toon je nieuwe score
    }
}