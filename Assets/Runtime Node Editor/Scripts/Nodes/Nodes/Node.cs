using System.Collections.Generic;
using RuntimeNodeEditor.RuntimeNode.Pointer;
using RuntimeNodeEditor.RuntimeNode.UI;
using UnityEngine;

namespace RuntimeNodeEditor.RuntimeNode
{
    public class Node : MonoBehaviour
    {
        protected bool wasExecuted = false;

        public NodeUI nodeUI = null;

        public List<InputPointer> inputs = new List<InputPointer>();
        public List<OutputPointer> outputs = new List<OutputPointer>();

        public virtual void Reset()
        {
            //
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

        public virtual void Exectute()
        {
            //
        }

        public virtual NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new NodeUI(), spawnPosition);
        }

        protected NodeUI Paste(NodeUI ui, Vector3 spawnPosition)
        {
            ui.rootRect.localPosition = spawnPosition;

            return ui;
        }
    }
}
