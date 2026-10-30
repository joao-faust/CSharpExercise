using CSharpExercise.app.Entity;

namespace CSharpExercise.app.Repository;

public interface IApiRepository
{
    Api Create(Api api);
    List<Api> FindAll();
    Api? FindById(int id);
    void Update(Api api);
    void Delete(Api api);
}
