using System;
using EnsatProject.Areas.Identity.Data;
using EnsatProject.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EnsatProject.Areas.Identity.IdentityHostingStartup))]
namespace EnsatProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EnsatProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EnsatProjectContextConnection")));

                services.AddDefaultIdentity<EnsatProjectUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<EnsatProjectContext>();
            });
        }
    }
}