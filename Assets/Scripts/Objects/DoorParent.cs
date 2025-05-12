using UnityEngine;

public class DoorParent : MonoBehaviour,IDoor
{
    [SerializeField] Animator animator;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void DoorOpen(bool isOpen)
    {
        if(isOpen == false)
        {
            Debug.LogWarning("wrong boolean, the isOpen must be true");
            return;
        }
        DoorAnimationPlayed(isOpen);
        Debug.Log("Animator Played");
    }
    public void DoorClose(bool isOpen)
    {
        if(isOpen == true)
        {
            Debug.LogWarning("wrong boolean, the isOpen must be true");
            return;
        }
        DoorAnimationPlayed(isOpen);
        Debug.Log("Animator Played");
    }

    private void DoorAnimationPlayed(bool isOpen)
    {
        animator.SetBool("DoorIsOpened", isOpen);
    }
}
