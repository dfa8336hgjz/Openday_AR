using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputControl : MonoBehaviour
{
    private TouchControl touchControl;
    // Start is called before the first frame update
    private void Awake()
    {
        touchControl = new TouchControl();
    }

    private void OnEnable()
    {
        touchControl.Enable();
    }

    private void OnDisable()
    {
        touchControl.Disable();
    }

    private void Start()
    {
        touchControl.Touch.TouchPressButton.started += ctx => StartTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext ctx)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchControl.Touch.TouchPosition.ReadValue<Vector2>());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            MyButton button = hit.collider.gameObject.GetComponent<MyButton>();
            if (button)
            {
                button.OnClick();
            }
        }
    }
}
