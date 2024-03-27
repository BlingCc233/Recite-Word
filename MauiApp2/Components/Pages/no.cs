



@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}







@code {
    [Parameter] public string BookName { get; set; }



    private List<string[]> allWords = new List<string[]>();
    private List<int> randomNumbers = new List<int>();
    private string nowWord = "";
    private int index = 1;
    private int revise = 1;
    private bool flag = false;

    private void Word()
    {
        if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
        else nowWord = allWords[randomNumbers[index - 1]][0];

    }

    private void Check()
    {
        try
        {

            flag = !flag;
            if (flag) nowWord = allWords[randomNumbers[index - 1]][1];
            else nowWord = allWords[randomNumbers[index - 1]][0];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void GenerateRandomNumbers()
    {
        if (randomNumbers == null)
        {
            randomNumbers = new List<int>();

        }
        randomNumbers.Clear(); // 清空之前的随机数列
        int length = allWords.Count; // 获取allWords的长度
        Random rnd = new Random();

        while (randomNumbers.Count < length)
        {
            int number = rnd.Next(0, length); // 生成1到length之间的随机数
            if (!randomNumbers.Contains(number)) // 确保没有重复
            {
                randomNumbers.Add(number);
            }
        }
    }


    protected override async Task OnInitializedAsync()
    {
        if (GlobalState.indexnow.TryGetValue(BookName, out index))
        {

        }
        else
        {
            index = 1;
        }

        Console.WriteLine(BookName);


        try
        {
            var file = GlobalState.GlobalFile[BookName];


            var content = file;
            var lines = content.Replace("\r\n", ",").Replace("\n", ",").Replace("\r", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Define the regular expression to match English words and corresponding Chinese translations
            int count = 0;
            string tmp = "";
            string chi = "";
            bool flag = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("\""))
                {
                    flag = true;
                    chi += line;
                    continue;
                }

                if (!line.StartsWith("\n") && !flag)
                {
                    count++;
                }

                if (flag && !line.EndsWith("\""))
                {
                    chi += line;
                    continue;

                }

                if (flag && line.EndsWith("\""))
                {
                    chi += line;
                    flag = false;
                    count++;
                }

                if (count % 2 == 1)
                {
                    tmp = line;
                }
                else
                {
                    if (string.IsNullOrEmpty(chi))
                    {
                        chi = line;
                    }

                    allWords.Add(new string[] { tmp, chi });
                    tmp = "";
                    chi = "";
                }


            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during file reading
            Console.WriteLine($"Error reading file: {ex.Message}");
        }



        if (GlobalState.ordernow.TryGetValue(BookName, out randomNumbers))
        {
        }
        else
        {
            GenerateRandomNumbers();
            GlobalState.ordernow[BookName] = randomNumbers;
        }

        // foreach (var x in randomNumbers)
        // {
        //     Console.WriteLine(allWords[x][0]);
        //     Console.WriteLine(allWords[x][1]);
        //     Console.WriteLine(randomNumbers.IndexOf(x));
        //
        // }
        Console.WriteLine(index);
        nowWord = allWords[randomNumbers[index - 1]][0];
    }






    private string WhichTot()
    {
        return allWords.Count.ToString();

    }

    private string btnClick = "";
    private void OnPreviousClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == 1) return;
        index--;
        GlobalState.indexnow[BookName] = index;
        Word();

    }

    private void OnNextClick()
    {
        // 在这里处理点击事件
        btnClick = "btn-click";
        if (index == int.Parse(WhichTot()))
        {
            return;
        }
        index++;
        // if (revise < index % 10)
        // {
        //     revise++;
        // }
        GlobalState.indexnow[BookName] = index;

        Word();

    }





}



