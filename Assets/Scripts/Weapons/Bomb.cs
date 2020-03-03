using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explodePrefab;
    
    private Animator explodeAnimator;
    private float explodeTime;
    private static readonly int IsTouchGround = Animator.StringToHash("isTouchGround");

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Collider2D>().enabled = false;
        GameObject explode = Instantiate(explodePrefab, this.transform);
        explodeAnimator = explode.GetComponentInChildren<Animator>();
        RuntimeAnimatorController runAc = explodeAnimator.runtimeAnimatorController;
        for (int i = 0; i < runAc.animationClips.Length; i++)
        {
            if (runAc.animationClips[i].name == "Explosion")
            {
                explodeTime = runAc.animationClips[i].length;
            }
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        explodeAnimator.SetBool(IsTouchGround, true); //IsTouchGround is equivalent to colliding with obstacles
    }
}
