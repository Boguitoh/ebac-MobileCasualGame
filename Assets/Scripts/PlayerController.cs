using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed;

    [Header("Movement")]
    public float speed = 1f;

    [Header("Collisions")]
    public string tagToCheckEnemy = "Enemy";

    private bool _canRun;
    private Vector3 _pos;

    private void Start()
    {
        _canRun = true;
    }

    private void Update()
    {
        if (!_canRun) return;
        //Se a condição for falsa, o código seguinte não é processado

        var _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;
        
        transform.position = Vector3.Lerp(transform.position, _pos, Time.deltaTime * lerpSpeed);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
            _canRun = false;
        }
    }
}
