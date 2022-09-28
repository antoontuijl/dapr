using Dapr.Client;

const string storeName = "statestore";
const string key = "counter";

var daprClient = new DaprClientBuilder().Build();
var counter = await daprClient.GetStateAsync<int>(storeName, key);

while (true)
{
    Console.WriteLine($"Counter = {counter++}");
    await daprClient.SaveStateAsync(storeName, key, counter);
    await Task.Delay(1000);
}

//https://docs.dapr.io/getting-started/install-dapr-cli/
//dapr init
//dapr --version
//dapr run --app-id DaprCounter dotnet run
// %USERPROFILE%\.dapr\components