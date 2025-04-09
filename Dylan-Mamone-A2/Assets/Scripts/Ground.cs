using UnityEditor;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;
//allows you to put created material on the object.
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
// makes the ground scroll.
    private void Update()
    {
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x;
        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;  
    }
}
