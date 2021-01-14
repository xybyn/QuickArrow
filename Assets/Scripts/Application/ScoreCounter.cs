using System.Collections;
using UnityEngine;

public class ScoreCounter : MonoBehaviour, IGameStartReciever, IGameOverReciever
{
    public Score Score;

    public void OnGameOverRecieved()
    {
        StopCoroutine(CountScore());
    }

    public void OnGameStartRecieved()
    {
        StartCounting();
    }

    public void StartCounting()
    {
        StartCoroutine(CountScore());
    }
    private IEnumerator CountScore()
    {
        while (true)
        {
            Score.CurrentScore++;
            yield return new WaitForSeconds(1);
        }
    }

}
