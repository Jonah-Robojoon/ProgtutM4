using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
