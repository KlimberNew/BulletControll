using NTC.MonoCache;
using UnityEngine;

public class HUD : MonoCache
{
    public void ShowUI()
    {
        Debug.Log("UI active: " + gameObject);
        gameObject.SetActive(true);
    }
    public void HideUI() 
    {
        Debug.Log("UI deactive: " + gameObject);
        gameObject.SetActive(false);
    }
}