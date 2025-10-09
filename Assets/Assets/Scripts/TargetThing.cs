using UnityEngine;

public abstract class TargetThing:MonoBehaviour
{
    [SerializeField] GameObject pointerPrefab;

    public void CreateTargetPointer()
    {
        Instantiate(pointerPrefab);
        pointerPrefab.GetComponent<TargetPointer>().targetPosition = transform.position;
    }
}
