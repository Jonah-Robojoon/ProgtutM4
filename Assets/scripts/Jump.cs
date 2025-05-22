using UnityEngine;

public class Jump : MonoBehaviour
{
    // Referentie naar Rigidbody
    // Snelheid van bewegen moveSpeed type float
    // Kracht van sprong jumpForce type float

    private Rigidbody rb;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Haal Rigidbody component op van het gameobject
        Debug.Log("Speler klaar!");
    }

    void Update()
    {
        // Get funny little keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // move the box to thingy place
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 up = Vector3.up * jumpForce;
            rb.AddForce(up, ForceMode.Impulse);
        }

        // Simpele Sprong met spatie , gebruik rigidbody

    }
}
