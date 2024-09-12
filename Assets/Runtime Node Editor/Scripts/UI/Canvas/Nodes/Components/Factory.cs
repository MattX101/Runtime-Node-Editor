using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using Utils.StringParameterExtractor;
using UnityEngine;
using System;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static class Factory
    {
        private const string NodeNamespace = "RuntimeNodeEditor.UI.Canvas.Nodes.Node.";

        internal static NodeUI CreateNode(string id, Vector3 position)
        {
            // Removes parameters from id else 'not null' error is thrown
            string typeId = StringParameterExtractor.ExtractBase(id);

            if (typeId.Length > byte.MaxValue)
            {
                Debug.LogError("Name of node cannot exceed 255 characters!");

                return null;
            }

            Type type = Type.GetType(NodeNamespace + typeId);
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