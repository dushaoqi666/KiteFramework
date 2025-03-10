﻿using Domain.Aggregate;
using System.Linq.Expressions;
using Domain.FileAndFolderInfo;
using Domain.FileInfo;
using Domain.UserInfo;

namespace Repository.Repositories;

public class DBContext : SugarUnitOfWork
{
    /// <summary>
    /// 用户
    /// </summary>
    public DbSet<UserInfo> Users { get; set; }

    public DbSet<FileInfos> Files { get; set; }
    public DbSet<FolderInfos> Folders { get; set; }
    
}

public class DbSet<T> : SimpleClient<T> where T : class, IDeleted, new()
{
    /// <summary>
    /// 逻辑删除
    /// </summary>
    public override bool Delete(T deleteObj)
    {
        deleteObj.IsDeleted = true;
        return Context.Updateable(deleteObj).ExecuteCommand() > 0;
    }

    /// <summary>
    /// 逻辑删除
    /// </summary>
    public override async Task<bool> DeleteAsync(T deleteObj)
    {
        deleteObj.IsDeleted = true;
        return await Context.Updateable(deleteObj).ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 逻辑删除
    /// </summary>
    public override bool Delete(Expression<Func<T, bool>> exp)
    {
        return Context.Updateable<T>().SetColumns(it => new T() { IsDeleted = true }, true).Where(exp)
            .ExecuteCommand() > 0;
    }

    /// <summary>
    /// 逻辑删除
    /// </summary>
    public override async Task<bool> DeleteAsync(Expression<Func<T, bool>> exp)
    {
        return await Context.Updateable<T>().SetColumns(it => new T() { IsDeleted = true }, true).Where(exp)
            .ExecuteCommandAsync() > 0;
    }
}