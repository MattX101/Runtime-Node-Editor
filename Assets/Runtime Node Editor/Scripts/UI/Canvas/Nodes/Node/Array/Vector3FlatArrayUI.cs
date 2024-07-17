using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector3FlatArrayUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Vector3 Flat Array");
            Vector3FlatArrayNode node = root.AddComponent<Vector3FlatArrayNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "Vector3");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.Vector3, 0, true).AddComponent<InputPointer>(), ValueType.Vector3, true);

            node.AddPointer(CreatePointer("Out", ValueType.Vector3, 0).AddComponent<OutputPointer>(), ValueType.Vector3);
        }
    }
}
