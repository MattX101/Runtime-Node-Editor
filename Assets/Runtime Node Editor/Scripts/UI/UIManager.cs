using UnityEngine;

namespace RuntimeNodeEditor.UI
{
    internal class UIManager : MonoBehaviour
    {
        [Header("Transforms")]
        [SerializeField] private Transform nodeSpawnTransform;
        [SerializeField] private Transform windowSpawnParent;

        [Header("Textures")]
        [SerializeField]
        private Texture2D pointerTexture;

        private void Awake()
        {
            UISettings.NodeSpawnTransform = nodeSpawnTransform;
            UISettings.WindowSpawnParent = windowSpawnParent;

            UISettings.PointerTexture = pointerTexture;
        }
    }
}
