using Questao2.Result;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&";
        var competition = Task.Run(() => GetUri(new Uri(url)));
        var result = competition.Result;

        var compettionDeserilializado = Newtonsoft.Json.JsonConvert.DeserializeObject<CompetitionResult>(result);

        var gols = compettionDeserilializado?.Data.Where(x => x.Team1 == team && x.Year == year).Select(x => x.Team1Goals).Sum();
        
        return gols ?? 0;
    }

    static async Task<string> GetUri(Uri url)
    {
        var response = string.Empty;

        using (var client = new HttpClient())
        {
            HttpResponseMessage result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                response = await result.Content.ReadAsStringAsync();
            }
        }

        return response;
    }
}