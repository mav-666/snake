using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utils
{
    #if UNITY_EDITOR
    public static class EditorUtils
    {
        [MenuItem("Utils/Reserialize all prefabs")]
        private static void onClick_ReserializeAllPrefabs()
        {
            foreach (string prefabPath in GetAllPrefabs())
            {
                GameObject _prefabAsset = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                if (!PrefabUtility.IsPartOfImmutablePrefab(_prefabAsset))
                {
                    PrefabUtility.SavePrefabAsset(_prefabAsset);
                }
            }
        }
    
        public static string[] GetAllPrefabs()
        {
            List<string> prefabPaths = new List<string>();
            foreach (string paths in AssetDatabase.GetAllAssetPaths())
            {
                if (paths.Contains(".prefab"))
                {
                    prefabPaths.Add(paths);
                }
            }
            return prefabPaths.ToArray();
        }
        
        [MenuItem("Utils/Mass Set Materials")]
        public static void MassSetMaterials()
        {
            var material = Resources.Load("Material/Default", typeof(Material)) as Material;

            var renderers = Object.FindObjectsByType<Renderer>(FindObjectsSortMode.None);

            foreach (var renderer in renderers)
                renderer.material = material;
        }
        
        public static T GetCopyOf<T>(this Component comp, T other) where T : Component
        {
            Type type = comp.GetType();
            if (type != other.GetType()) return null; // type mis-match
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
            PropertyInfo[] pinfos = type.GetProperties(flags);
            foreach (var pinfo in pinfos) {
                if (pinfo.CanWrite) {
                    try {
                        pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                    }
                    catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                }
            }
            FieldInfo[] finfos = type.GetFields(flags);
            foreach (var finfo in finfos) {
                finfo.SetValue(comp, finfo.GetValue(other));
            }
            return comp as T;
        }
        
        public static T AddComponent<T>(this GameObject go, T toAdd) where T : Component
        {
            return go.AddComponent<T>().GetCopyOf(toAdd) as T;
        }
    }
    #endif
}