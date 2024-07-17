using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Functions.UI.Elements;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Node : MonoBehaviour
    {
        protected bool WasExecuted;
        public bool endNode;

        public readonly List<InputPointer> inputs = new();
        public readonly List<OutputPointer> outputs = new();

        public NodeUIElements Elements;

        public virtual void Reset()
        {
            //
        }

        protected void ResetExecution()
        {
            WasExecuted = false;
        }

        public void AddPointer(InputPointer inputPointer, ValueType valueType, bool allowMultipleConnections = false)
        {
            inputPointer.node = this;
            inputPointer.valueType = valueType;
            inputPointer.allowsMultipleConnection = allowMultipleConnections;   

            inputs.Add(inputPointer);
        }
        public void AddPointer(OutputPointer outputPointer, ValueType valueType)
        {
            outputPointer.node = this;
            outputPointer.valueType = valueType;

            outputs.Add(outputPointer);
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
