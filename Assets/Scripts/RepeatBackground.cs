using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos; // リピートの開始位置
    float repeatWidth; // リピートの幅

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;//ゲーム開始時の場所を記憶
        // 背景のコライダーのⅹ方向の長さの半分をリピート幅にする（ずっと固定）
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // 何か条件が満たされたら．．．
        if (startPos.x - transform.position.x > repeatWidth) // (現在のx座標 - 最初のx座標 > 規定値)
        {
            transform.position = startPos; // 場所をリセット
        }
    }
}
