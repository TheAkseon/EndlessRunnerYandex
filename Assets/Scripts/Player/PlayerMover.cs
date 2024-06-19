using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeightY;
    [SerializeField] private float _minHeightY;
    [SerializeField] private float _maxHeightX;
    [SerializeField] private float _minHeightX;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if(transform.position != _targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }

    public void TryMoveUp()
    {
        if(_targetPosition.y < _maxHeightY)
        {
            SetNextPositionY(_stepSize);
        }
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeightY)
        {
            SetNextPositionY(-_stepSize);
        }
    }

    public void TryMoveForfard()
    {
        if(_targetPosition.y < _maxHeightX)
        {
            SetNextPositionX(_stepSize);
        }
    }

    public void TryMoveBack()
    {
        if (_targetPosition.y > _minHeightX)
        {
            SetNextPositionX(-_stepSize);
        }
    }

    private void SetNextPositionY(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }

    private void SetNextPositionX(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x  + stepSize, _targetPosition.y);
    }
}
