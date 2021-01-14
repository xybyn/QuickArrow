using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public int MaxObjectsInQueue;

    private Queue<GameObject> _deletingQueue = new Queue<GameObject>();
    public void AddObjectToDelete(GameObject gameObject)
    {
        while (_deletingQueue.Count > MaxObjectsInQueue)
        {
            Destroy(_deletingQueue.Dequeue().gameObject);
        }

        _deletingQueue.Enqueue(gameObject);
    }
}
