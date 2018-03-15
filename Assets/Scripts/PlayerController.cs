using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    public Sprite invincibilityEffectSprite;
    private bool invincible = false;

    private SpriteRenderer powerUpEffect;
    private GameManager manager;
    private Vector3 mousePosition;
    private float playerX;
    public float invincibilityRemainingTime = 0f;

    void Start()
    {
        playerX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 16, 0, 0)).x;
        manager = transform.parent.gameObject.GetComponent<GameManager>();
        powerUpEffect = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (manager.IsGameRunning)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.x = playerX;
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
        if (invincibilityRemainingTime < 0) removeInvincibility();
        else if (invincibilityRemainingTime > 0 && invincibilityRemainingTime < 3)
        {
            if (invincibilityRemainingTime > 2.5 || invincibilityRemainingTime < 1.5 && invincibilityRemainingTime > 1 || invincibilityRemainingTime < 0.5) powerUpEffect.sprite = null;
            else powerUpEffect.sprite = invincibilityEffectSprite;
        }
        if(invincibilityRemainingTime > 0) invincibilityRemainingTime -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle" && !invincible)
        {
            manager.PlayerTouched(collision);
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Invincibility")
        {
            Destroy(collision.gameObject);
            setInvincibility();
        }
    }

    private void setInvincibility()
    {
        if (invincibilityRemainingTime < 0) invincibilityRemainingTime = 5;
        else invincibilityRemainingTime += 5;
        powerUpEffect.sprite = invincibilityEffectSprite;
        invincible = true;
    }

    private void removeInvincibility()
    {
        powerUpEffect.sprite = null;
        invincible = false;
    }


}
