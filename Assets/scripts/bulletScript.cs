using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float speed = 5f;

    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Dummy");
        }
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}