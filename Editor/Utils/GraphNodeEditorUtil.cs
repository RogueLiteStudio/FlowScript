﻿using UnityEngine;

namespace Flow
{
    public class GraphNodeEditorUtil
    {
        public static void OnNodePosition(FlowGraphEditor graphEditor, string nodeGUID, Rect position)
        {
            var nodeView = graphEditor.Graph.NodeViews.Find(it => it.NodeGUID == nodeGUID);
            if (nodeView != null)
            {
                GraphEditorUtil.RegisterUndo(graphEditor.Graph.Owner, "move node");
                nodeView.Position = position;
            }
        }

        public static void OnNodeExpanded(FlowGraphEditor graphEditor, string nodeGUID, bool expanded)
        {
            var nodeView = graphEditor.Graph.NodeViews.Find(it => it.NodeGUID == nodeGUID);
            if (nodeView != null)
            {
                GraphEditorUtil.RegisterUndo(graphEditor.Graph.Owner, "node expanded");
                nodeView.Expanded = expanded;
            }
        }

        public static void OnNodeSelected(FlowGraphEditor graphEditor, string nodeGUID, bool selected)
        {
            var index = graphEditor.Graph.Nodes.FindIndex(it => it.GUID == nodeGUID);
            if (index >= 0)
            {
                var nodeRef = graphEditor.Graph.Nodes[index];
                if (selected)
                {
                    graphEditor.SelectNodes.Add(nodeRef);
                }
                else
                {
                    graphEditor.SelectNodes.Remove(nodeRef);
                }
            }
        }

        public static void DeleteNode(FlowGraphEditor graphEditor, string nodeGUID)
        {

        }

        public static void CreateNode(FlowGraphEditor graphEditor, System.Type nodeType, Rect position)
        {

        }
    }
}
