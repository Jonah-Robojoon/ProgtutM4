using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Maak een aanpasbare snelheid variabele voor de besturing van de speler
    [SerializeField] private float speed = 5f;

    // Maak een variabele waarmee je een referentie naar het score-script kunt opslaan door deze in de inspector toe te voegen.
    [SerializeField] private ScoreManager scoreManager;

    void Start()
    {

        Debug.Log("Speed changed to " + speed);

        // Controleer of je scoreManager is meegegeven in de inspector
        if (scoreManager == null)
        {
            // Geef een error als dat niet zo is
            Debug.LogError("ScoreManager ontbreekt!");
        }
    }

    void Update()
    {
        // Beweeg speler met pijltjestoetsen en A,D links en rechts
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check of je een gameobject raakt met de naam "Coin"
        if (other.gameObject.name == "Coin")
        {
            // Stuur 10 punten naar de scoreManager
            if (scoreManager != null)
            {
                scoreManager.AddScore(10);
            }

            // Stuur bericht naar de console "Munt gepakt!"
            Debug.Log("Got Coin!");

            // Vernietig de munt
            Destroy(other.gameObject);
        }
    }
}