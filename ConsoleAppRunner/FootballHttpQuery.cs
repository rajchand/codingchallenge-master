using ConsoleAppRunner;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

[DataContractAttribute]
public class ResultsDrawClass
{
    //{"page":1,"per_page":10,"total":162,"total_pages":17,
    //"data":[{"competition":"UEFA Champions League","year":2011,"round":"GroupE","team1":"KRC Genk","team2":"Valencia CF","team1goals":"0","team2goals":"0"}]}
    public ResultsDrawClass()
    {
        data = new List<DrawResults>();
    }
    [DataMemberAttribute]
    public string page { get; set; }
    [DataMemberAttribute]
    public string per_page { get; set; }
    [DataMemberAttribute]
    public string total { get; set; }
    [DataMemberAttribute]
    public string total_pages { get; set; }
    [DataMemberAttribute]
    public List<DrawResults> data { get; set; }
}

[DataContractAttribute]
public class DrawResults
{
    [DataMemberAttribute]
    public string competition { get; set; }
    [DataMemberAttribute]
    public string year { get; set; }
    [DataMemberAttribute]
    public string round { get; set; }
    [DataMemberAttribute]
    public string team1 { get; set; }
    [DataMemberAttribute]
    public string team2 { get; set; }
    [DataMemberAttribute]
    public string team1goals { get; set; }
    [DataMemberAttribute]
    public string team2goals { get; set; }
}

[DataContractAttribute]
public class ResultsWinnerClass
{
    public ResultsWinnerClass()
    {
        data = new List<WinnerResults>();
    }
    [DataMemberAttribute]
    public string page { get; set; }
    [DataMemberAttribute]
    public string per_page { get; set; }
    [DataMemberAttribute]
    public string total { get; set; }
    [DataMemberAttribute]
    public string total_pages { get; set; }
    [DataMemberAttribute]
    public List<WinnerResults> data { get; set; }
}

[DataContractAttribute]
public class WinnerResults
{
    [DataMemberAttribute]
    public string name { get; set; }
    [DataMemberAttribute]
    public string year { get; set; }
    [DataMemberAttribute]
    public string country { get; set; }
    [DataMemberAttribute]
    public string winner { get; set; }
    [DataMemberAttribute]
    public string runnerup { get; set; }
}

public class FootballGetNumDraws
{
    /*
     * Complete the 'getNumDraws' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER year as parameter.
     */
   
    public static int getNumDraws(int year)
    {
        int drawCount = 0;
        for (int i = 0; i < 10; i++)
        {            
            string responseJson = HttpHelper.GetJsonResponse($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1goals={i}&team2goals={i}");            
            var drawItems = HttpHelper.JsonDeserialize<ResultsDrawClass>(responseJson);            
            drawCount += StringHelper.ConvertToInt32(drawItems.total);
        }
        return drawCount;
    }

}

public class FootballGetWinnerTotalGoals
{
    /*
     * Complete the 'getWinnerTotalGoals' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING competition
     *  2. INTEGER year
     */     
    public static int getWinnerTotalGoals(string competition, int year)
    {
        // Competition and year, total goals for winner        
        string responseJson = HttpHelper.GetJsonResponse($"https://jsonmock.hackerrank.com/api/football_competitions?name={competition}&year={year}");        
        var winnerItem = HttpHelper.JsonDeserialize<ResultsWinnerClass>(responseJson);

        var winningTeam = winnerItem.data.FirstOrDefault().winner;

        // Get Match result for winning team home and away
        var totalGoalCount = 0;
        for (int i = 1; i <= 2; i++)
        {
            responseJson = HttpHelper.GetJsonResponse($"https://jsonmock.hackerrank.com/api/football_matches?competition={competition}&year={year}&team{i}={winningTeam}");
            var resultClass = HttpHelper.JsonDeserialize<ResultsDrawClass>(responseJson);

            // Take first page and continue
            totalGoalCount += GetGoalsFromResult(resultClass, winningTeam);

            // If multiple pages then loop through
            if (StringHelper.ConvertToInt32(resultClass.total_pages) > 1)
            {
                for (int p = 2; p <= StringHelper.ConvertToInt32(resultClass.total_pages); p++)
                {
                    responseJson = HttpHelper.GetJsonResponse($"https://jsonmock.hackerrank.com/api/football_matches?competition={competition}&year={year}&team{i}={winningTeam}&page={p}");
                    resultClass = HttpHelper.JsonDeserialize<ResultsDrawClass>(responseJson);

                    totalGoalCount += GetGoalsFromResult(resultClass, winningTeam);
                }
            }            
        }
        
        return totalGoalCount;
    }
    
    private static int GetGoalsFromResult(ResultsDrawClass resultsClass, string winningTeam)
    {
        int goals = 0;
        foreach (var result in resultsClass.data)
        {            
            if (result.team1 == winningTeam)
            {
                goals += StringHelper.ConvertToInt32(result.team1goals);
            }

            if (result.team2 == winningTeam)
            {
                goals += StringHelper.ConvertToInt32(result.team2goals);
            }
        }
        return goals;
    }
}





