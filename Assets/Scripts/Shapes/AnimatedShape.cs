using System.Collections.Generic;
using UnityEngine;

public class AnimatedShape : Shape
{
    [System.Serializable]
    public class AnimationInfo
    {
        public string name;
        public Vector2 pivot;
        public float duration;
        public int priority;
    }
    [SerializeField] List<AnimationInfo> animationInfos = new List<AnimationInfo>();

    //variables
    Movement movement;
    Weapon weapon;
    string oldAnimationState;
    string animationState;
    int animationPirority = 0;
    Vector2 originalPivot;

    Duration playAnimationDur = new Duration();


    bool nonLoopChange;



    private void Awake()
    {
        movement = unit.GetComponent<Movement>();
    }
    protected virtual void Start()
    {
        if (animator)
            InvokeRepeating("SetRandomFloat", 1, 1);

        if (unit.health)
            unit.health.onTakeDamage += (x) =>
            {
                Play(AnimationCode.Hit);
            };
    }

    void SetRandomFloat()
    {
        animator.SetFloat("random", Random.value);
    }

    private void Update()
    {
        if (playingChange)
            Play(playingCode);
        else
            Play(GetAnimationCode());

        playingChange = false;
        if (movement)
        {
            if (playingCode == AnimationCode.Run)
                animator.SetFloat("speed", movement.inputMovement.magnitude);
            else
                animator.SetFloat("speed", 1);
        }
    }

    protected virtual AnimationCode GetAnimationCode()
    {
        if (unit.health && unit.health.isDead)
            return AnimationCode.Die;
        if (movement && movement.isMoving)
            return AnimationCode.Run;
        return 0;
    }

}