using System.IO;
using Newtonsoft.Json;
using System;
using UnityEngine;

public class JsonTool
{
    public static void AsyncWriteByJson(string globalizeFilePath, object data)
    {
        Debug.Log($"Write file:  {globalizeFilePath}");
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        FileInfo fileInfo = new FileInfo(globalizeFilePath);
        var di = fileInfo.Directory;
        if (!di.Exists)
            di.Create();
        // File.WriteAllText(filePath, json);
        File.WriteAllTextAsync(globalizeFilePath, json);
    }
    public static object ReadByJson(string globalizeFilePath)
    {
        Debug.Log($"Read file:  {globalizeFilePath}");
        try
        {
            // 检查文件是否存在
            if (!File.Exists(globalizeFilePath))
            {
                Debug.LogError("File not found: " + globalizeFilePath);
                return null;
            }
            string json = File.ReadAllText(globalizeFilePath);
            return JsonConvert.DeserializeObject(json);
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occurred: " + ex.Message);
            return null;
        }

    }
    public static T ReadByJson<T>(string globalizeFilePath)
    {
        Debug.Log($"Read file:  {globalizeFilePath}");
        try
        {
            // 检查文件是否存在
            if (!File.Exists(globalizeFilePath))
            {
                Debug.LogError("File not found: " + globalizeFilePath);
                return default;
            }
            string json = File.ReadAllText(globalizeFilePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occurred: " + ex.Message);
            return default;
        }
    }
    public static void OperateAllFile(string globalDirectory, Action<string> action, bool includeSubDirectories = true)
    {
        string folderPath = globalDirectory;
        // 获取当前文件夹下的所有文件
        string[] files = Directory.GetFiles(folderPath);

        // 打印当前文件夹内的文件路径
        foreach (string file in files)
        {
            if (file.Contains(".meta")) continue;
            action?.Invoke(file);
        }
        if (includeSubDirectories)
        {
            // 递归处理所有子文件夹
            string[] subdirectories = Directory.GetDirectories(folderPath);
            foreach (string subdirectory in subdirectories)
            {
                OperateAllFile(subdirectory, action);
            }
        }
    }
}
