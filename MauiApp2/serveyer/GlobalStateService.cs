using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;

namespace MauiApp2.serveyer;

public class GlobalStateService
{
    private const string FilePath = "init.json"; // 设置JSON文件的保存路径

    public bool daker { get; set; }

    public Dictionary<string, string> GlobalFile { get; set; } = new Dictionary<string, string>();

    public Dictionary<string, int> indexnow { get; set; } = new Dictionary<string, int>();

    public Dictionary<string, List<int>> ordernow { get; set; } = new Dictionary<string, List<int>>();

    public event Action OnStateChanged;

    public GlobalStateService()
    {
        LoadStateFromFile(); // 在构造函数中尝试从文件加载状态
    }

    public void SaveStateToFile()
    {
        var state = new
        {
            daker = this.daker,
            GlobalFile = this.GlobalFile,
            indexnow = this.indexnow,
            ordernow = this.ordernow
        };
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(state, options);
        File.WriteAllText(FilePath, jsonString);
    }

    private void LoadStateFromFile()
    {
        if (File.Exists(FilePath))
        {
            var jsonString = File.ReadAllText(FilePath);
            var state = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

            if (state != null)
            {
                if (state.ContainsKey("daker"))
                    this.daker = state["daker"].GetBoolean();
                if (state.ContainsKey("GlobalFile"))
                    this.GlobalFile = JsonSerializer.Deserialize<Dictionary<string, string>>(state["GlobalFile"].GetRawText());
                if (state.ContainsKey("indexnow"))
                    this.indexnow = JsonSerializer.Deserialize<Dictionary<string, int>>(state["indexnow"].GetRawText());
                if (state.ContainsKey("ordernow"))
                    this.ordernow = JsonSerializer.Deserialize<Dictionary<string, List<int>>>(state["ordernow"].GetRawText());
            }
        }
    }
}