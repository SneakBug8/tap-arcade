using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Global;
    public LevelObject[] Objects;
    public float Margin = 2f;
    public float MinimumDistanceToPlayer = 20;
    public GameObject LastGameObject;

    public float MinSpeedModifier;
    public float MaxSpeedModifier;

    public float MinRotationModifier;
    public float MaxRotationModifier;
    private void Awake() {
        Global = this;
    }
    private void Start()
    {
        SpawnObject();
    }
    private void Update()
    {

        if (LastGameObject.transform.position.y > -MinimumDistanceToPlayer + Margin)
        {
            SpawnObject();
            return;
        }
    }
    public void SpawnObject()
    {
        var pref = Objects[Random.Range(0, Objects.Length)];
        var ObjPos = -MinimumDistanceToPlayer - pref.YSize;

        LastGameObject = Instantiate(pref.Prefab, new Vector3(0, ObjPos, 0), Quaternion.identity, transform);
        var obstacle = LastGameObject.GetComponent<Obstacle>();

        obstacle.RotationSpeed = Mathf.Lerp(
            MinRotationModifier,
            MaxRotationModifier,
            LevelController.Global.FloatingTime / 60);
        obstacle.Speed = Mathf.Lerp(
            MinSpeedModifier,
            MaxSpeedModifier,
            LevelController.Global.FloatingTime / 60);

        var amount = Random.Range(0, obstacle.RelativePoints.Length + 2 * Random.Range(0, 1000));

        for (int i = 0; i < amount; i++)
        {
            obstacle.Move(0, Time.deltaTime * Random.Range(0, 1000));
        }
    }
}

[System.Serializable]
public class LevelObject
{
    public float YSize;
    public GameObject Prefab;
}