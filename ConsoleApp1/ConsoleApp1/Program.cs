var options = new RestClientOptions("https://viavuminh.com")
{
    MaxTimeout = -1,
};
var client = new RestClient(options);
var request = new RestRequest("/api/profile.php?api_key=38f3986e951966cc8392db8f6601ca09", Method.Get);
RestResponse response = await client.ExecuteAsync(request);
Console.WriteLine(response.Content);