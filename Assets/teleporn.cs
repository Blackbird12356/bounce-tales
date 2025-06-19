using UnityEngine;

public class teleporn : MonoBehaviour
{
    public Transform player, destination;
    public GameObject playerobject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerobject.SetActive(false);
            player.position = destination.position;
            playerobject.SetActive(true);
        }
    }
}
