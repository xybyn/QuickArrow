using System.Collections.Generic;
using UnityEngine;
public class ObstacleCreator : MonoBehaviour
{
    public float DistanceFromArrow;

    public Transform ArrowTransform;
    public GameObject ObstaclePrefab;
    public Score Score;
    public ObstacleDestroyer ObjectDestroyer;
    public int MaxObstaclesPerColumn;

    private float step;
    List<int> _list = new List<int>();
    private void Start()
    {
        Score.OnScoreChanged += OnScoreUpdated;
        step = 1f / MaxObstaclesPerColumn;
        _list.Capacity = MaxObstaclesPerColumn;
    }
    private void OnDestroy()
    {
        Score.OnScoreChanged -= OnScoreUpdated;
    }
    private void OnScoreUpdated(int newScore)
    {
        var countOfObstacles = Random.Range(4, MaxObstaclesPerColumn);
        for (int i = 0; i < countOfObstacles; i++)
        {
            int randomY;
            do
            {
                randomY = Random.Range(0, MaxObstaclesPerColumn);
            }
            while (_list.Contains(randomY));
            _list.Add(randomY);
            var yPosition = step* randomY;
            var obstacle = Instantiate(ObstaclePrefab, this.transform);
            var p = Camera.main.ViewportToWorldPoint(new Vector3(0, yPosition, -10f));
            obstacle.transform.position = new Vector3(ArrowTransform.position.x + DistanceFromArrow, p.y-1f- step);
            ObjectDestroyer.AddObjectToDelete(obstacle);
            _list.Clear();
        }
    }
}
