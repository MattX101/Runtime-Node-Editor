using System.Collections.Generic;
using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class Node : MonoBehaviour
    {
        protected bool wasExecuted = false;
        public bool endNode = false;

        public NodeUI nodeUI = null;

        public List<InputPointer> inputs = new List<InputPointer>();
        public List<OutputPointer> outputs = new List<OutputPointer>();

        private void Update()
        {
            nodeUI.SetAlpha();
        }

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

        public void MoveUp()
        {
            if (endNode)
            {
                Exectute();
                return;
            }
            else
            {
                if (outputs == null)
                    return;

                foreach (OutputPointer output in outputs)
                {
                    if (output.connectedInputPointers == null)
                        continue;

                    foreach (InputPointer input in output.connectedInputPointers)
                        input.node.MoveUp();
                }
            }
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
