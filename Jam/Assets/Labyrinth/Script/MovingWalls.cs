using UnityEngine;
using System.Collections;

public class MovingWalls : MonoBehaviour
{
    private Vector3 _originalPosition;
    private Vector3 _targetPosition;
    private bool _isMoving = false;
    private float _moveDistance = 4f;

    void Start()
    {
        _originalPosition = transform.position;

        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0: _targetPosition = _originalPosition + new Vector3(_moveDistance, 0, 0); break;
            case 1: _targetPosition = _originalPosition + new Vector3(-_moveDistance, 0, 0); break;
            case 2: _targetPosition = _originalPosition + new Vector3(0, 0, _moveDistance); break;
            case 3: _targetPosition = _originalPosition + new Vector3(0, 0, -_moveDistance); break;
        }

        StartCoroutine(MoveWall());
    }

    IEnumerator MoveWall()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));

            if (!_isMoving)
            {
                _isMoving = true;
                yield return MoveToPosition(_targetPosition);
                yield return new WaitForSeconds(Random.Range(4f, 8f));
                yield return MoveToPosition(_originalPosition);
                _isMoving = false;
            }
        }
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        float elapsedTime = 0;
        float duration = 2.5f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(transform.position, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
}
