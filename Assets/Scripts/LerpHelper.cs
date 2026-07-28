using UnityEngine;

public class LerpHelper : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * lerpSpeed);
    }
}
