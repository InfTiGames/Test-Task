using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float _throttleIncrement = 1f, _maxThrust = 200f, _responsiveness = 10f, _lift = 2000f;
    private float _horizontalInput, _verticalInput, _throttle;

    private const string HorizontalAxis = "Horizontal", VerticalAxis = "Vertical";

    private Rigidbody _rigidBody;
    private PhotonView _view;
    private TextMeshProUGUI _hud;

    private float ResponseModifier { get { return (_rigidBody.mass / 10f) * _responsiveness; } }

    private void Start() {
        _rigidBody = GetComponent<Rigidbody>();
        _view = GetComponent<PhotonView>();
        _hud = FindFirstObjectByType<TextMeshProUGUI>();
    }

    private void HandleInput() {
        _horizontalInput = Input.GetAxis(HorizontalAxis);
        _verticalInput = Input.GetAxis(VerticalAxis);

        if (_verticalInput > 0f) _throttle += _throttleIncrement;
        else if (_verticalInput < 0f) _throttle -= _throttleIncrement;

        _throttle = Mathf.Clamp(_throttle, 0f, 100f);
    }

    private void Update() {
        HandleInput();
        if (_view.IsMine) UpdateHUD();
    }

    private void FixedUpdate() {
        if (_view.IsMine) HandleMovement();
    }

    private void HandleMovement() {
        _rigidBody.AddForce(_maxThrust * _throttle * transform.forward);
        if (transform.position.y <= 1f) _rigidBody.AddForce(_lift * _rigidBody.velocity.magnitude * Vector3.up);
        _rigidBody.AddTorque(ResponseModifier * _horizontalInput * transform.up);
    }

    private void UpdateHUD() {
        _hud.text = Physics.gravity.y.ToString() + " - Your gravity\n";
        _hud.text += _throttle.ToString("F0") + " - Throttle\n";
        _hud.text += (_rigidBody.velocity.magnitude * 3.6f).ToString("F0") + " - Airspeed" + " km/h";
    }
}