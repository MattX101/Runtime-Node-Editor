using UnityEngine;

namespace RuntimeNodeEditor.UI
{
    internal class UIManager : MonoBehaviour
    {
        [Header("Transforms")]
        [SerializeField] private Transform _nodeSpawnTransform;
        [SerializeField] private Transform _windowSpawnParent;

        [Header("Textures")]
        [SerializeField] private Texture2D _pointerTexture;

        private void Awake()
        {
            UISettings.NodeSpawnTransform = _nodeSpawnTransform;
            UISettings.WindowSpawnParent = _windowSpawnParent;

            UISettings.PointerTexture = _pointerTexture;
        }
    }
}
