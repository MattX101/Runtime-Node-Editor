using System.Collections.Generic;
using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class Node : MonoBehaviour
    {
        protected bool wasExecuted = false;
        public bool endNode = false;

        public List<InputPointer> inputs = new List<InputPointer>();
        public List<OutputPointer> outputs = new List<OutputPointer>();

        public NodeUIElements elements;

        public virtual void Reset()
        {
            //
        }

        public void ResetExecution()
        {
            wasExecuted = false;
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

            foreach (OutputPointer output in outputs)
            {
                if (output.connectedInputPointers == null)
                    continue;

                foreach (InputPointer input in output.connectedInputPointers)
                    input.node.MoveUp();
            }

            return 1;
        }
    }
}
