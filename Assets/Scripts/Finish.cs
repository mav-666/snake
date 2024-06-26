using Snake;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SegmentMobility segmentMobility;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        segmentMobility.maxSpeed = 0;
        gameManager.NexLevel();
    }
}