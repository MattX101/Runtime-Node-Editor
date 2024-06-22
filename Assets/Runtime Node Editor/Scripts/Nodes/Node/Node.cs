using System.Collections.Generic;
using System.Linq;
using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Node : MonoBehaviour
    {
        protected bool WasExecuted;
        public bool endNode;

        public List<InputPointer> inputs = new();
        public List<OutputPointer> outputs = new();

        public NodeUIElements Elements;

        public virtual void Reset()
        {
            //
        }

        protected void ResetExecution()
        {
            WasExecuted = false;
        }

        protected void AddInputPointer(InputPointer inputPointer)
        {
            inputs.Add(inputPointer);
        }
        protected void AddOutputPointer(OutputPointer outputPointer)
        {
            outputs.Add(outputPointer);
        }

        public virtual void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            //
        }

        public void DeletePointerConnections()
        {
            foreach (InputPointer input in inputs)
                input.DeleteConnection();

            foreach (OutputPointer output in outputs)
                output.DeleteConnections();
        }

        public virtual void Execute()
        {
            //
        }

        public int MoveUp()
        {
            if (endNode)
            {
                Execute();
                return 0;
            }
            
            if (outputs == null)
                return 0;

            foreach (var input in outputs.Where(output => output.connectedInputPointers != null).SelectMany(output => output.connectedInputPointers))
                input.node.MoveUp();

            return 1;
        }
    }
}
