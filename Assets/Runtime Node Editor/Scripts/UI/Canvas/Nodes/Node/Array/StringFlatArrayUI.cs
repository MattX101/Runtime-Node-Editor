using RuntimeNodeEditor.Nodes.Node;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    internal class StringFlatArrayUI : NodeUI
    {
        public override void Init(string nodeId)
        {
            base.Init(nodeId);

            PopulateRoot("String Flat Array");
            StringFlatArrayNode node = root.AddComponent<StringFlatArrayNode>();

            NumOfInputs = 1;
            NumOfOutputs = 1;

            drawBodyImage = false;

            CreateNodeUI(node, NodeColor.Array, "String");

            node.AddPointer(CreateValueInsertPointer("In", ValueType.String, 0, true).AddComponent<InputPointer>(), ValueType.String, true);

            node.AddPointer(CreatePointer("Out", ValueType.String, 0).AddComponent<OutputPointer>(), ValueType.String);
        }
    }
}
