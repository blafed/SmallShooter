using UnityEngine;

public class Shape : MonoBehaviour
{

    public Unit unit => this.GetCachedComponentInParent(ref _unit);
    public Animator animator => this.GetCachedComponent(ref _animator);
    public SpriteRenderer spriteRenderer => this.GetCachedComponent(ref _spriteRenderer);
    public SpriteMask spriteMask => this.GetCachedComponent(ref _spriteMask);

    Unit _unit;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    SpriteMask _spriteMask;

    protected AnimationCode playingCode;
    protected bool playingChange;


    public virtual void Play(AnimationCode code)
    {
        if (playingCode == code)
            return;
        playingCode = code;
        animator.SetTrigger("change");
        animator.SetInteger("state", (int)code);
        playingChange = true;
    }




}


public enum AnimationCode
{
    Idle,
    Run,
    Die,
    Attack,
    Hit,
}