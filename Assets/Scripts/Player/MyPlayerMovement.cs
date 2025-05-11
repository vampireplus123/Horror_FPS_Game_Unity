using UnityEngine;

public class MyPlayerMovement : PlayerActionsController
{
    // Update is called once per 
    
    // protected override float speed { get { return 100f; } }

    private void Update()
    {
        moveInput = playerControls.Player.Movement.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        base.Movement();
    }
}
