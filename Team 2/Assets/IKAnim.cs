using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAnim : MonoBehaviour
{

    [SerializeField] Animator anim;
    private float weightForPosition = 0.8f;
    private float weightForRotation = 0.8f;
    private float weightForLook = 0.8f;
    private float bodyWeight = 0.5f;
    private float headWeight = 1f;
    private float eyesWeight = 1f;
    private float clampWeight = 0.5f;

    private void OnAnimatorIk ()
    {
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weightForPosition);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, weightForRotation);
        anim.SetLookAtWeight(weightForLook, bodyWeight, headWeight, eyesWeight, clampWeight);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
