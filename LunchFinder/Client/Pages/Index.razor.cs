namespace LunchFinder.Client.Pages
{

    public partial class Index
    {

        public void test()
        {
            var client = new Lunchfinder.Api.TagsClient("localhost:5721", new HttpClient());
            
            
            var task = client.GetTagsAsync();
            Console.WriteLine(task.Result);
        }

    }
}
