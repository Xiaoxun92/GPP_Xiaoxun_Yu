using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon {

    [SerializeField] float SPEED;
    [SerializeField] float RANGE;

    Vector3 startPos;
    Vector3 deltaPos;
    SpriteRenderer effectSprite;
    float effectAlphaTarget;
    float effectAlpha;

    void Start() {
        startPos = transform.position;
        deltaPos = BasicFunc.AngleToVector(transform.eulerAngles.z) * SPEED;

        effectSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        effectAlphaTarget = effectSprite.color.a;
        effectAlpha = 0;
        SetAlpha();
    }

    protected override void GameUpdate() {
        transform.position += deltaPos * Time.deltaTime;
        if ((transform.position - startPos).magnitude >= RANGE)
            Destroy(gameObject);

        if (effectAlpha < effectAlphaTarget) {
            effectAlpha = Mathf.MoveTowards(effectAlpha, effectAlphaTarget, 1 / 0.5f * Time.deltaTime);
            SetAlpha();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag != "Player")
            return;
        Destroy(gameObject);
    }

    void SetAlpha() {
        Color c = effectSprite.color;
        c.a = effectAlpha;
        effectSprite.color = c;
    }

    protected override void Blocked() {
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy() {
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(0f);
        Destroy(gameObject);
    }

    public override void PrimaryAction() {
    }

    public override void SecondaryAction() {
    }
}
