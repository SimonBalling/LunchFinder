namespace LunchFinder.Client.Pages
{

    public partial class Index
    {

        public void test()
        {
            var client = new Lunchfinder.Api.Client("localhost:5721", new HttpClient());
            
            
            var task = client.GetAllTagsAsync();
            Console.WriteLine(task.Result);
        }

    }
}
