using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform Target;
    public float InterpolationTime;
    public float Offset;
    private Transform _transform;
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        _transform.position = Vector3.Lerp(
            _transform.position,

            new Vector3(
            Target.transform.position.x+ Offset,
            _transform.position.y,
            _transform.position.z
            ),

            InterpolationTime * Time.deltaTime);    
    }
}
