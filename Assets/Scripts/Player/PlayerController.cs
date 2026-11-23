using DG.Tweening;
using ebac.Core.Singleton;
using TMPro;
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
    public GameObject coinCollector;
    public TextMeshPro powerUpText;
    public TextMeshPro flyingText;

    [Header("Boundary")]
    public float limit = 4;
    public Vector2 limitVector = new Vector2(-4, 4);

    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;

    private bool invincible = false;

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
            if(!invincible)
                EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            if(!invincible)
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
        powerUpText.text = s;
    }

    public void SetFlyingText(string s)
    {
        flyingText.text = s;
    }

    public void PowerUp_Speed(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = forwardSpeed;
    }

    public void SetInvincible(bool b = true)
    {
        invincible = b;
    }

    public void ChangeHeight(float heightAmount, float powerDuration, float animationDuration, Ease ease)
    {
        /*
        var p = transform.position;
        p.y = _startPosition.y + heightAmount;
        _startPosition = p;
        */

        transform.DOMoveY(_startPosition.y + heightAmount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), powerDuration);
    }

    public void ResetHeight(float animationDuration)
    {
        /*
        var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;
        */

        transform.DOMoveY(_startPosition.y, animationDuration);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }

    #endregion
}
