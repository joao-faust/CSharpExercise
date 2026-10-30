using CSharpExercise.app.Entity;

namespace CSharpExercise.app.Repository;

public class ApiRepository : IApiRepository
{
    private readonly List<Api> DataSet = [];
    
    public Api Create(Api api)
    {
        int lastId = DataSet.Select(api => api.Id).DefaultIfEmpty(0).Max();
        int id = lastId + 1;
        api.SetId(id);

        DataSet.Add(api);

        return api;
    }

    public List<Api> FindAll()
    {
        return [.. DataSet.Select(api => api.Clone())];
    }

    public Api? FindById(int id)
    {
        return DataSet.FirstOrDefault(api => api.Id == id)?.Clone();
    }

    public void Update(Api api)
    {
        int index = DataSet.FindIndex(s => s.Id == api.Id);

        if (index != -1)
        {
            DataSet[index] = api.Clone();
        }
    }

    public void Delete(Api api)
    {
        int index = DataSet.FindIndex(s => s.Id == api.Id);

        if (index != -1)
        {
            DataSet.Remove(DataSet[index]);
        }
    }
}
