namespace CSharpExercise.app.Entity;

public class Api
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int DelayTime { get; private set; }

    public Api(int id, string name, int delayTime)
    {
        Id = id;
        Name = name;
        DelayTime = delayTime;
    }

    public override string ToString()
    {
        return $"{Id}: {Name} - {DelayTime} ms - {GetStatus()}";
    }

    public Api(string name, int delayTime)
    {
        Name = name;
        DelayTime = delayTime;
    }

    public Api Clone()
    {
        return new(Id, Name, DelayTime);
    }

    public void SetId(int id)
    {
        Id = id;
    }

    public void SetDelayTime(int delayTime)
    {
        DelayTime = delayTime;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public bool IsAvailable()
    {
        return DelayTime <= 1200;
    }

    public bool IsFast()
    {
        return DelayTime <= 250;
    }

    public bool IsSlow()
    {
        return DelayTime > 500;
    }

    public bool IsModerate()
    {
        return IsAvailable() && !IsFast() && !IsSlow(); 
    }

    public bool IsHealthy()
    {
        return IsAvailable() && !IsSlow();
    }

    public ApiStatus GetStatus()
    {
        if (!IsAvailable())
        {
            return ApiStatus.Unavailable;
        }

        if (!IsSlow()) 
        {
            return ApiStatus.Healthy;
        }

        return ApiStatus.Slow;
    } 
}
