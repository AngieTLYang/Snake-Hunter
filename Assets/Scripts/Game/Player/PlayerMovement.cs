using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    //To be able to set this value from Unity, allow this by adding the SerializeField attribute
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _screenBorder;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Camera _camera;

    //Unity will call this method when the scene is first initialized
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    //This method is called at the frequency of the physics system, and any changes to a Rigidbody are recommended to be made inside this method.
    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f
        );
        _rigidbody.linearVelocity = _smoothedMovementInput * _speed;
        PreventPlayerGoingOffScreen();
    }

    private void PreventPlayerGoingOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);
        if ((screenPosition.x < _screenBorder && _rigidbody.linearVelocity.x < 0) ||
            (screenPosition.x > _camera.pixelWidth - _screenBorder && _rigidbody.linearVelocity.x > 0)) 
        {
            _rigidbody.linearVelocity = new Vector2(0, _rigidbody.linearVelocity.y);
        }
        if ((screenPosition.y < _screenBorder && _rigidbody.linearVelocity.y < 0) ||
            (screenPosition.y > _camera.pixelHeight - _screenBorder && _rigidbody.linearVelocity.y > 0))
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, 0); 
        }
    }

    private void RotateInDirectionOfInput()
    {
        Vector2 _mouseDirection = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _camera.ScreenToWorldPoint(Input.mousePosition));
        Debug.Log($"Input.mousePosition : {Input.mousePosition}");
        transform.up = _mouseDirection;
    }
    //This method will be called whenever there is a change to the input bound to the move action.
    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
        Debug.Log($"_movementInput : {_movementInput}");
    }
}
