using CSharpExercise.app.Entity;
using CSharpExercise.app.Repository;
using CSharpExercise.app.Service;

ApiRepository apiRepository = new();
ApiService apiService = new(apiRepository);
int id = 1;

void Create(IApiService apiService, string name, int delayTime)
{
    Api api = new(name, delayTime);
    Api saved = apiService.Create(api);
    Console.WriteLine(saved.ToString());
}

void FindAll(IApiService apiService)
{
    foreach (Api api in apiService.FindAll())
    {
        Console.WriteLine(api.ToString());
    } 
}

void FindById(IApiService apiService, int id)
{
    Console.WriteLine(apiService.FindById(id)?.ToString());
}

static async Task CheckById(IApiService apiService, int id)
{
    Api? api = apiService.FindById(id);

    if (api != null)
    {
        int duration = await apiService.Check(api);
        Console.WriteLine($"Tempo total: {duration} ms");
        Console.WriteLine(api.ToString());
    }
    else
    {
        Console.WriteLine("Api não encontrada");
    }
}

static async Task CheckAll(IApiService apiService)
{
    int duration = await apiService.CheckAll();
    Console.WriteLine($"Tempo total: {duration} ms");

    foreach (Api api in apiService.FindAll())
    {
        Console.WriteLine(api.ToString());
    }   
}

void UpdateById(IApiService apiService, string name)
{
    Api? api = apiService.FindById(id);
    
    if (api != null)
    {
        api.SetName(name);
        apiService.Update(api);
    }
    else
    {
        Console.WriteLine("Api não encontrada");
    }
}

void DeleteById(IApiService apiService, int id)
{
    Api? api = apiService.FindById(id);
    
    if (api != null)
    {
        apiService.Delete(api);
    }
    else
    {
        Console.WriteLine("Api não encontrada");
    }
}

Create(apiService, "Autenticacao", 120);
Create(apiService, "Autenticacao 2", 850);
Create(apiService, "Notificacoes", 0);
Create(apiService, "Relatorios", 320);
Create(apiService, "Estoque", 1200);
Create(apiService, "Usuarios", 90);
Console.WriteLine();

FindById(apiService, id);
Console.WriteLine();

await CheckById(apiService, id);
Console.WriteLine();

await CheckAll(apiService);
Console.WriteLine();

UpdateById(apiService, "Novo nome");
DeleteById(apiService, 2);

FindAll(apiService);
Console.WriteLine();
