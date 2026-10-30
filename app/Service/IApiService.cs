using CSharpExercise.app.Entity;

namespace CSharpExercise.app.Service;

public interface IApiService
{
    Api Create(Api api);
    List<Api> FindAll();
    Api? FindById(int id);
    Task<int> Check(Api api);
    Task<int> CheckAll();
    void Update(Api api);
    void Delete(Api api);
}
