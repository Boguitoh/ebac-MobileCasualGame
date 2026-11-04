using UnityEngine;

public class CollectibleCoin : CollectibleBase
{
    public Collider coinCollider;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;

    private void Start()
    {
        //CoinsAnimationManager.Instance.RegisterCoins(this);
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
        coinCollider.enabled = false;
        collect = true;
        //PlayerController.instance.Bounce();
    }

    protected override void Collect()
    {
        OnCollect();
    }

    private void Update()
    {
        /*
        if (collect) 
        { 
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime); 
            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance) 
            { 
                HideItens(); Destroy(gameObject); 
            } 
        }
        */
    }
}
