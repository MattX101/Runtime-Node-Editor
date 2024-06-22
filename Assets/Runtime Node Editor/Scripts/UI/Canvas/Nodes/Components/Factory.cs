using System;
using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static class Factory
    {
        private const string NodeNamespace = "RuntimeNodeEditor.UI.Canvas.Nodes.Node.";
        
        public static NodeUI CreateNode(string id, Vector3 position)
        {
            if (id.Length > byte.MaxValue)
            {
                Debug.LogError("Name of node cannot exceed 255 characters!");

                return null;
            }

            Type type = Type.GetType(NodeNamespace + id);
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            GameObject nodeUIObject = new GameObject();
            NodeUI nodeUI = (NodeUI)nodeUIObject.AddComponent(type);
            nodeUI.Init(id);
            nodeUI.rootRect.localPosition = position;

            return nodeUI;
        }

    }
}