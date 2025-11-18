using UnityEngine;
 
public class Animation : MonoBehaviour

{

    public Animator playerAnimator;
 
    private bool wasWalking = false;
 
    void Start()

    {

        if (playerAnimator == null)

            playerAnimator = GetComponentInChildren<Animator>();

    }
 
    void Update()

    {
        bool isWalking = Input.GetKey(KeyCode.A) ||
                         Input.GetKey(KeyCode.D);
 

        if (isWalking && !wasWalking)

        {

            playerAnimator.Play("Walkinfforreal", 0, 0f);

        }

        else if (!isWalking && wasWalking)

        {

            playerAnimator.Play("Idle", 0, 0f);

        }
 
        wasWalking = isWalking;

    }

}
 