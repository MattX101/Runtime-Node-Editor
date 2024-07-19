using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector3FlatArrayBuilderUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Vector3 Flat Array Builder");
            Vector3FlatArrayBuilderNode node = root.AddComponent<Vector3FlatArrayBuilderNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "Vector3");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.Vector3, 0, true).AddComponent<MultiConnectionInputPointer>(), ValueType.Vector3, PointerType.ArrayInsert, true);

            node.AddPointer(CreateArrayPointer("Out", ValueType.Vector3, 0).AddComponent<Vector3ArrayOutputPointer>(), ValueType.Vector3, PointerType.Array);
        }
    }
}
