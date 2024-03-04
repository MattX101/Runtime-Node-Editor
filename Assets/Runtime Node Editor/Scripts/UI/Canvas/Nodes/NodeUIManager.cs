using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class NodeUIManager : MonoBehaviour
    {
        [SerializeField] private Transform _parent;

        [SerializeField] private Texture2D _pointerTexture;

        void Awake()
        {
            UISettings.nodeCanvasTransform = _parent.transform;
            UISettings.pointerTexture = _pointerTexture;

            ImportUI importUI1 = new ImportUI();
            importUI1.rootRect.localPosition = new Vector3(-500.0f, 70, 0);

            ImportUI importUI2 = new ImportUI();
            importUI2.rootRect.localPosition = new Vector3(-500.0f, -70, 0);

            TestUI testNode = new TestUI();

            ExportUI exportUI = new ExportUI();
            exportUI.rootRect.localPosition = new Vector3(500.0f, 0, 0);
        }
    }
}
