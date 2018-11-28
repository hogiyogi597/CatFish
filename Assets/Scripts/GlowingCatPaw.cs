using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingCatPaw : MonoBehaviour {

    public float colliderOffset;

    private BoxCollider2D collider2D;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    public void Initialize(Transform parent)
    {
        anim = this.gameObject.GetComponent<Animator>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        collider2D = this.gameObject.GetComponent<BoxCollider2D>();
        Vector2 parentCollider = parent.localScale;
        collider2D.size = new Vector2(parentCollider.x + colliderOffset, parentCollider.y + 2f * colliderOffset);
        SetVisible(false);
        this.transform.position.Set(this.transform.position.x, -1 * parent.localScale.y, this.transform.position.z);
        //Debug.Log("parentColliderSize: " + parentCollider + " | childColliderSize: " + collider2D.size, this);
    }

    private void SetVisible(bool flag)
    {
        spriteRenderer.enabled = flag;
        anim.enabled = flag;
    }

    private bool IsValidCollision(Collider2D collision)
    {
        return collision.gameObject.name == "Cat";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsValidCollision(collision))
            SetVisible(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (IsValidCollision(collision))
            SetVisible(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsValidCollision(collision))
            SetVisible(false);
    }

}
