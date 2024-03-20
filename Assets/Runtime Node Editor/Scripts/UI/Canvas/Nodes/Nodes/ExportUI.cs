using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class ExportUI : NodeUI
    {
        public ExportUI()
        {
            CreateRoot("Export");
            ExportNode exportNode = root.AddComponent<ExportNode>();
            exportNode.nodeUI = this;

            inputs = new InputPointer[1];
            numOfInputs = inputs.Length;
            numOfOutputs = 0;

            togglePreviewImage = true;
            CreateNodeUI(exportNode, Color.gray, "Export");

            inputs[0] = CreatePointer("In", ValueType.Float, 0, true, true).AddComponent<InputPointer>();
            inputs[0].name = "In";
            inputs[0].node = exportNode;
            inputs[0].valueType = ValueType.Float;

            exportNode.AddPointers(inputs, outputs);
        }
    }
}
