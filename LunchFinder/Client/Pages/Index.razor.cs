namespace LunchFinder.Client.Pages;

using Lunchfinder.Api;

public partial class Index
{
    public static async void Test()
    {
        var client = new TagsClient("localhost:5721", new HttpClient());


        var tag = await client.GetTagAsync(1);
        Console.WriteLine(tag.Name);
    }
}