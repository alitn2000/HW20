namespace App.Domain.Core.TurnsManager.ResultAggrigate;

public class Result
{
    public bool Flag { get; set; }
    public string Message { get; set; }

    public Result(bool flag, string message)
    {
        Flag = flag;
        Message = message;
    }
}
