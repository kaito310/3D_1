using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject player; // [SerializeField] ～ : 他からアクセスできない
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 毎フレーム力を加える
        rb.AddForce(player.transform.position - transform.position);
    }
}
