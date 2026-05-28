using System.Data;
using UnityEngine;

public class YokoEnemySpawn : MonoBehaviour
{
    [Header("生成設定")]
    [SerializeField] private GameObject prefabToSpawn;   // インスペクターで設定するプレファブ
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(5f, 5f); // 生成範囲のサイズ（X幅, Y高さ）
    [SerializeField] private int spawnCount = 1;          // 一度に生成する数
    [SerializeField] private float spawnTimelimit = 3.0f;      // 何秒ごとに生成するか

    [Header("オプション")]
    [SerializeField] private bool spawnOnStart = false;    // 開始時に生成するか
    [SerializeField] private bool keepOriginalRotation = true; // プレファブの元の回転を維持するか

    private bool spawnTrue = false;
    private float spawnTimeCount = 0;

    private void Start()
    {
        spawnTrue = false;
    }

    private void Update()
    {
        spawnTimeCount += Time.deltaTime;

        if(spawnTimeCount > spawnTimelimit )
        {
            spawnTimeCount = 0;
            spawnTrue = true;
        }
        else
        {
            spawnTrue = false;
        }

        // キー入力で生成（デバッグ用など）
        if (spawnTrue)
        {
            SpawnRandomPrefabs();
        }
    }

    /// <summary>
    /// 自分の範囲内のランダムな位置にプレファブを指定された数だけ生成する
    /// </summary>
    public void SpawnRandomPrefabs()
    {
        if (prefabToSpawn == null)
        {
            Debug.LogWarning("プレファブが設定されていません！");
            return;
        }

        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 randomPosition = GetRandomPositionInArea();
            Quaternion rotation = keepOriginalRotation ? prefabToSpawn.transform.rotation : Quaternion.identity;

            Instantiate(prefabToSpawn, randomPosition, rotation);
        }
    }

    /// <summary>
    /// 自分のオブジェクトを中心とした範囲内のランダムなワールド座標を取得
    /// </summary>
    private Vector2 GetRandomPositionInArea()
    {
        float randomX = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float randomY = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

        // 自分のワールド座標を中心にしたオフセットを加算
        Vector2 center = transform.position;
        return center + new Vector2(randomX, randomY);
    }

    /// <summary>
    /// 範囲の矩形をSceneビューで視覚化（デバッグ用）
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Vector3 center = transform.position;
        Vector3 size = new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0);
        Gizmos.DrawWireCube(center, size);
        Gizmos.color = new Color(0, 1, 0, 0.1f);
        Gizmos.DrawCube(center, size);
    }
}
