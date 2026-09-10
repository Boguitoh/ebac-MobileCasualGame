using System.Collections.Generic;
using UnityEngine;

public class CollectibleBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particle;
    public float timeToHide;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;

     
    private void Awake()
    {
        if (particle != null) particle.transform.SetParent(null);
        // Move o objeto para a raíz do projeto, evitando exclusão
    }
    //Método não funcionou, "transform resides in a prefab asset and cannot be set to prevent data corruption"
    //Agora funciona (?)
    

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        this.GetComponent<Collider>().enabled = false;
        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particle != null) particle.Play();
        if (audioSource != null) audioSource.Play();
    }

}
