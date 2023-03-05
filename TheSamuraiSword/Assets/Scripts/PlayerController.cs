using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector2 JoystickSize = new Vector2(300, 300);
    [SerializeField] private JoystickController Joystick;
    [SerializeField] private NavMeshAgent Player;
    [SerializeField] private Animator playerAnimator;
    
    private Finger MovementFinger;
    private Vector2 MovementAmount;

    private void Update()
    {
        Vector3 scaledMovement = Player.speed * Time.deltaTime * new Vector3(
            MovementAmount.x,
            0,
            MovementAmount.y
        );

        Player.transform.LookAt(Player.transform.position + scaledMovement, Vector3.up);
        Player.Move(scaledMovement);
        playerAnimator.SetFloat("moveX", MovementAmount.x);
        playerAnimator.SetFloat("moveZ", MovementAmount.y);
    }
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += HandleLoseFinger;
        ETouch.Touch.onFingerMove += HandleFingerMove;
    }
    
    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= HandleLoseFinger;
        ETouch.Touch.onFingerMove -= HandleFingerMove;
        EnhancedTouchSupport.Disable();
    }
    
    private void HandleFingerMove(Finger MovedFinger)
    {
        if (MovedFinger == MovementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = JoystickSize.x / 2f;
            ETouch.Touch currentTouch = MovedFinger.currentTouch;

            if (Vector2.Distance(
                    currentTouch.screenPosition,
                    Joystick.RectTransform.anchoredPosition
                ) > maxMovement)
            {
                knobPosition = (
                    currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition
                    ).normalized
                    * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition;
            }

            Joystick.Knob.anchoredPosition = knobPosition;
            MovementAmount = knobPosition / maxMovement;
        }
    }

    private void HandleLoseFinger(Finger LostFinger)
    {
        if (LostFinger == MovementFinger)
        {
            MovementFinger = null;
            Joystick.Knob.anchoredPosition = Vector2.zero;
            Joystick.gameObject.SetActive(false);
            MovementAmount = Vector2.zero;
        }
    }

    private void HandleFingerDown(Finger TouchedFinger)
    {
        if (MovementFinger == null && TouchedFinger.screenPosition.x <= Screen.width / 2f)
        {
            MovementFinger = TouchedFinger;
            MovementAmount = Vector2.zero;
            Joystick.gameObject.SetActive(true);
            Joystick.RectTransform.sizeDelta = JoystickSize;
            Joystick.RectTransform.anchoredPosition = ClampStartPosition(TouchedFinger.screenPosition);
        }
    }

    private Vector2 ClampStartPosition(Vector2 StartPosition)
    {
        if (StartPosition.x < JoystickSize.x / 2)
        {
            StartPosition.x = JoystickSize.x / 2;
        }

        if (StartPosition.y < JoystickSize.y / 2)
        {
            StartPosition.y = JoystickSize.y / 2;
        }
        else if (StartPosition.y > Screen.height - JoystickSize.y / 2)
        {
            StartPosition.y = Screen.height - JoystickSize.y / 2;
        }

        return StartPosition;
    }

    private void OnGUI()
    {
        GUIStyle labelStyle = new GUIStyle()
        {
            fontSize = 24,
            normal = new GUIStyleState()
            {
                textColor = Color.white
            }
        };
        if (MovementFinger != null)
        {
            GUI.Label(new Rect(10, 35, 500, 20), $"Finger Start Position: {MovementFinger.currentTouch.startScreenPosition}", labelStyle);
            GUI.Label(new Rect(10, 65, 500, 20), $"Finger Current Position: {MovementFinger.currentTouch.screenPosition}", labelStyle);
        }
        else
        {
            GUI.Label(new Rect(10, 35, 500, 20), "No Current Movement Touch", labelStyle);
        }

        GUI.Label(new Rect(10, 10, 500, 20), $"Screen Size ({Screen.width}, {Screen.height})", labelStyle);
    }


  
  // [SerializeField] private float speed;
  // [SerializeField] private DynamicJoystick joystick;
  // [SerializeField] private Image joystickBg;
  // public GameObject sword;
  // public Transform rightHand;
  // [SerializeField] private Rigidbody rb;
  // public Transform joyStickTransform;
  // private bool isRunning;
  // private Animator playerAnimator;
  //
  //  private void Awake()
  // {
  //     playerAnimator = GetComponent<Animator>();
  // }
  //
  // public void FixedUpdate()
  // {
  //    PlayerMovement();
  //    PlayerRunAnimation();
  //    Debug.Log(joyStickTransform);
  //    
  // }
  //
  // private void PlayerMovement()
  // {
  //     Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
  //     transform.Translate(direction * speed);
  //     
  //       
  //     if (direction != Vector3.zero)
  //     {
  //         var lookPos = Camera.main.transform.TransformDirection(direction);
  //         lookPos.y = 0;
  //         transform.rotation = Quaternion.LookRotation(lookPos);
  //         rb.velocity = transform.forward * (speed * Time.fixedDeltaTime);
  //     }
  //     
  //     else
  //     {
  //         rb.velocity = Vector3.zero;
  //     }
  //
  //     if (joystickBg.gameObject.activeSelf)
  //     {
  //         isRunning = true;
  //         sword.transform.position = rightHand.position;
  //         
  //     }
  //     else
  //     {
  //         isRunning = false;
  //         sword.transform.position = transform.position;
  //     }
  // }
  //
  // private void PlayerRunAnimation()
  // {
  //    
  // }

}

