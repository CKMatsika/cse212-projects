using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var wordSet = new HashSet<string>(words);

        foreach (var word in words)
        {
            var reversed = new string(new char[] { word[1], word[0] });

            if (word != reversed && wordSet.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
                wordSet.Remove(word);
                wordSet.Remove(reversed);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 4)
            {
                var degree = fields[3].Trim();
                if (degrees.ContainsKey(degree))
                    degrees[degree]++;
                else
                    degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var normalized1 = word1.Replace(" ", "").ToLower();
        var normalized2 = word2.Replace(" ", "").ToLower();

        if (normalized1.Length != normalized2.Length)
            return false;

        var count = new Dictionary<char, int>();

        foreach (var c in normalized1)
        {
            if (count.ContainsKey(c))
                count[c]++;
            else
                count[c] = 1;
        }

        foreach (var c in normalized2)
        {
            if (!count.ContainsKey(c))
                return false;

            count[c]--;
            if (count[c] < 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Read JSON data from USGS earthquake feed and summarize location and magnitude.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var results = new List<string>();
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                if (feature.Properties != null)
                {
                    results.Add($"{feature.Properties.Place} => Magnitude: {feature.Properties.Mag}");
                }
            }
        }

        return results.ToArray();
    }
}
