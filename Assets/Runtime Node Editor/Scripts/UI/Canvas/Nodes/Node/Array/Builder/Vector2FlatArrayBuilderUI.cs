using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class Vector2FlatArrayBuilderUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("Vector2 Flat Array Builder");
            Vector2FlatArrayBuilderNode node = root.AddComponent<Vector2FlatArrayBuilderNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "Vector2");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.Vector2, 0, true).AddComponent<MultiConnectionInputPointer>(), ValueType.Vector2, PointerType.ArrayInsert, true);

            node.AddPointer(CreateArrayPointer("Out", ValueType.Vector2, 0).AddComponent<Vector2ArrayOutputPointer>(), ValueType.Vector2, PointerType.Array);
        }
    }
}
