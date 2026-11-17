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
    public GameObject bulletPrefab;     // 弾丸のプレハブの変数

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

        // ----- 弾丸を出す
        Shot();
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


    /// <summary>
    /// 弾丸のプレハブを複製する（弾を撃つ）
    /// --------------------------------------
    /// 1. 弾丸のオブジェクトを用意
    /// 2. 弾丸のオブジェクトを「プレハブ化」
    /// 3. 弾丸のプレハブをInstantiate()で複製
    /// 4. 弾丸のRigidbody2Dを利用して射出する
    /// </summary>
    public void Shot()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame == true)
        {
            // GameObject Instantiate(元のオブジェクト参照, 出現座標, 出現角度);
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 0));

            // クローンのRigidbody2Dを使って射出する
            Rigidbody2D rb2d = clone.GetComponent<Rigidbody2D>();

            // Rigidbody2D.AddForce( 力の量と方向, フォースモード )
            rb2d.AddForce(new Vector2(1, 0) * 20, ForceMode2D.Impulse);
        }
    }

    
    /// <summary>
    /// 重複衝突
    /// </summary>
    void OnTriggerEnter2D(Collider2D hitObject)
    {
        Debug.Log($"[Player] 何かと重なりました >> {hitObject.name}");

        // タグが[Enemy]という文字列のオブジェクトとの衝突判定
        if( hitObject.transform.tag =="Enemy" )
        {
            Debug.Log("[Player] 敵に衝突しました...");

            Dead();
        }
    }
}
