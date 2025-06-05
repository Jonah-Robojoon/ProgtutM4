using UnityEngine;

public class FollowAndReturn : MonoBehaviour
{
    // Inspector variables
    [SerializeField] private Transform target; // Target to follow
    [SerializeField] private float followSpeed = 2f; // Speed when following
    [SerializeField] private float returnSpeed = 2f; // Speed when returning
    [SerializeField] private float stopDistance = 0.1f; // Distance threshold to switch states

    private Vector3 startPosition;
    private bool isReturning = false;

    void Start()
    {
        // Store the start position
        startPosition = transform.position;
    }

    void Update()
    {
        // Call either ReturnToStart or FollowTarget, never both
        if (isReturning)
        {
            ReturnToStart();
        }
        else
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        if (target == null) return;

        // Move towards the target using Lerp
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);

        // Calculate distance to target
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // If close enough to the target, switch to returning
        if (distanceToTarget < stopDistance)
        {
            isReturning = true;
        }
    }

    private void ReturnToStart()
    {
        // Calculate direction to start position
        Vector3 direction = (startPosition - transform.position).normalized;

        // Move towards the start position using Translate
        transform.Translate(direction * returnSpeed * Time.deltaTime, Space.World);

        // Calculate distance to start position
        float distToStart = (startPosition - transform.position).magnitude;

        // If close enough to the start position, stop returning
        if (distToStart < stopDistance)
        {
            isReturning = false;
        }
    }
}