using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{
    private GameOver GameOver => UiDisplay.Instance.GameOver;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player)) 
        {
            GameManager.Instance.GameOverTrig = true;
            GameOver.ShowUI();
        }            
    }
}