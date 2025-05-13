using UnityEngine;

public class CarCamera : MonoBehaviour
{
    [SerializeField] private Transform target; // The Car
    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -10f); // Distance Between Camera And Car
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float lookSpeed = 10f;
    [SerializeField] private float lookDownAngle = 10f; // Down Angle of Camera Looking Towards The Car
    void LateUpdate()
    {
        if (!target) return;

        // Camera Position Above Car
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Calculating the place that camera should look at 
        Vector3 lookTarget = target.position + Vector3.up * Mathf.Tan(lookDownAngle * Mathf.Deg2Rad) * offset.magnitude;
        Quaternion desiredRotation = Quaternion.LookRotation(lookTarget - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, lookSpeed * Time.deltaTime);
    }
}