using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.serveyer;


public class GlobalStateService
{
    public bool dark { get; set; }
    public Dictionary<string, string> GlobalFile { get; set; }

    public Dictionary<string, int> indexnow { get; set; }

    public Dictionary<string, List<int>> ordernow { get; set; }

    public GlobalStateService()
    {
        indexnow = new Dictionary<string, int>();
        ordernow = new Dictionary<string, List<int>>();
        GlobalFile = new Dictionary<string, string>();
    }
    // 可以添加更多的全局变量或方法
}