namespace GerenciamentoVultorian.Domain.Enums;

public enum StatusCodeEnum
{
    Ok = 200,
    Created = 201,
    NoContent = 204,
    NotModified = 304,
    BadRequest = 400,
    Unauthorized = 401,
    NotFound = 404,
    Conflict = 409,
    InternalServerError = 500
}