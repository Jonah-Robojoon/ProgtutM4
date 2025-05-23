using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Maak een speed variabele die aanpasbaar is in de Inspector
    [SerializeField] private float moveSpeed = 5f;
    // Maak een variabele voor je prefab
    [SerializeField] private GameObject coinPrefab;

    void Start()
    {
        //Maak een random waarde tussen de -10 en de 10 voor het plaatsen van een munt op de x-as
        float randomX = Random.Range(-10f, 10f);
        //Gebruik de Instantiate methode om de coinPrefab op een random x-positie in de scene te zetten.
        Instantiate(coinPrefab, new Vector3(randomX, 0, 0), Quaternion.identity);


    }

    void Update()
    {
        //Beweeg de speler ging met pijltjestoetsen links en rechts of A en D

        // Get funny little keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // move the box to thingy place
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}