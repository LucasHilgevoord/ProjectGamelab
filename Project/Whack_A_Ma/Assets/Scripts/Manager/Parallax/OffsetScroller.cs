using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;
    private Renderer Rend;

    void Start() {
        Rend = GetComponent<Renderer>();
        savedOffset = Rend.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update() {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        Rend.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable() {
        Rend.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}