using UnityEngine;

// ゲーム内の全オブジェクトに対して利用可能なアニメーション処理を記述

public class AnimatedSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // キーが入力されてない時に表示させるSprite?
    public Sprite idleSprite;
    public Sprite[] animationSprites;
    // オブジェクトごとにNextFrameを呼び出す間隔が異なる為、publicに設定してinspectorから設定できるようにする。デフォルトでは0.25 second
    public float animationTime = 0.25f;
    private int animationFrame;

    public bool loop = true;
    public bool idle = true;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }


    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void Start()
    { InvokeRepeating(nameof(NextFrame), animationTime, animationTime); }

    private void NextFrame()
    {
        animationFrame++;

        if (loop && animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        if (idle)
        {
            spriteRenderer.sprite = idleSprite;
        }
        else if (animationFrame >= 0 && animationFrame < animationSprites.Length)
        {
            spriteRenderer.sprite = animationSprites[animationFrame];
        }
    }

}
