using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] float jumpForce; // ジャンプ力
    [SerializeField] float gravityModifier; // 重力値調整用
    [SerializeField] bool isOnGround; // 地面についているか
    public bool gameOver;
    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押され、かつ地面にいたら、ゲームオーバーでないなら
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 上へ飛ばす
            isOnGround = false; // ジャンプした＝地面にいない
            playerAnim.SetTrigger("Jump_trig"); // ジャンプアニメ発動準備
        }
    }

    // 衝突が起きたら実行
    private void OnCollisionEnter(Collision collision)
    {
        // ぶつかった相手（collision）のタグがGroundなら
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // 地面についている状態に変更
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true; // ゲームオーバー
            playerAnim.SetBool("Death_b", true); // 死亡状態bにする。
            playerAnim.SetInteger("DeathType_int", 1); // integerは整数の意味。死亡タイプを1番目のやつにする
        }
    } 
}
