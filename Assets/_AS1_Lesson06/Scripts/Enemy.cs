using UnityEngine;

/* 「敵(Enemy)」キャラクターのクラス
 * ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
 * ■　やること
 *      - 左に移動する
 *      - 弾に当たると「死亡」
 *      
 * ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
 */
public class Enemy : MonoBehaviour
{
    // === 変数の宣言（フィールド）
    private float moveSpeed = 3.0f;


    /// <summary>
    /// 初期化処理メソッド
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// 更新処理メソッド
    /// </summary>
    void Update()
    {
        Movement();     // 移動処理を実行
    }


    /// <summary>
    /// 移動メソッド
    /// </summary>
    public void Movement()
    {
        // ★ 左に移動する命令を記述しなさい
        // オブジェクトを移動させるメソッド
        // [ transform.Translate( X軸の移動量, Y軸の移動量, Zの移動量 ) ]
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);

        // moveSpeed = 1.0f;    // 移動速度の値[1.0f]
        // Updateで毎フレーム移動させる場合、
        // 1.0f / frame になる　=> くそ速い
        // Speed / 秒に変換する必要がある！

        // Time.deltaTime => Update実行時のスキマ時間
        // スキマ時間を足し続けると、1秒になる！
        // 移動速度 * スキマ時間で 速度を 1/秒 にすることができる。
    }


    /// <summary>
    /// 死亡処理メソッド
    /// </summary>
    public void Dead()
    {
        // Unityでの「隠す」「表示する」機能
        // gameObject.SetActive( true or false )
        gameObject.SetActive( false );
    }
}
