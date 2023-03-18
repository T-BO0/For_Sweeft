using Newtonsoft.Json;
using RestSharp;
using sweeft.Data;
using sweeft.Models;


//task 1
bool IsItPalindrome(string text)
{
    string txt = new string(text.ToLower().ToArray());
    return txt == new string(txt.Reverse().ToArray());
}


//task 2
int MinSplit(int money)
{
    int numSplit = 0;
    int[] arr = {50,20,10,5,1};
    for (int i = 0; i < arr.Length; i++)
    {
        while(money >= arr[i])
        {
            money -= arr[i];
            numSplit++;
        }
    }
    return numSplit;
}


//task 3
int NotInIt(int[] arr)
{
    int num = 0;
    Array.Sort(arr);
    for (int i = 1; i < arr.Length; i++)
    {
        if(!arr.Contains(i))
        {
            num = i;
            break;
        }
    }
    if(num == 0)
        return arr.Last()+1;
    return num;
}


//task 4
bool IsItWrittenCorrectly(string txt)
{
    var stack = new Stack<char>();
    
    foreach (char c in txt)
    {
        if (c == '(')
        {
            stack.Push(c);
        }
        else if (c == ')')
        {
            if (stack.Count == 0 || stack.Pop() != '(')
            {
                return false;
            }
        }
    }

    return stack.Count == 0;
}


//task 5
int NubmerOfWaysToClimb(int n)
{
    if (n == 0 || n == 1) {
        return 1;
    }
    int[] dp = new int[n + 1];
    dp[0] = 1;
    dp[1] = 1;
    for (int i = 2; i <= n; i++) {
        dp[i] = dp[i - 1] + dp[i - 2];
    }
    return dp[n];
}


// task 7
List<Teacher> GetTeachers()
{
    var context = new SkolaContext();
    var teachers = context.Teachers.Where(te => te.TeacherPupils.Any(pu => pu.Pupil.FirstName == "გიორგი")).ToList();

    return teachers;
}


//task 8
void WriteTextFromAPI()
{
    var httpClient = new RestClient("https://restcountries.com/v3.1/");
    var request = new RestRequest("all", Method.Get);
    var resp = httpClient.Execute(request);
    dynamic countries = JsonConvert.DeserializeObject<object>(resp.Content);

    foreach (var country in countries)
    {
        string filePath = "Task8/" + country.name.common + ".txt";

        if (!Directory.Exists("Taks8"))
            Directory.CreateDirectory("Task8");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine($"Country Name: {country.name.common}");
            writer.WriteLine($"Country Region: {country.region}");
            writer.WriteLine($"Country SubRegion: {country.subregion}");
            writer.WriteLine($"Country LatNLng: {country.latlng[0]}, {country.latlng[1]}");
            writer.WriteLine($"Country Area: {country.area}");
            writer.WriteLine($"Country Population: {country.population}");
        }
    }
}