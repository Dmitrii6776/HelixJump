using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{

    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;

    private Ball _ball;

    private Beam _beam;

    private Vector3 _cameraPosition;

    private Vector3 _minBallPosition;
    // Start is called before the first frame update
    void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _cameraPosition = _ball.transform.position;
        _minBallPosition = _ball.transform.position;
        
        Tracking();
        
    }

    private void Tracking()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPosition -= direction * _lenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }

    // Update is called once per frame
    void Update()
    {

        if (_ball.transform.position.y < _minBallPosition.y)
        {
            Tracking();
            _minBallPosition = _ball.transform.position;
        }
    }
}
