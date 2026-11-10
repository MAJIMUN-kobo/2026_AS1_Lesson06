using UnityEngine;
using UnityEngine.InputSystem;  // 入力デバイス機能の読み込み


/* 「プレイヤー(Player)」キャラクターのクラス
 * ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
 * ■　やること
 *      - 上下左右に移動（ボタン入力）
 *      - 弾を撃つ
 *      - 敵に当たると死亡する
 *      
 * ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
 */
public class Player : MonoBehaviour
{
    // === 変数の宣言（フィールド）
    private float moveSpeed = 1.0f;


    /// <summary>
    /// 初期化処理メソッド
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// 更新メソッド
    /// </summary>
    void Update()
    {
        Movement();         // 移動処理を実行
    }


    /// <summary>
    /// 移動メソッド
    /// </summary>
    public void Movement()
    {
        // ☆　キーボードを使って上下左右(8方向)に移動する処理を記述しなさい
        if (Keyboard.current.wKey.IsPressed() == true)
        {   // [wKey]入力で Y軸(正) の方向へ移動
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }
        if (Keyboard.current.aKey.IsPressed() == true)
        {   // [aKey]入力で X軸(負) の方向へ移動
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Keyboard.current.dKey.IsPressed() == true)
        {   // [dKey]入力で X軸(正) の方向へ移動
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Keyboard.current.sKey.IsPressed() == true)
        {   // [sKey]入力で Y軸(負) の方向へ移動
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
        }
    }


    /// <summary>
    /// 死亡処理メソッド
    /// </summary>
    public void Dead()
    {
        // 死亡したら「隠す」
        gameObject.SetActive( false );
    }
}
