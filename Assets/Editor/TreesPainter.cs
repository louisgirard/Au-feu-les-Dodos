﻿using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class TreesPainter : EditorWindow
{
    bool isPainting = false;
    public GameObject[] trees = new GameObject[] { };
    public GameObject parent;
    float brushSize = 3f;
    float treeDensity = 2f;
    float minTreeSize = 0.8f;
    float maxTreeSize = 1.2f;

    [MenuItem("Window/TreesPainter")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        TreesPainter window = (TreesPainter)EditorWindow.GetWindow(typeof(TreesPainter));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Settings", EditorStyles.boldLabel);

        if (isPainting)
        {
            if (GUILayout.Button("Stop Paint"))
            {
                isPainting = false;
            }
        }
        else
        {
            if (GUILayout.Button("Paint"))
            {
                isPainting = true;
            }
        }

        SerializedObject so = new SerializedObject(this);
        SerializedProperty treesProperty = so.FindProperty("trees");
        EditorGUILayout.PropertyField(treesProperty, true);
        so.ApplyModifiedProperties();

        parent = (GameObject)EditorGUILayout.ObjectField("Parent in Scene", parent, typeof(GameObject), true);

        brushSize = EditorGUILayout.Slider("Brush Size", brushSize, 1f, 100f);

        treeDensity = EditorGUILayout.Slider("Tree Density", treeDensity, 1f, 100f);

        minTreeSize = EditorGUILayout.FloatField("Tree Size Min", minTreeSize);

        maxTreeSize = EditorGUILayout.FloatField("Tree Size Max", maxTreeSize);
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
       isPainting = false;
    }

    void OnSceneGUI(SceneView scene)
    {
        if (!isPainting) return;

        // Repaint to always see circle around mouse
        if(Event.current.type is EventType.MouseMove)
        {
            scene.Repaint();
        }

        //Draw circle
        Handles.CircleHandleCap(0, MousePosition(), Quaternion.identity, brushSize / 2, EventType.Repaint);

        // Paint trees when mouse left click
        if (parent == null) return;
        if (Event.current.type is EventType.MouseDown && Event.current.button == 0 && trees.Length > 0)
        {
           PaintTrees();
        }
    }

    private void PaintTrees()
    {
        int treesNumber = Mathf.RoundToInt(brushSize * treeDensity);
        List<GameObject> treesCreated = new List<GameObject>();

        for (int i = 0; i < treesNumber; i++)
        {
            // Create the tree
            GameObject tree = (GameObject)PrefabUtility.InstantiatePrefab(RandomTree(), parent.transform);
            // Set its position
            tree.transform.position = RandomPointInCircle() + MousePosition();
            // Scale it
            float scale = Random.Range(minTreeSize, maxTreeSize);
            tree.transform.localScale *= scale;
            // Change position renderer offset
            PositionRendererSorter treeOrderSorter = tree.GetComponent<PositionRendererSorter>();
            treeOrderSorter.offset -= (1 - scale);
            treeOrderSorter.offset = Mathf.Floor(treeOrderSorter.offset * 10f) / 10f;

            treesCreated.Add(tree);
            Undo.RegisterCreatedObjectUndo(tree, "tree");
        }
    }

    private Vector2 MousePosition()
    {
        return HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
    }

    private Vector2 RandomPointInCircle()
    {
        float a = Random.Range(0f, 1f) * 2 * Mathf.PI;
        float r = brushSize / 2 * Mathf.Sqrt(Random.Range(0f, 1f));

        return new Vector2(r * Mathf.Cos(a), r * Mathf.Sin(a));
    }

    private GameObject RandomTree()
    {
        return trees[Random.Range(0, trees.Length)];
    }

    private Vector2 TreePosition(List<GameObject> trees)
    {
        bool positionValid;
        Vector2 position;
        // Find a new position while current tree is too close to other trees
        do
        {
            positionValid = true;
            position = RandomPointInCircle() + MousePosition();
            foreach(GameObject tree in trees)
            {
                if (Vector2.Distance(position, tree.transform.position) < (brushSize / treeDensity))
                {
                    positionValid = false;
                    break;
                }
            }
        } while (!positionValid);

        return position;
    }
}
