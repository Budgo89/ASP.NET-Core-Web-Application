using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASP.NET_Core_Web_Application
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            var tasks = new List<Task<PostModel>>();
            for (uint i = 4; i <= 13; i++)
                tasks.Add(GetPostByID(i));

            Task.WaitAll(tasks.ToArray());

            using (var sw = new StreamWriter(File.Create("result.txt")))
            {
                foreach (var task in tasks)
                    if (task.IsCompleted && task.Exception == null)
                        sw.WriteLine(task.Result);
            }
		}
        private static async Task<PostModel> GetPostByID(uint postID)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{postID}");

            if (response.IsSuccessStatusCode)
            {
                await using var responseStream = await response.Content.ReadAsStreamAsync();
                if (await JsonSerializer.DeserializeAsync<PostModel>(responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web)) is PostModel post)
                    return post;
                else
                    throw new Exception($"Error content");
            }
            else
            {
                throw new Exception($"Eroor code: {response.StatusCode}");
            }
        }
    }
}