using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 30; // Groundが動く速さ
    // PlayerControllerもRigidbodyなどと同様にクラスなので、型として宣言できる
    PlayerController playerControllerScript;
    float leftBound = -15; // 左の限界値

    // Start is called before the first frame update
    void Start()
    {
        // 左辺は宣言しただけなので、代入が必要
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームオーバー状態でなければ、backgroundを動かす
        if (playerControllerScript.gameOver == false)
        { 
                transform.Translate(Vector3.left * Time.deltaTime * speed); 
        }

        // 左の限界値よりも左に行ってしまったら、かつ、左に行き過ぎたやつが障害物のタグ持ちなら
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            // 障害物を消す
            Destroy(gameObject);
        }
    }
}
