using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    public static string maintexture = "_MainTex";

    public float scroll_Speed = 0.3f;

    private MeshRenderer mesh_Renderer;

    private void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Scroll();
    }


    // Infinite Scrolling of Background
    // don't forget to change the setting of the sprite image in advance setting to warp

    void Scroll()
    {
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset(maintexture);

        offset.y += Time.deltaTime * scroll_Speed;

        mesh_Renderer.sharedMaterial.SetTextureOffset(maintexture, offset);

    }
}
