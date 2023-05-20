using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos; // リピートの開始位置

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 何か条件が満たされたら．．．
        if (startPos.x - transform.position.x > 50.0f) // (現在のx座標 - 最初のx座標 > 規定値)
        {
            transform.position = startPos; // 場所をリセット
        }
    }
}
