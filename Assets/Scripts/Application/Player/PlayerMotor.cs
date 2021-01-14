using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour, IGameStartSender, IGameOverSender
{
    [Range(0, 1)]
    public float InterpolationTime;
    public float MoveSpeed;

    public event Action OnGameStarted;
    public event Action OnGameOver;
    private Rigidbody _rb;
    private float _direction = 0;
    private bool _isGameOver = false;
    public void Turn()
    {
        if (_direction == 0)
        {
            OnGameStarted?.Invoke();
            _direction = 1;
        }
        else
            _direction = -_direction;
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        CheckVisibility();
        _rb.MoveRotation(Quaternion.Lerp(
            _rb.rotation,
            Quaternion.Euler(0, 0, 45f * _direction),
            InterpolationTime));
        _rb.velocity = _rb.transform.localToWorldMatrix * Vector3.right * MoveSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            if (!_isGameOver)
            {
                OnGameOver?.Invoke();
                _isGameOver = true;
            }
        }
    }
    //determines whether the player is out of sight
    private void CheckVisibility()
    {
        var yInViewport = Camera.main.WorldToViewportPoint(_rb.transform.position).y;
        if (yInViewport > 1f || yInViewport <0f)
        {
            if (!_isGameOver)
            {
                OnGameOver?.Invoke();
                _isGameOver = true;
            }
        }
    }
}
