using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Test : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private int spring;
    [SerializeField] private float time = 2f;
    [SerializeField] private float waitTime = 1f;
    private Rigidbody rb;
    private SpringJoint joint;
    private float _time;
    private Coroutine startSpring;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        joint = GetComponent<SpringJoint>();
        _time = time;
    }

    private void Start()
    {
        startSpring =  StartCoroutine(StartSpring());
    }

    public void StartButton()
    {
        if (startSpring != null) return;
        startSpring = StartCoroutine(StartSpring());
    }

    private IEnumerator StartSpring()
    {
        joint.spring = 0;
        while (_time > 0)
        {
            yield return new WaitForSeconds(0f);
            rb.AddForce(Vector3.down * force);
            _time -= Time.deltaTime;
        }

        yield return new WaitForSeconds(waitTime);
        joint.spring = spring;
        _time = time;
        startSpring = null;
    }

}
