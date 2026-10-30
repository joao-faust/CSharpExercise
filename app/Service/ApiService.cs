using CSharpExercise.app.Entity;
using CSharpExercise.app.Repository;

namespace CSharpExercise.app.Service;

public class ApiService(IApiRepository repository) : IApiService
{
    private readonly IApiRepository Repository = repository;

    public Api Create(Api api)
    {
        return Repository.Create(api);
    }

    public List<Api> FindAll()
    {
        return Repository.FindAll();
    }

    public Api? FindById(int id)
    {
        return Repository.FindById(id);
    }

    public async Task<int> Check(Api api)
    {
        int delayTime = Random.Shared.Next(1, 2500);
        await Task.Delay(delayTime);
        api.SetDelayTime(delayTime);

        Repository.Update(api);

        return delayTime;
    }

    public async Task<int> CheckAll()
    {
        var tasks = Repository.FindAll().Select(Check);
        int[] results = await Task.WhenAll(tasks);

        return results.Sum();
    }

    public void Update(Api api)
    {
        Repository.Update(api);
    }

    public void Delete(Api api)
    {
        Repository.Delete(api);
    }
}
