using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TomorrowsLunch.Models;

namespace TomorrowsLunch.AzureMachineLearning
{
    public class IngredientsClustering
    {
        public static List<Ingredient> Ingredients;

        private class StringTable
        {
            public string[] ColumnNames { get; set; }
            public string[,] Values { get; set; }
        }
        public class Value
        {
            public List<string> ColumnNames { get; set; }
            public List<string> ColumnTypes { get; set; }
            public List<List<string>> Values { get; set; }
        }

        public static async Task InvokeRequestResponseService()
        {
            using (var client = new HttpClient())
            {
                string[,] values = new string[Ingredients.Count, 5];
                int counter = 0;
                foreach (var item in Ingredients)
                {
                    values[counter, 0] = item.Carbohydrates.ToString();
                    values[counter, 1] = item.Fat.ToString();
                    values[counter, 2] = item.Proteins.ToString();
                    values[counter, 3] = item.Name;
                    values[counter, 4] = item.Calories.ToString();

                    counter++;
                }
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"CARBOHYDRATES", "FAT", "PROTEINS", "NAME", "CALORIES"},
                                Values = values
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "MuCzSFQEeSIRrh1GCkC96ctDraZzz6LaOJmLtdgiW65rOw5TwNyk6gh+S8wYWXiUs/yOg+itiOXoqd8xgvKwjw=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/b18ad9f1009f4191837c680d297f1224/services/e022f842d5b04a7d97f4949c02edaf1f/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    result = result.Remove(result.Length - 3);
                    result = result.Substring(46, result.Length - 46);

                    Value groupedIngredients = new JavaScriptSerializer().Deserialize<Value>(result);

                    for (int i = 0; i < groupedIngredients.Values.Count; i++)
                    {
                        Ingredients.Where(ing => ing.Name.Equals(groupedIngredients.Values.ElementAt(i).ElementAt(3))).FirstOrDefault().Group = Convert.ToInt32(groupedIngredients.Values.ElementAt(i).ElementAt(5));
                    }
                }

                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
            }
        }
    }
}