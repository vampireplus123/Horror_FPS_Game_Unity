using UnityEngine;

public class MyPlayerLook : PlayerActionsController
{
    // Bạn có thể tùy chỉnh nếu cần giá trị mouseSensitivity ở đây.
    // protected override float mouseSensitivity { get; set; } = 100f;  

    void Update()
    {
        base.Look();  
    }
}
