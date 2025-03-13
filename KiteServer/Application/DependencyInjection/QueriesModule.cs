﻿using Application.Queries.System.Menu;
using Application.Queries.System.Post;

namespace Application.DependencyInjection;

public class QueriesModule : Module
{
    private readonly IServiceProvider _serviceProvider;

    public QueriesModule(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(c => new MenuQueries(_serviceProvider)).As<IMenuQueries>().InstancePerLifetimeScope();
        builder.Register(c => new PostQueries(_serviceProvider)).As<IPostQueries>().InstancePerLifetimeScope();
    }
}
