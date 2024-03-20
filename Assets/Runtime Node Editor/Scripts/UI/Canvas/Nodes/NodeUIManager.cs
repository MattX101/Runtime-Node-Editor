using RuntimeNodeEditor.UI.Canvas.Data;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class NodeUIManager : MonoBehaviour
    {
        [SerializeField] private Transform _parent;

        [SerializeField] private Texture2D _pointerTexture;

        [Header("UI Elements")]
        [SerializeField] private GameObject _inputField;

        void Awake()
        {
            CanvasData.inputField = _inputField;

            UISettings.nodeCanvasTransform = _parent.transform;
            UISettings.pointerTexture = _pointerTexture;

            /*ImportUI importUI1 = new ImportUI();
            importUI1.rootRect.localPosition = new Vector3(-500.0f, 70, 0);

            ImportUI importUI2 = new ImportUI();
            importUI2.rootRect.localPosition = new Vector3(-500.0f, -70, 0);

            TestUI testNode = new TestUI();

            ExportUI exportUI = new ExportUI();
            exportUI.rootRect.localPosition = new Vector3(500.0f, 0, 0);*/

            IntInputUI intIn = new IntInputUI();
            FloatInputUI floatIn = new FloatInputUI();
            Vector2InputUI vector2InputUI = new Vector2InputUI();
            Vector3InputUI vector3InputUI = new Vector3InputUI();
            BoolInputUI boolInputUI = new BoolInputUI();
            ColorInputUI colorInputUI = new ColorInputUI();
            CharInputUI charInputUI = new CharInputUI();
            StringInputUI stringInputUI = new StringInputUI();

            IntOutputUI intOut = new IntOutputUI();
            FloatOutputUI floatOut = new FloatOutputUI();
            Vector2OutputUI vector2OutputUI = new Vector2OutputUI();
            Vector3OutputUI vector3OutputUI = new Vector3OutputUI();
            BoolOutputUI boolOutputUI = new BoolOutputUI();
            ColorOutputUI colorOutputUI = new ColorOutputUI();
            CharOutputUI charOutputUI = new CharOutputUI();
            StringOutputUI stringOutputUI = new StringOutputUI();

            float y = 0.0f;
            intIn.rootRect.localPosition = new Vector3(-200, y, 0);
            intOut.rootRect.localPosition = new Vector3(200, y, 0);
            y += intIn.rootRect.sizeDelta.y + 50.0f;

            floatIn.rootRect.localPosition = new Vector3(-200, y, 0);
            floatOut.rootRect.localPosition = new Vector3(200, y, 0);
            y += floatIn.rootRect.sizeDelta.y + 50.0f;

            vector2InputUI.rootRect.localPosition = new Vector3(-200, y, 0);
            vector2OutputUI.rootRect.localPosition = new Vector3(200, y, 0);
            y += vector2InputUI.rootRect.sizeDelta.y + 50.0f;

            vector3InputUI.rootRect.localPosition = new Vector3(-200, y, 0);
            vector3OutputUI.rootRect.localPosition = new Vector3(200, y, 0);
            y += vector3InputUI.rootRect.sizeDelta.y + 50.0f;

            boolInputUI.rootRect.localPosition = new Vector3(-200, y, 0);
            boolOutputUI.rootRect.localPosition = new Vector3(200, y, 0);
            y += boolInputUI.rootRect.sizeDelta.y + 50.0f;

            charInputUI.rootRect.localPosition = new Vector3(-200, y, 0);
            charOutputUI.rootRect.localPosition = new Vector3(200, y, 0);
            y += charInputUI.rootRect.sizeDelta.y + 50.0f;

            stringInputUI.rootRect.localPosition = new Vector3(-200, y, 0);
            stringOutputUI.rootRect.localPosition = new Vector3(200, y, 0);

            colorInputUI.rootRect.localPosition = new Vector3(600, 0, 0);
            colorOutputUI.rootRect.localPosition = new Vector3(1000, 0, 0);
        }
    }
}
