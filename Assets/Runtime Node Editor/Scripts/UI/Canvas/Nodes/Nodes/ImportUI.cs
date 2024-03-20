using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
{
    public class ImportUI : NodeUI
    {
        public ImportUI()
        {
            CreateRoot("Import");
            ImportNode importNode = root.AddComponent<ImportNode>();
            importNode.nodeUI = this;

            numOfInputs = 0;
            outputs = new OutputPointer[1];
            numOfOutputs = outputs.Length;

            togglePreviewImage = false;
            CreateNodeUI(Color.gray, "Import");

            outputs[0] = CreatePointer("Out", ValueType.Int, 0, true, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = importNode;
            outputs[0].valueType = ValueType.Int;

            importNode.AddPointers(inputs, outputs);
        }
    }
}
