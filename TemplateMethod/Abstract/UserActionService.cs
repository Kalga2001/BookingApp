using BookingApp.DataContext;
using BookingApp.Helpers;
using BookingApp.Models;

public abstract class UserActionService
{
    public CustomResponse PerformAction(CustomActionRequest request)
    {
        if (!ValidateRequest(request))
        {
            return new CustomResponse { Code = 400, Message = "Bad Request" };
        }

        return ExecuteAction(request);
    }

    protected abstract bool ValidateRequest(CustomActionRequest request);

    protected abstract CustomResponse ExecuteAction(CustomActionRequest request);
}