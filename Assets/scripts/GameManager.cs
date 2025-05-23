using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //Maak een variabele voor je snelheid
    [SerializeField] private int moveSpeed;
    //Maak een variabele voor de overgebleven tijd
    private float timeLeft = 5;
    //Maak een variabele voor je score
    private int score;
    //Zorg voor logische datatypes



    void Update()
    {

        // Beweging
        //laat de speler bewegen via de pijltjes en WASD toetsen

        //Maak in je berekening gebruik van de speed en zorg voor vloeiende beweging ongeacht de framerate.

        // Get funny little keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // move the box to thingy place
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        //Als de tijd voorbij is stuur je een bericht naar de console met daarin "Game Over! Eindscore: " en je behaalde score.
        if (timeLeft <= 0)
        {
            Debug.Log("Game OVER  --  Score: " + score);
            enabled = false; // Schakelt Update uit
            return;           // stopt uitvoer van de rest van de code.
        }

        //Haal de verstreken seconden tussen de frames van de tijd af
        timeLeft -= Time.deltaTime;

        //Laat in de console het aantal resterende seconden zien (afgerond) en je score

        Debug.Log("Tijd: " + Mathf.Round(timeLeft) + " | Score: " + score);
    }
    //zorg dat je een coin kan raken maar er niet tegenaan kan lopen. De speler moet door de coins heen kunnen.
    void OnTriggerEnter(Collider other)
    {

        //Check of je een coin hebt geraakt.
        if (other.gameObject.tag == "Coin")
        {
            //Voeg 10 punten toe aan je score
            score += 10;

            //Stuur een bericht naar de console dat je een munt hebt gepakt en hoeveel punten dit oplevert
            Debug.Log("you collected 10 coins");

            //Vernietig de geraakte coin
            Destroy(other.gameObject);
        }
    }
}