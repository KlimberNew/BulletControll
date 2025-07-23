using NTC.MonoCache;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Destractible : MonoCache, IDestractible
{
    [SerializeField] private float infectionDuration = 1.5f;
    [SerializeField] private Color infectedColor = Color.red;

    private Renderer _renderer => GetComponent<Renderer>();
    private Material _material;
   // private bool _infected;
    private void Awake()
    {
        // —оздаЄм экземпл€р материала, чтобы не вли€ть на другие объекты с тем же материалом
        _material = _renderer.material;
    }

    public void Destroed()
    {
        StartCoroutine(DestractionObject());        
    }
    private IEnumerator DestractionObject()
    {
        Color startColor = _material.color;
        float timer = 0f;
        //Debug.Log(_material);
        //Debug.Log("Start infect");

        while (timer < infectionDuration)
        {
            timer += Time.deltaTime;
            float t = timer / infectionDuration;
            _material.color = Color.Lerp(startColor, infectedColor, t);
            yield return null;
        }

        Destroy(gameObject);
    }
}