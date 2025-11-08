using UnityEngine;
using UnityEngine.UI;

public class TargetPointer:MonoBehaviour
{

    [SerializeField] private Camera uiCamera;
    [SerializeField] private Sprite arrowSprite;
    [SerializeField] private Sprite crossSprite;

    public Vector3 targetPosition;


    private RectTransform pointerRectTransform;
    public Image pointerImage;

    private void Awake()
    {
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
        Hide();
    }

    private void Update()
    {
        float borderSize = 100f;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= borderSize ||
            targetPositionScreenPoint.x >= Screen.width - borderSize || 
            targetPositionScreenPoint.y <= borderSize || 
            targetPositionScreenPoint.y >= Screen.height - borderSize;


        RotatePointerTowardsTargetPosition();

        pointerImage.sprite = arrowSprite;
        Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
        if (cappedTargetScreenPosition.x <= borderSize) cappedTargetScreenPosition.x = borderSize;
        if (cappedTargetScreenPosition.x >= Screen.width - borderSize) cappedTargetScreenPosition.x = Screen.width - borderSize;
        if (cappedTargetScreenPosition.y <= borderSize) cappedTargetScreenPosition.y = borderSize;
        if (cappedTargetScreenPosition.y >= Screen.height - borderSize) cappedTargetScreenPosition.y = Screen.height - borderSize;

        Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);
        pointerRectTransform.position = pointerWorldPosition;
        pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);


    }

    private void RotatePointerTowardsTargetPosition()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = Utilities.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show(Vector3 targetPosition)
    {
        gameObject.SetActive(true);
        this.targetPosition = targetPosition;
    }
}
