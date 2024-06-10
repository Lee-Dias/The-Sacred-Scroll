using UnityEngine;

public class ShaderDebugger : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer[] spriteRenderers = FindObjectsOfType<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            Material material = spriteRenderer.material;
            if (material != null && material.shader.name != "Sprites/Default")
            {
                Debug.LogWarning($"Shader problem detected in {spriteRenderer.gameObject.name}. Resetting to default shader.");
                spriteRenderer.material.shader = Shader.Find("Sprites/Default");
            }
        }
    }
}