using UnityEngine;

public class Diamond : MonoBehaviour
{
    public ScoreManager scoreManager;  

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        scoreManager.IncreaseScore(1);  
        Destroy(gameObject);            
    }
}
