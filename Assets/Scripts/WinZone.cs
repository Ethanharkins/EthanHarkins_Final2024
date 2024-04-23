using UnityEngine;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.transform.Find("Body") != null) // Assuming the Body is a child of the Player when picked up
        {
            GameManager.Instance.PlayerWon();
        }
    }
}
