using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerApiTemplate.Api.Authorization;
using ServerApiTemplate.Application.Common.Models;
using ServerApiTemplate.Application.Features.V1.ApiLogs.DTOs;
using ServerApiTemplate.Application.Features.V1.ApiLogs.Queries;
using ServerApiTemplate.Domain.Constants;
using ServerApiTemplate.Domain.Enums;

namespace ServerApiTemplate.Api.Controllers.V1;

/// <summary>Tra cứu log request/response API để debug (chuẩn BE §9.2 · RULES.md §8).</summary>
[Route("api/v1/api-logs")]
[HasPermission(ConstActivity.ApiLog, ActivityType.Read)]
public sealed class ApiLogsController(ISender mediator) : ApiControllerBase(mediator)
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<ApiLogListItemDto>>> Search([FromQuery] SearchApiLogsQuery query, CancellationToken ct) =>
        Ok(await Mediator.Send(query, ct));

    [HttpGet("{id:long}")]
    public async Task<ActionResult<ApiLogDetailDto>> Get(long id, CancellationToken ct) =>
        Ok(await Mediator.Send(new GetApiLogDetailQuery(id), ct));
}
