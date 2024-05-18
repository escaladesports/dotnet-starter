namespace CleanArchitecture.Application.Common.Interfaces;

public interface IUser
{
    string? Id { get; }
    int? LocationHeaderId { get; }
    int? LocationId { get; }
    string Schema { get; }
}
