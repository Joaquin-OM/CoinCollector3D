using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player killed!");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.RestartLevel();
            }
        }
    }
}
