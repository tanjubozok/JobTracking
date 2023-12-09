namespace JobTracking.Business.DependencyResolvers;

public static class DependencyExtension
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("LocalPostgreSql"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICategoryService, CategoryManager>();

        services.AddTransient<IValidator<CategoryAddDto>, CategoryAddDtoValidator>();
        services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();


        #region AutoMapper

        var profiles = ProfileHelper.GetProfiles();
        var conf = new MapperConfiguration(opt =>
        {
            opt.AddProfiles(profiles);
        });
        var mapper = conf.CreateMapper();
        services.AddSingleton(mapper); 

        #endregion
    }
}
