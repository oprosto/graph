using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class FileHandler
{
    public static void SaveToJSON<T>(List<T> toSave, string path) 
    {
        string content = JsonHelper.ToJson<T>(toSave.ToArray(), true);
        WriteFile(path, content);

    }
    public static List<T> LoadFromJSON<T>(string path) 
    {
        string content = ReadFile(path);
        if (string.IsNullOrEmpty(content) || content == "{}") 
        {
            return new List<T>();
        }

        List<T> res = JsonHelper.FromJson<T>(content).ToList();

        return res;

    }
    private static void WriteFile(string path, string content) 
    {
        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);

        using (StreamWriter writer = new StreamWriter(fileStream)) 
        {
            writer.Write(content);
        }
    } 
    private static string ReadFile(string path) 
    {
        if (File.Exists(path)) 
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint = false)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}