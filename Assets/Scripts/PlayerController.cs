using ebac.Core.Singleton;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed;

    [Header("Movement")]
    public float forwardSpeed = 1f;

    [Header("Collisions")]
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    [Header("Misc")]
    public GameObject startScreen;
    public GameObject endScreen;

    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();

        //startScreen.SetActive(true);
    }

    private void Update()
    {
        if (!_canRun) return;
        //Se a condição for falsa, o código seguinte não é processado

        var _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;
        
        transform.position = Vector3.Lerp(transform.position, _pos, Time.deltaTime * lerpSpeed);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
            EndGame();
        }
        if(collision.transform.tag == tagToCheckEndLine)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
    }

    #region PowerUp

    public void SetPowerUpText(string s)
    {
        //powerUpUiText.text = s;
    }

    public void PowerUp_Speed(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = forwardSpeed;
    }

    #endregion
}
