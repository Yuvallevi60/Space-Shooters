using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float SpeedByKeyboard;
    private float SpeedByVirtualStick;

    [SerializeField] private GameObject ShotPrefab;

    public VariableJoystick joystick;

    void Start()
    {
        // Set Joystick Properties
        SpeedByVirtualStick = GameManager.Instance.gameSettings.JoystickSpeed;
        joystick.SetMode(GameManager.Instance.gameSettings.joystickType);
    }

    void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            MoveByKeyboard();
            MoveByVirtualJoystick();

            // handle shooting
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        if (!GameManager.Instance.isPaused)
        {
            Vector2 shotPosition = new(transform.position.x, transform.position.y + 1);
            Instantiate(ShotPrefab, shotPosition, ShotPrefab.transform.rotation);
        }
    }

    private void MoveByKeyboard()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float newXPos = transform.position.x + horizontalInput * SpeedByKeyboard * Time.deltaTime;

        float verticalInput = Input.GetAxis("Vertical");
        float newYPos = transform.position.y + verticalInput * SpeedByKeyboard * Time.deltaTime;

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void MoveByVirtualJoystick()
    {
        Vector2 direction = Vector2.up * joystick.Vertical + Vector2.right * joystick.Horizontal;

        transform.Translate(SpeedByVirtualStick * Time.deltaTime * direction);
    }

}
