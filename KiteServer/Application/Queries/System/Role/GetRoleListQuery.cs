using DomainShared.Dto;
using DomainShared.Dto.System;
using MediatR;

namespace Application.Queries.System.Role;

/// <summary>
/// 获取角色列表查询
/// </summary>
public class GetRoleListQuery : IRequest<PagedList<RoleDto>>
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public RoleDto QueryDto { get; set; }
}
