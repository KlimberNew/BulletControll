using NTC.MonoCache;
using UnityEngine;

public class BulletLogic : MonoCache
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDestractible>(out IDestractible target)) 
        {
            Debug.Log(target);
            target.Destroed();
            Destroy(gameObject);
        }
    }
}