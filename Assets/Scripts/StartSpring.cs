using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StartSpring : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        _rigidbody.AddForce(Vector3.up * force);        
    }
}
